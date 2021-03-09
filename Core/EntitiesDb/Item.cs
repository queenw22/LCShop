namespace Core.EntitiesDb
{
    public class Item : BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ItemType ItemType { get; set; }
        public int ItemTypeId { get; set; }
        public ItemBrand ItemBrand { get; set; }
        public int ItemBrandId { get; set; }
    }
}