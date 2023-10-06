using Model.Dtos.RequestDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IRequestBs
    {
        Task<RequestGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Request>> GetDescriptionAsync(string description, params string[] IncludeList);
        Task<List<Request>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Request>> GetUserIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Request>> GetStatusIdAsync(Guid Id, params string[] IncludeList);
        Task<Request> InsertAsync(Request entity);
        Task<Request> UpdateAsync(Request entity);
        Task DeleteAsync(Guid id);
    }
}
