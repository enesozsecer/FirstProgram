namespace FirstProgramUI.Models.UserModel
{
    public class UserGetViewModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; }
        public string? AuthenticateName { get; set; }
        public string? DepartmentName { get; set; }
        public string? CompanyName { get; set; }
    }
}
