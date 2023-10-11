using FirstProgramUI.Models.CompanyModel;
using Model.Entities;

namespace FirstProgramUI.Models.UserModel
{
    public class UserUpdateViewModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public Guid? AuthenticateID { get; set; }
        public Guid? DepartmentID { get; set; }
        public Guid? CompanyID { get; set; }
        public List<CompanyViewModel>? CompanyViewModel { get; set; }

    }
}
