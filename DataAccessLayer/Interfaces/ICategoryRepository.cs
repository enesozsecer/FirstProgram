﻿using Core.DataAccessLayer.InterfacesDal;
using Model.Entities;

namespace DataAccessLayer.Interfaces
{
    public interface ICategoryRepository:BaseRepository<Category>
    {
        Task<Category> GetByIdAsync(Guid Id, params string[] IncludeList);
        Task<List<Category>> GetNameAsync(string name, params string[] IncludeList);
    }
}
