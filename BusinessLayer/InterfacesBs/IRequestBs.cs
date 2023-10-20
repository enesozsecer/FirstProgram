using Model.Dtos.RequestDto;
using Model.Dtos.UserDto;
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
        Task<List<RequestGetDto>> GetRequestsAsync(params string[] IncludeList);
        Task<RequestGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<RequestGetDto>> GetDescriptionAsync(string description, params string[] IncludeList);
        Task<List<RequestGetDto>> GetCategoryIdAsync(Guid Id, params string[] IncludeList);
        Task<List<RequestGetDto>> GetUserIdAsync(Guid Id, params string[] IncludeList);
        Task<List<RequestGetDto>> GetStatusIdAsync(Guid Id, params string[] IncludeList);
        Task<Request> InsertAsync(RequestPostDto entity);
        Task<Request> UpdateAsync(RequestPutDto entity);
        Task DeleteAsync(Guid id);
        Task<List<RequestGetDto>> GetUserDepIdAsync(Guid depId, params string[] IncludeList);
    }
}
