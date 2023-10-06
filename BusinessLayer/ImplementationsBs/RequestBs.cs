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
        public async Task DeleteAsync(Guid id)
        {
            var request = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(request);
        }

        public async Task<RequestGetDto> GetByIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetByIdAsync(Id, IncludeList);
            if (val != null)
            {
                var dto = _mapper.Map<RequestGetDto>(val);
                return dto;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetCategoryIdAsync(Id, IncludeList);
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

        public async Task<List<Request>> GetStatusIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetStatusIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Request>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Request>> GetUserIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetUserIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<Request>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Request> InsertAsync(Request dto)
        {
            var request = _mapper.Map<Request>(dto);
            var insertedRequest = await _repo.InsertAsync(request);
            return insertedRequest;
        }

        public async Task<Request> UpdateAsync(Request dto)
        {
            var request = _mapper.Map<Request>(dto);
            var updatedRequest = await _repo.UpdateAsync(request);
            return updatedRequest;
        }
    }
}
