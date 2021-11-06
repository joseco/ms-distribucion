using Application.Dto.Item;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Item.GetItems
{
    public class GetItemsQuery : IRequest<ICollection<ItemDto>>
    {

    }
}
