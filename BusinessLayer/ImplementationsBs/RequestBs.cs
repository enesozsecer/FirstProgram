using AutoMapper;
using BusinessLayer.InterfacesBs;
using DataAccessLayer.Interfaces;
using Model.Dtos.RequestDto;
using Model.Dtos.StatusDto;
using Model.Entities;

namespace BusinessLayer.ImplementationsBs
{
    public class RequestBs : IRequestBs
    {
        private readonly IRequestRepository _repo;
        private readonly IMapper _mapper;
        public RequestBs(IRequestRepository repo, IMapper mapper)
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

        public async Task<List<RequestGetDto>> GetCategoryIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetCategoryIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<RequestGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<RequestGetDto>> GetDescriptionAsync(string description, params string[] IncludeList)
        {
            var val = await _repo.GetDescriptionAsync(description, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<RequestGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<RequestGetDto>> GetRequestsAsync(params string[] IncludeList)
        {
            var val = await _repo.GetAllAsync(includeList: IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<RequestGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }
        public async Task<List<RequestGetDto>> GetUserDepIdAsync(Guid depId, params string[] IncludeList)
        {
            var val = await _repo.GetUserDepIdAsync(depId, IncludeList);
            if (val!=null)
            {
                var valList = _mapper.Map<List<RequestGetDto>>(val);

                return valList;
            }

            throw new NotImplementedException();
        }

        public async Task<List<RequestGetDto>> GetStatusIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetStatusIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<RequestGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<List<RequestGetDto>> GetUserIdAsync(Guid Id, params string[] IncludeList)
        {
            var val = await _repo.GetUserIdAsync(Id, IncludeList);
            if (val.Count > 0)
            {
                var valList = _mapper.Map<List<RequestGetDto>>(val);
                return valList;
            }
            throw new NotImplementedException();
        }

        public async Task<Request> InsertAsync(RequestPostDto dto)
        {
            dto.StatusID = Guid.Parse("34f0086e-304e-4eb4-99a1-1c54343a9d7c");
            var val = _mapper.Map<Request>(dto);
            var insertedVal = await _repo.InsertAsync(val);
            return insertedVal;
        }

        public async Task<Request> UpdateAsync(RequestPutDto dto)
        {
            var val = _mapper.Map<Request>(dto);
            var updatedVal = await _repo.UpdateAsync(val);
            return updatedVal;
        }
    }
}
