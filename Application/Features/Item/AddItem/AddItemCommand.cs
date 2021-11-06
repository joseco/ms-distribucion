using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.AddItem
{
    public class AddItemCommand : IRequest<VoidResult>
    {
        public AddItemCommand(Guid id, string codigo, string descripcion)
        {
            Id = id;
            Codigo = codigo;
            Descripcion = descripcion;
        }

        public Guid Id { get; private set; }
        public string Codigo { get; private set; }
        public string Descripcion { get; private set; }



    }
}
