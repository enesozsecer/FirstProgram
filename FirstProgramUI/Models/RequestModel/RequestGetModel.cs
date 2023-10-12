using Model.Entities;

namespace FirstProgramUI.Models.RequestModel
{
    public class RequestGetModel
    {
        public Guid ID { get; set; }
        public string? Description { get; set; }
        public int? DesiredQuantity { get; set; }
        public Guid? CategoryID { get; set; }
        public Guid? UserID { get; set; }
        public Guid? StatusID { get; set; }
        public string? CategoryName { get; set; }
        public string? UserName { get; set; }
        public string? StatusName { get; set; }
        public List<Request> Request { get; set; }
        public List<Category> Cateogry { get; set; }
        public List<Status> Status { get; set; }

    }
}
