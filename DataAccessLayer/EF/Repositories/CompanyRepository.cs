﻿using Core.DataAccessLayer.ImplementationsDal;
using DataAccessLayer.EF.Context;
using DataAccessLayer.Interfaces;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EF.Repositories
{
    public class CompanyRepository : BaseRepository<Company, FirstProgramContext>, ICompanyRepository
    {
        public async Task<Company> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            return await GetAsync(val => val.ID == Id, IncludeList);
        }

        public async Task<List<Company>> GetNameAsync(string name, params string[] IncludeList)
        {
            return await GetAllAsync(val => val.Name.Contains(name), IncludeList);
        }
    }
}
