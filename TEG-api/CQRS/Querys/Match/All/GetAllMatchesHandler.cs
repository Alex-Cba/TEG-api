using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Match.All
{
    public class ListMatches
    {
        public List<MatchDTO>? lstMatches { get; set; }
    }
    public class GetAllMatchesHandler : IRequestHandler<GetAllMatchesQuery, ListMatches>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllMatchesHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }
        public async Task<ListMatches> Handle(GetAllMatchesQuery request, CancellationToken cancellationToken)
        {
            ListMatches listMatches = new ListMatches();

            var MatchDB = await _crudService.GetAsync<Common.Models.Match>();

            listMatches.lstMatches = _mapper.Map<List<MatchDTO>>(MatchDB);

            return listMatches;
        }
    }
}
