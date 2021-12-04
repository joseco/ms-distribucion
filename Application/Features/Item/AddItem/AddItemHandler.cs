using CoreDDD.Event;
using Domain.Events;
using Domain.Persistence;
using Domain.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Item.AddItem
{
    public class AddItemHandler : IRequestHandler<AddItemCommand, VoidResult>, IEventHandler<ArticuloCreated>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddItemHandler(IItemRepository itemRepository, IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<VoidResult> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            Domain.Model.Item item = new Domain.Model.Item(request.Id,
                request.Codigo,
                request.Descripcion);

            await _itemRepository.Insert(item);
            await _unitOfWork.Commit(cancellationToken);
            return new VoidResult();
        }

        public async Task Handle(ArticuloCreated @event)
        {
            try
            {
                Domain.Model.Item item = new Domain.Model.Item(@event.ArticuloId,
                   string.IsNullOrEmpty(@event.Codigo) ? @event.Nombre : @event.Codigo,
                    @event.Nombre);

                await _itemRepository.Insert(item);
                await _unitOfWork.Commit();

            }
            catch (Exception ex)
            {
               
            }
        }

        private async Task Save(Domain.Model.Item item)
        {
        }
    }
}
