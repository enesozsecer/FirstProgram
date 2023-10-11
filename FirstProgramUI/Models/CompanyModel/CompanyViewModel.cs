using FirstProgramUI.Models.UserModel;

namespace FirstProgramUI.Models.CompanyModel
{
    public class CompanyViewModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public UserUpdateViewModel UserUpdateViewModel { get; set; }
    }
}
