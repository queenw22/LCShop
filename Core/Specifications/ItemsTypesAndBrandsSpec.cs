using System;
using System.Linq.Expressions;
using Core.EntitiesDb;

namespace Core.Specifications
{
    public class ItemsTypesAndBrandsSpec : BaseSpecification<Item>
    {
        public ItemsTypesAndBrandsSpec(ItemParams itemsParams) 
        : base(x =>  (string.IsNullOrEmpty(itemsParams.Search) || x.Name.ToLower().Contains(itemsParams.Search)
        && (!itemsParams.BrandId.HasValue || x.ItemBrandId == itemsParams.BrandId) 
        && (!itemsParams.TypeId.HasValue || x.ItemTypeId == itemsParams.TypeId)))
        {
            AddInclude(x => x.ItemType);
            AddInclude(x => x.ItemBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(itemsParams.PageSize * (itemsParams.PageIndex - 1), 
            itemsParams.PageSize);

            //sorting functionality 
            if (!string.IsNullOrEmpty(itemsParams.Sort))
            {
                switch (itemsParams.Sort)
                {
                    case "priceAsc":
                         AddOrderBy(p => p.Price);
                         break;
                    case "priceDesc":
                         AddOrderByDesc(p => p.Price);
                         break;
                    default:
                         AddOrderBy(n => n.Name);
                         break;
                }
            }

        }

        public ItemsTypesAndBrandsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ItemType);
            AddInclude(x => x.ItemBrand);
        }
    }
}