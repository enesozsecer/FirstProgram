using Model.Entities;

namespace FirstProgramUI.Models.InvoiceModel
{
    public class InvoiceGetModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public short? OrderAmount { get; set; }
        public decimal? OrderPrice { get; set; }

        public List<Invoice> Invoice { get; set; }
        public Guid? SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public List<Supplier>? Supplier { get; set; }
    }
}
