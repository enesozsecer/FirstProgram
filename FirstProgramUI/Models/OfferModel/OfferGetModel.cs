namespace FirstProgramUI.Models.OfferModel
{
    public class OfferGetModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public short? OfferAmount { get; set; }
        public decimal? OfferPrice { get; set; }
        public string ProductName { get; set; }
        public Guid? ProductID { get; set; }
        public decimal? ProductPrice { get; set; }
    }
}
