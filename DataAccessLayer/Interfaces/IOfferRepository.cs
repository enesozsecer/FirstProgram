using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IOfferRepository : BaseRepository<Offer>
    {
        Task<Offer> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Offer>> GetNameAsync(string name, params string[] IncludeList);
        Task<List<Offer>> GetAsyncByProduct(Guid Id, params string[] IncludeList);
        Task<List<Offer>> GetAsyncByStatus(Guid Id, params string[] IncludeList);
    }
}
