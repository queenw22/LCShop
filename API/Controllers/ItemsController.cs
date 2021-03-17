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
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
   
    public class ItemsController : BaseApiController
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]


        public async Task<ActionResult<ItemToReturnDto>> GetItemByIdAsync(int id)
        {
            var spec = new ItemsTypesAndBrandsSpec(id);

            var item = await _itemsRepo.GetEntityWithSpec(spec);

            if (item == null)
            {
                return NotFound(new ApiResponse(404));
            }

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