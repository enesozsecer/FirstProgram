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
            var request = await _repo.FindByIdAsync(id);
            await _repo.DeleteAsync(request);
        }

        public async Task<RequestGetDto> FindByIdAsync(int requestId, params string[] IncludeList)
        {
            var request = await _repo.FindByIdAsync(requestId, IncludeList);
            if (request != null)
            {
                var dto = _mapper.Map<RequestGetDto>(request);
                return dto;
            }
            else { throw new NotImplementedException(); }
        }

        public async Task<List<RequestGetDto>> GetByProductId(int productId, params string[] IncludeList)
        {
            var request = await _repo.GetByProductId(productId, IncludeList);
            if (request.Count>0)
            {
                var requestList = _mapper.Map<List<RequestGetDto>>(request);
                return requestList;
            }
            else { throw new NotImplementedException(); }
        }

        public async Task<List<RequestGetDto>> GetByRequestType(string type, params string[] IncludeList)
        {
            var request = await _repo.GetByRequestType(type, IncludeList);
            if (request.Count > 0)
            {
                var requestList = _mapper.Map<List<RequestGetDto>>(request);
                return requestList;
            }
            else { throw new NotImplementedException(); }
            
        }

        public async Task<List<RequestGetDto>> GetByUserId(int userId, params string[] IncludeList)
        {
            var request = await _repo.GetByUserId(userId, IncludeList);
            if (request.Count > 0)
            {
                var requestList = _mapper.Map<List<RequestGetDto>>(request);
                return requestList;
            }
            else { throw new NotImplementedException(); }
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
