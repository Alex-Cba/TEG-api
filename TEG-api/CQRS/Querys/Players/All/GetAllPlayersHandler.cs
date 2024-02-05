using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Common.Models;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Players.All
{
    public class ListPlayers
    {
        public List<PlayerDTO>? lstPlayers { get; set; }
    }
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, ListPlayers>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllPlayersHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ListPlayers> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            ListPlayers listPlayer = new ListPlayers();

            var playerDB = await _crudService.GetAsync<Player>();

            listPlayer.lstPlayers = _mapper.Map<List<PlayerDTO>>(playerDB);

            return listPlayer;
        }
    }
}
