using System.Threading.Tasks;
using Infrastructure.Data;
using Core.EntitiesDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using System.Collections.Generic;
using Core.Specifications;
using System.Linq;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IGenericRepository<ItemBrand> _itemBrandRepo;
        private readonly IGenericRepository<ItemType> _itemTypeRepo;
        private readonly IGenericRepository<Item> _itemsRepo;
        private readonly IMapper _mapper;

        public ItemsController(IGenericRepository<ItemBrand> itemBrandRepo,
        IGenericRepository<ItemType> itemTypeRepo, IGenericRepository<Item> itemsRepo,
        IMapper mapper)
        {
            _mapper = mapper;
            _itemsRepo = itemsRepo;
            _itemTypeRepo = itemTypeRepo;
            _itemBrandRepo = itemBrandRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemToReturnDto>>> GetItemsAsync()
        {
            //return includes statement depending on which class is chosen
            var spec = new ItemsTypesAndBrandsSpec();
            var items = await _itemsRepo.ListAsync(spec);

            //convert readonly list from item to itemtoreturndtos
            return Ok(_mapper.Map<IReadOnlyList<Item>, IReadOnlyList<ItemToReturnDto>>(items));
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ItemToReturnDto>> GetItemByIdAsync(int id)
        {
            var spec = new ItemsTypesAndBrandsSpec(id);

            var item = await _itemsRepo.GetEntityWithSpec(spec);

            //map out product descrition data that displays to user 
            return _mapper.Map<Item, ItemToReturnDto>(item);
        }



        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ItemBrand>>> GetItemBrandsAsync()
        {
            return Ok(await _itemBrandRepo.ListAllAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ItemType>>> GetItemTypesAsync()
        {
            return Ok(await _itemTypeRepo.ListAllAsync());

        }

    }
}