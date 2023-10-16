using Model.Entities;

namespace FirstProgramUI.Models.DepartmentModel
{
    public class DepartmentGetModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public List<Company> Company { get; set; }
        public List<Department> Department { get; set; }
        public List<User> User { get; set; }
    }
}
