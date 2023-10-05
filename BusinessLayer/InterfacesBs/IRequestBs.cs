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
        Task<Request> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<Request>> GetDescriptionAsync(string description, params string[] IncludeList);
        Task<List<Request>> GetCategoryNameAsync(string categoryName, params string[] IncludeList);
        Task<List<Request>> GetUserNameAsync(string userName, params string[] IncludeList);
        Task<List<Request>> GetStatusNameAsync(string statusName, params string[] IncludeList);
        Task<Request> InsertAsync(RequestGetDto entity);
        Task<Request> UpdateAsync(RequestGetDto entity);
        Task DeleteAsync(int id);
    }
}
