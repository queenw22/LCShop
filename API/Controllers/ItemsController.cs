using System.Threading.Tasks;
using Infrastructure.Data;
using Core.EntitiesDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using System.Collections.Generic;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository _repository;
        public ItemsController(IItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Item>> GetItemsAsync()
        {
            var items = await _repository.GetItemsAsync();
            return Ok(items);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Item>> GetItemByIdAsync(int id)
        {
            return await _repository.GetItemByIdAsync(id);
        }


        
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ItemBrand>>> GetItemBrandsAsync()
        {
            return Ok(await _repository.GetItemBrandsAsync());
            
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ItemType>>> GetItemTypesAsync()
        {
            return Ok(await _repository.GetItemTypesAsync());
            
        }

    }
}