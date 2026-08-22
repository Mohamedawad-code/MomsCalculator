using Microsoft.AspNetCore.Mvc;
using MomsCalculator.service;
using MomsCalculator.DTO;
using MomsCalculator.Models;


namespace MomsCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost]
        public IActionResult CreateItem([FromBody] CreateItemRequest request)
        {
            
            Item result = _itemService.CreateItem(request.Price, request.Name);
            return Ok(result);

        }



    }
}
