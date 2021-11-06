using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ItemEntrega : Entity<Guid>
    {
        public Item Item { get; set; }
        public Guid ItemId { get; set; }

        public OrdenEntrega OrdenEntrega { get; set; }
        public Guid OrdenEntregaId { get; set; }

        public int Cantidad { get; set; }

        public bool Entregado { get; set; }

        public ItemEntrega(Item item, OrdenEntrega ordenEntrega, int cantidad)
        {
            Item = item;
            ItemId = item.Id;
            OrdenEntrega = ordenEntrega;
            OrdenEntregaId = ordenEntrega.Id;
            Cantidad = cantidad;
            Entregado = false;
        }

        protected ItemEntrega()
        {

        }

        public void MarcarComoEntregado()
        {
            Entregado = true;
        }


    }
}
