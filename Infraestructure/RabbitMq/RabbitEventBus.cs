using CoreDDD.Event;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.RabbitMq
{
    public class RabbitEventBus : IEventBus
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly Dictionary<string, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitEventBus(IMediator mediator, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            _mediator = mediator;
            _handlers = new Dictionary<string, List<Type>>();
            _eventTypes = new List<Type>();
            _configuration = configuration;
            _serviceScopeFactory = serviceScopeFactory;
        }


        public Task SendCommand<T>(T comando) where T : Comand
        {
            return _mediator.Send(comando);
        }

        public void Publish<T>(T evento) where T : Event
        {
            var factory = new ConnectionFactory() { HostName = _configuration["RabbitMqBusHost"] };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var eventName = evento.GetType().Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var message = JsonConvert.SerializeObject(evento);
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", eventName, null, body);
            }


        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventoNombre = typeof(T).Name;
            var manejadorEventoTipo = typeof(TH);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }

            if (!_handlers.ContainsKey(eventoNombre))
            {
                _handlers.Add(eventoNombre, new List<Type>());
            }

            if (_handlers[eventoNombre].Any(x => x.GetType() == manejadorEventoTipo))
            {
                throw new ArgumentException($"El manejador {manejadorEventoTipo.Name} fue registrado anteriormente por {eventoNombre}");
            }

            _handlers[eventoNombre].Add(manejadorEventoTipo);

            var factory = new ConnectionFactory();
            factory.UserName = "guest";
            factory.Password = "guest";
            factory.VirtualHost = "/";
            factory.HostName = _configuration["RabbitMqBusHost"];
            factory.Port = AmqpTcpEndpoint.UseDefaultPort;

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.ExchangeDeclare(eventoNombre, ExchangeType.Fanout);

            var queueName = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queueName,
                              exchange: eventoNombre,
                              routingKey: "");

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventoNombre, true, consumer);

        }

        private void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var nombreEvento = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            try
            {
                if (_handlers.ContainsKey(nombreEvento))
                {


                    var subscriptions = _handlers[nombreEvento];
                    foreach (var sb in subscriptions)
                    {
                        using (var scope = _serviceScopeFactory.CreateScope())
                        {
                            var manejador = scope.ServiceProvider.GetService(sb);
                            if (manejador == null) continue;

                            var tipoEvento = _eventTypes.SingleOrDefault(x => x.Name == nombreEvento);
                            var eventoDS = JsonConvert.DeserializeObject(message, tipoEvento);

                            var concretoTipo = typeof(IEventHandler<>).MakeGenericType(tipoEvento);



                            var method = concretoTipo.GetMethod("Handle");

                            var task = Task.Run(async () => await (Task)method.Invoke(manejador, new object[] { eventoDS }));
                            
                            task.Wait();


                        }

                    }


                }



            }
            catch (Exception ex)
            {
                ;
            }


        }
    }

}
