using Core.EntitiesDb;

namespace Core.Specifications
{
    public class ItemFiltersForCountSpec : BaseSpecification<Item>
    {
        public ItemFiltersForCountSpec(ItemParams itemParams) 
           : base(x => (string.IsNullOrEmpty(itemParams.Search) || x.Name.ToLower().Contains(itemParams.Search) &&
           (!itemParams.BrandId.HasValue || x.ItemBrandId == itemParams.BrandId) &&
             (!itemParams.TypeId.HasValue || x.ItemTypeId == itemParams.TypeId) ))
        {
        }
    }
}