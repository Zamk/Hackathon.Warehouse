using Hackathon.Warehouse.Api.ApiExtensions;
using Hackathon.Warehouse.Api.Contracts.Warehouse;
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

        [HttpPost]
        [Route("get")]
        public async Task<ActionResult<WarehouseResponse>> GetId([FromBody] GetWarehouseRequest request)
        {
            var result = await _warehouseService.GetById(request.Id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.ToResponse());
        }

        [HttpPost]
        [Route("storage")]
        public async Task<ActionResult<WarehouseStorageResponse>> GetStorage([FromBody] GetWarehouseRequest request)
        {
            var result = await _warehouseService.GetStorage(request.Id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.ToResponse());
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<WarehouseResponse>> Create([FromBody] CreateWarehouseRequest request)
        {
            var result = await _warehouseService.Create(request.Name);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.ToResponse());
        }

        [HttpPost]
        [Route("zone/add")]
        public async Task<ActionResult> AddZone([FromBody] AddZoneRequest request)
        {
            var result = await _warehouseService.CreateZone(
                request.WarehouseId,
                request.Name,
                request.NumberOfRows,
                request.NumberOfSections,
                request.NumberOfTires,
                request.MaxWidth,
                request.MaxHeight,
                request.MaxDepth
                );

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.ToResponse());
        }

        [HttpPost]
        [Route("zone/remove")]
        public async Task<ActionResult> RemoveZone([FromBody] RemoveZoneRequest request)
        {
            var result = await _warehouseService.RemoveZone(
                request.WarehouseId,
                request.ZoneId
                );

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.ToResponse());
        }
    }
}
