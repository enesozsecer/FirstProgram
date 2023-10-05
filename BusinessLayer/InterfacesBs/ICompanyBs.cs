using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.InterfacesBs
{
    public interface ICompanyBs
    {
        Task<Company> GetByIdAsync(int Id, params string[] IncludeList);
        Task<List<Company>> GetNameAsync(string name, params string[] IncludeList);
    }
}
