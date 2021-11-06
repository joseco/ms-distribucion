using Application.Dto.Item;
using Application.Features.Item.AddItem;
using Application.Features.Item.GetItems;
using Domain.Model;
using Domain.Persistence;
using Domain.Persistence.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(AddItemCommand addCommand)
        {
            await _mediator.Send(addCommand);
            
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            ICollection<ItemDto> items = await _mediator.Send(new GetItemsQuery());

            return Ok(items);
        }
    }
}
