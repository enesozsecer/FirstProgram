using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Repositories
{
    public class OfferRepository : BaseRepository<Offer, FirstProgramContext>, IOfferRepository
    {
        public async Task<Offer> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);

        }

        public async Task<List<Offer>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }
        public async Task<List<Offer>> GetAsyncByProduct(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.ProductID == Id, IncludeList);
        }

        public async Task<List<Offer>> GetAsyncByStatus(Guid Id, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.StatusID == Id, IncludeList);
        }
    }
}
