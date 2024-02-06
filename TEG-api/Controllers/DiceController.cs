using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Querys.Dice.All;
using TEG_api.Services.Interface;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IDiceService _diceService;

        public DiceController(IMediator mediator, IDiceService diceService)
        {
            _mediator = mediator;
            _diceService = diceService;
        }


        //TEST
        [HttpPost("LogicDices")]
        public async Task<IActionResult> LogicDices()
        {
            var result =_diceService.ResolveDiceRoll(3, 3, new Common.DTOs.DiceDTO()
                                {
                                    Faces = 6,
                                },
                                "RED",
                                "BLUE");

            return Ok(result);
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllDicesQuery()));
        }
    }
}
