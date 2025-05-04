using Hackathon.Warehouse.Api.ApiExtensions;
using Hackathon.Warehouse.Api.Contracts;
using Hackathon.Warehouse.Core.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Warehouse.Api.Controllers
{
    [ApiController]
    [Route("api/warehouse")]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(
            IWarehouseService warehouseService
            ) 
        {
            _warehouseService = warehouseService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<WarehouseResponse>> GetId([FromRoute] long id)
        {
            var clientResult = await _warehouseService.GetById(id);

            if (clientResult.IsFailure)
            {
                return BadRequest(clientResult.Error);
            }

            return Ok(clientResult.Value.ToResponse());
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<WarehouseResponse>> Create([FromBody] CreateWarehouseRequest request)
        {
            var categoryResult = await _warehouseService.Create(request.Name);

            if (categoryResult.IsFailure)
            {
                return BadRequest(categoryResult.Error);
            }

            return Ok(categoryResult.Value.ToResponse());
        }
    }
}
