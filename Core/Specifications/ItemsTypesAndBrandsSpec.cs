using System;
using System.Linq.Expressions;
using Core.EntitiesDb;

namespace Core.Specifications
{
    public class ItemsTypesAndBrandsSpec : BaseSpecification<Item>
    {
        public ItemsTypesAndBrandsSpec()
        {
            AddInclude(x => x.ItemType);
            AddInclude(x => x.ItemBrand);

        }

        public ItemsTypesAndBrandsSpec(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ItemType);
            AddInclude(x => x.ItemBrand);
        }
    }
}