using FirstProgramUI.Models.CategoryModel;
using Model.Dtos.CategoryDto;
using Model.Entities;

namespace FirstProgramUI.Models.ProductModel
{
    public class ProductGetModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public short? StockQuantity { get; set; }
        public decimal? ProductPrice { get; set; }
        public Guid CategoryID { get; set; }
        public Guid OfferID { get; set; }
        public string CategoryName { get; set; }
        public string? OfferName { get; set; }
        public List<Category> Cateogry { get; set; }
        public List<Product> Product { get; set; }
        public List<Offer> Offer { get; set; }
    }
}
