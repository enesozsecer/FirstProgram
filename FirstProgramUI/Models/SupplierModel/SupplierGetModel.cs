using Model.Entities;

namespace FirstProgramUI.Models.SupplierModel
{
    public class SupplierGetModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Category>? Category { get; set; }
        public List<Invoice>? Invoice { get; set; }
    }
}
