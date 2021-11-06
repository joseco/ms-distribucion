using Application.Dto.Item;
using AutoMapper;
using Domain.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Item.GetItems
{
    public class GetItemsHandler : IRequestHandler<GetItemsQuery, ICollection<ItemDto>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            ICollection<Domain.Model.Item> items = await _itemRepository.GetItems();

            ICollection<ItemDto> list = _mapper.Map<ICollection<Domain.Model.Item>, ICollection<ItemDto>>(items);

            return list;
        }
    }
}
