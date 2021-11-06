using CoreDDD.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Item : AggregateRoot<Guid>
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public Item(Guid id, string codigo, string descripcion)
        {
            Id = id;
            Codigo = codigo;
            Descripcion = descripcion;
        }
    }
}
