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
        Task<List<RequestGetDto>> GetByRequestType(string type, params string[] IncludeList);
        Task<RequestGetDto> FindByIdAsync(int requestId, params string[] IncludeList);
        Task<List<RequestGetDto>> GetByUserId(int userId, params string[] IncludeList);
        Task<List<RequestGetDto>> GetByProductId(int productId, params string[] IncludeList);
        Task<Request> InsertAsync(RequestGetDto entity);
        Task<Request> UpdateAsync(RequestGetDto entity);
        Task DeleteAsync(int id);
    }
}
