using AutoMapper;
using MediatR;
using TEG_api.Common.DTOs;
using TEG_api.Services.Interface;

namespace TEG_api.CQRS.Querys.Dice.All
{
    public class ListDices
    {
        public List<DiceDTO> lstDices { get; set; }
    }
    public class GetAllDicesHandler : IRequestHandler<GetAllDicesQuery, ListDices>
    {
        private readonly ICRUDService _crudService;
        private readonly IMapper _mapper;

        public GetAllDicesHandler(ICRUDService crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public async Task<ListDices> Handle(GetAllDicesQuery request, CancellationToken cancellationToken)
        {
            ListDices listDices = new ListDices();

            var DiceDB = await _crudService.GetAsync<Common.Models.Dice>();

            listDices.lstDices = _mapper.Map<List<DiceDTO>>(DiceDB);

            return listDices;
        }
    }
}
