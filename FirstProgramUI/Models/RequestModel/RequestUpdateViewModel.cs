namespace FirstProgramUI.Models.RequestModel
{
    public class RequestUpdateViewModel
    {
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public int? DesiredQuantity { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? UserID { get; set; }
        public Guid? StatusID { get; set; }
    }
}
