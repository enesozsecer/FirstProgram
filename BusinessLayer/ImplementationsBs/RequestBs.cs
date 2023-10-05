using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.RequestDto;
using Model.Entities;

namespace BusinessLayer.ImplementationsBs
{
    public class RequestBs : IRequestBs
    {
        private readonly IRequestRepository _repo;
        private readonly IMapper _mapper;
        public RequestBs(IRequestRepository repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task DeleteAsync(int id)
        {
            var request = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(request);
        }

        public async Task<Request> GetByIdAsync(int Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<Request>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetCategoryNameAsync(string categoryName, params string[] IncludeList)
        {
            var val = await _repo.GetCategoryNameAsync(categoryName, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Request>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetDescriptionAsync(string description, params string[] IncludeList)
        {
            var val = await _repo.GetDescriptionAsync(description, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Request>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetStatusNameAsync(string statusName, params string[] IncludeList)
        {
            var val = await _repo.GetStatusNameAsync(statusName, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Request>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetUserNameAsync(string userName, params string[] IncludeList)
        {
            var val = await _repo.GetUserNameAsync(userName, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Request>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Request> InsertAsync(RequestGetDto dto)
        {
            var request = _mapper.Map<Request>(dto);
            var insertedRequest = await _repo.InsertAsync(request);
            return insertedRequest;
        }

        public async Task<Request> UpdateAsync(RequestGetDto dto)
        {
            var request = _mapper.Map<Request>(dto);
            var updatedRequest = await _repo.UpdateAsync(request);
            return updatedRequest;
        }
    }
}
