using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrdenEntrega.CancelarOrdenEntrega
{
    public class CancelarOrdenEntregaCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
