using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.Common.Request;
using TEG_api.CQRS.Commands.Continent.Create;
using TEG_api.CQRS.Commands.Continent.Delete;
using TEG_api.CQRS.Commands.Continent.SoftDelete;
using TEG_api.CQRS.Commands.Continent.Update;
using TEG_api.CQRS.Commands.Country.Create;
using TEG_api.CQRS.Commands.Country.Delete;
using TEG_api.CQRS.Commands.Country.Update;
using TEG_api.CQRS.Commands.Map.Create;
using TEG_api.CQRS.Commands.Map.Delete;
using TEG_api.CQRS.Commands.Map.SoftDelete;
using TEG_api.CQRS.Commands.Map.Update;
using TEG_api.CQRS.Querys.Continents.All;
using TEG_api.CQRS.Querys.Continents.ById;
using TEG_api.CQRS.Querys.Countrys.All;
using TEG_api.CQRS.Querys.Countrys.ById;
using TEG_api.CQRS.Querys.Maps.All;
using TEG_api.CQRS.Querys.Maps.ById;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/World")]
    public class MapController : Controller
    {
        private readonly IMediator _mediator;

        public MapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Map

        /// <summary>
        /// Esto es una prubea de documentación
        /// </summary>
        /// <param name="a">El primer número.</param>
        /// <param name="b">El segundo número.</param>
        /// <returns>La suma de los dos números.</returns>
        [HttpGet("Map/GetAll")]
        public async Task<IActionResult> GetAllMaps()
        {
            return Ok(await _mediator.Send(new GetAllMapsQuery()));
        }

        /// <summary>
        /// Esdaaaaaaaaaaaaaaaaaaaaaaa
        /// </summary>
        /// <param name="a">El primer númedsadasdro.</param>
        /// <param name="b">El segundo adas.</param>
        /// <response code="200">Returns the ID of the successfully created show.</response>
        /// <response code="400">If the provided data is invalid.</response>
        /// <response code="401">If the user is not authenticated.</response>
        /// <response code="403">If the user lacks the required permissions.</response>
        [HttpGet("Map/GetById/{Id}")]
        public async Task<IActionResult> GetMapById([FromRoute] string Id)
        {
            return Ok(await _mediator.Send(new GetByIdMapsQuery(Id)));
        }

        [HttpPost("Map/Create")]
        public async Task<IActionResult> CreateMap([FromBody] CreateMapRequest request)
        {
            var response = await _mediator.Send(new CreateMapCommand(request));

            return Ok(response);
        }

        [HttpPut("Map/Update")]
        public async Task<IActionResult> UpdateMap([FromBody] UpdateMapRequest request)
        {
            var response = await _mediator.Send(new UpdateMapCommand(request));

            return Ok(response);
        }

        [HttpDelete("Map/Delete")]
        public async Task<IActionResult> DeleteMap([FromQuery] int Id)
        {
            var response = await _mediator.Send(new DeleteMapCommand(Id));

            return Ok(response);
        }

        [HttpDelete("Map/SoftDelete")]
        public async Task<IActionResult> SoftDeleteMap([FromQuery] int Id)
        {
            var response = await _mediator.Send(new SoftDeleteMapCommand(Id));

            return Ok(response);
        }
        #endregion

        #region Continent
        [HttpGet("Continent/GetAll")]
        public async Task<IActionResult> GetAllContinent()
        {
            return Ok(await _mediator.Send(new GetAllContinentsQuery()));
        }

        [HttpGet("Continent/GetById/{Id}")]
        public async Task<IActionResult> GetContinentById([FromRoute] string Id)
        {
            return Ok(await _mediator.Send(new GetByIdContinentsQuery(Id)));
        }

        [HttpPost("Continent/Create")]
        public async Task<IActionResult> CreateContinent([FromBody] CreateContinentRequest request)
        {
            var response = await _mediator.Send(new CreateContinentCommand(request));

            return Ok(response);
        }

        [HttpPut("Continent/Update")]
        public async Task<IActionResult> UpdateContinent([FromBody] UpdateContinentRequest request)
        {
            var response = await _mediator.Send(new UpdateContinentCommand(request));

            return Ok(response);
        }

        [HttpDelete("Continent/Delete")]
        public async Task<IActionResult> DeleteContinent([FromQuery] int Id)
        {
            var response = await _mediator.Send(new DeleteContinentCommand(Id));

            return Ok(response);
        }

        [HttpDelete("Continent/SoftDelete")]
        public async Task<IActionResult> SoftDeleteContinent([FromQuery] int Id)
        {
            var response = await _mediator.Send(new SoftDeleteContinentCommand(Id));

            return Ok(response);
        }
        #endregion

        #region Country
        [HttpGet("Country/GetAll")]
        public async Task<IActionResult> GetAllCountry()
        {
            return Ok(await _mediator.Send(new GetAllCountrysQuery()));
        }

        [HttpGet("Country/GetById/{Id}")]
        public async Task<IActionResult> GetCountryById([FromRoute] string Id)
        {
            return Ok(await _mediator.Send(new GetByIdCountrysQuery(Id)));
        }

        [HttpPost("Country/Create")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryRequest request)
        {
            var response = await _mediator.Send(new CreateCountryCommand(request));

            return Ok(response);
        }

        [HttpPut("Country/Update")]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryRequest request)
        {
            var response = await _mediator.Send(new UpdateCountryCommand(request));

            return Ok(response);
        }

        [HttpDelete("Country/Delete")]
        public async Task<IActionResult> DeleteCountry([FromQuery] int Id)
        {
            var response = await _mediator.Send(new DeleteCountryCommand(Id));

            return Ok(response);
        }
        #endregion
    }
}
