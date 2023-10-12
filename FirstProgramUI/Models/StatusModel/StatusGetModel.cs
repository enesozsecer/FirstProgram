using Model.Entities;

namespace FirstProgramUI.Models.StatusModel
{
    public class StatusGetModel
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public List<Status> Status{ get; set; }
        public List<Request> Request { get; set; }
    }
}
