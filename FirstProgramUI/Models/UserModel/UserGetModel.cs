using Model.Entities;

namespace FirstProgramUI.Models.UserModel
{
    public class UserGetModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public Guid? AuthenticateID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? CompanyID { get; set; }
        public string? AuthenticateName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CompanyName { get; set; }
        public List<Department> Department { get; set; }
        public List<Authenticate> Authenticate { get; set; }
        public List<Company> Company { get; set; }
        public List<User> User { get; set; }
    }
}
