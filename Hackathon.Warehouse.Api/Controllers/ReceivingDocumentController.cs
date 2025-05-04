using Hackathon.Warehouse.Api.ApiExtensions;
using Hackathon.Warehouse.Api.Contracts.Documents;
using Hackathon.Warehouse.Core.Abstractions.Services;
using Hackathon.Warehouse.Core.Models.Documents;
using Microsoft.AspNetCore.Mvc;

namespace Hackathon.Warehouse.Api.Controllers
{
    [ApiController]
    [Route("api/receivings")]
    public class ReceivingDocumentController : ControllerBase
    {
        private readonly IReceivingService _receivingService;

        public ReceivingDocumentController(
            IReceivingService receivingService
            ) 
        {
            _receivingService = receivingService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ReceivingDocumentResponse>> Create([FromBody] CreateReceivingDocumentRequest request)
        {
            var items = request.Items.Select(i => new ReceivingItem { ProductId = i.ProductId, ExpectedCount = i.ExpectedCount});

            var result = await _receivingService.CreateReceivingDocument(
                    request.WarehouseId,
                    request.SupplierName,
                    items.ToList()
                );

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.ToResponse());
        }

        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<IEnumerable<ReceivingDocumentResponse>>> GetAll()
        {
            var result = await _receivingService.GetReceivingDocuments();

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.Select(d => d.ToResponse()));
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<ActionResult<IEnumerable<ReceivingDocumentResponse>>> GetById([FromRoute] int id)
        {
            var result = await _receivingService.GetRecievingDocumentById(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Value.ToResponse());
        }
    }
}
