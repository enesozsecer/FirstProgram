using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICompanyRepository: BaseRepository<Company>
    {
        Task<Company> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Company>> GetNameAsync(string name, params string[] IncludeList);
    }
}
