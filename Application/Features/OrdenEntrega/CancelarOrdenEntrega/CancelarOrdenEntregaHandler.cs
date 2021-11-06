using Domain.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrdenEntrega.CancelarOrdenEntrega
{
    public class CancelarOrdenEntregaHandler : IRequestHandler<CancelarOrdenEntregaCommand>
    {
        private readonly IOrdenEntregaRepository _repository;

        public CancelarOrdenEntregaHandler(IOrdenEntregaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CancelarOrdenEntregaCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.OrdenEntrega objOrdenEntrega = await _repository.GetById(request.Id);

            objOrdenEntrega.AnularEntrega();

            _repository.Update(objOrdenEntrega);

            return Unit.Value;
        }
    }
}
