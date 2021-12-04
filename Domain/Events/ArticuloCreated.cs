using CoreDDD.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Events
{
    public class ArticuloCreated : Event
    {
        public ArticuloCreated(Guid articuloId, string nombre, string codigo)
        {
            ArticuloId = articuloId;
            Nombre = nombre;
            Codigo = codigo;
        }

        protected ArticuloCreated() { }

        public Guid ArticuloId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

    }
}
