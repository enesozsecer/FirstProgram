using Model.Dtos.StatusDto;
using Model.Dtos.UserDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface IStatusBs
    {
        Task<List<StatusGetDto>> GetStatusAsync(params string[] IncludeList);
        Task<StatusGetDto> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<StatusGetDto>> GetNameAsync(string name, params string[] IncludeList);
        Task<Status> InsertAsync(StatusPostDto entity);
        Task<Status> UpdateAsync(StatusPutDto entity);
        Task DeleteAsync(Guid id);
    }
}
