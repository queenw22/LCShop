using System.Collections.Generic;
using System.Threading.Tasks;
using Core.EntitiesDb;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly ShopContext _context;
        public ItemRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            return await _context.Items
            .Include(i => i.ItemType)
            .Include(i => i.ItemBrand)
            .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IReadOnlyList<Item>> GetItemsAsync()
        {
            return await _context.Items
            .Include(i => i.ItemType)
            .Include(i => i.ItemBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ItemType>> GetItemTypesAsync()
        {
            return await _context.ItemTypes.ToListAsync();


        }

        public async Task<IReadOnlyList<ItemBrand>> GetItemBrandsAsync()
        {
            return await _context.ItemBrands.ToListAsync();

        }
    }
}