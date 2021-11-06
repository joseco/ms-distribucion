using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class ItemViaje : Entity<Guid>
    {
        public Item Item { get; set; }
        public Guid ItemId { get; set; }

        public Viaje Viaje { get; set; }
        public Guid ViajeId { get; set; }

        public int Cantidad { get; set; }

        public ItemViaje(Item item, Viaje viaje, int cantidad)
        {
            Item = item;
            ItemId = item.Id;
            Viaje = viaje;
            ViajeId = viaje.Id;
            Cantidad = cantidad;
        }

        protected ItemViaje()
        {

        }
    }
}
