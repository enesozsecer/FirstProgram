using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Model.Dtos.CategoryDto;
using Model.Dtos.CompanyDto;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ImplementationsBs
{
    public class CategoryBs : ICategoryBs
    {
        private readonly ICategoryRepository _repo;
        private readonly IMapper _mapper;
        public CategoryBs(ICategoryRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(Guid id)
        {
            var val = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(val);
        }

        public async Task<CategoryGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<CategoryGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }
        public async Task<List<CategoryGetDto>> GetCategoriesAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<CategoryGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<List<CategoryGetDto>> GetNameAsync(string name, params string[] IncludeList)
        {
            var val = await _repo.GetNameAsync(name, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<CategoryGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Category> InsertAsync(CategoryPostDto entity)
        {
            var val = _mapper.Map<Category>(entity);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Category> UpdateAsync(CategoryPutDto entity)
        {
            var val = _mapper.Map<Category>(entity);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
