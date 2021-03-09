using System.Collections.Generic;
using System.Threading.Tasks;
using Core.EntitiesDb;

namespace Core.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetItemByIdAsync(int id);

        Task<IReadOnlyList<Item>> GetItemsAsync();
        Task<IReadOnlyList<ItemBrand>> GetItemBrandsAsync(); 
        Task<IReadOnlyList<ItemType>> GetItemTypesAsync();   


    }
}