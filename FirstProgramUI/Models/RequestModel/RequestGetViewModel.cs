namespace FirstProgramUI.Models.RequestModel
{
    public class RequestGetViewModel
    {
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public int? DesiredQuantity { get; set; }
        public string? CategoryName { get; set; }
        public string? UserName { get; set; }
        public string? StatusName { get; set; }
    }
}
