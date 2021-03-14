namespace API.Dtos
{
    public class ItemToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public string ItemType { get; set; }
        public string ItemBrand { get; set; }
    }
}