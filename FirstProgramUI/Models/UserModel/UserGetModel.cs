using Model.Entities;

namespace FirstProgramUI.Models.UserModel
{
    public class UserGetModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
        public Guid? RoleID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? CompanyID { get; set; }
        public string? RoleName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CompanyName { get; set; }
        public List<Department> Department { get; set; }
        public List<Role> Role { get; set; }
        public List<Company> Company { get; set; }
        public List<User> User { get; set; }
    }
}
