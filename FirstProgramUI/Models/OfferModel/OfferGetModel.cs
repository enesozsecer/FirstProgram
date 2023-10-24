using Model.Dtos.InvoiceDto;
using Model.Dtos.ProductDto;
using Model.Dtos.StatusDto;
using Model.Dtos.SupplierDto;
using Model.Entities;

namespace FirstProgramUI.Models.OfferModel
{
    public class OfferGetModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public short? OfferAmount { get; set; }
        public decimal? OfferPrice { get; set; }


        public Guid? ProductID { get; set; }
        public string ProductName { get; set; }
        public List<ProductGetDto>? Product { get; set; }
        public Guid? StatusID { get; set; }
        public string StatusName { get; set; }
        public List<StatusGetDto>? Status { get; set; }
        public Guid? InvoiceID { get; set; }
        public string InvoiceName { get; set; }
        public List<InvoiceGetDto>? Invoice { get; set; }
        public Guid? SupplierID { get; set; }
        public string SupplierName { get; set; }
        public List<SupplierGetDto>? Supplier { get; set; }


    }
}
