using CoreDDD.Event;
using Domain.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventHandler
{
    public class AddItemEventHandler : IEventHandler<ArticuloCreated>
    {
        private readonly ILogger<AddItemEventHandler> _logger;

        public AddItemEventHandler(ILogger<AddItemEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ArticuloCreated @event)
        {
           _logger.LogInformation("Creado " + @event.Nombre);
            return null;
        }
    }
}
