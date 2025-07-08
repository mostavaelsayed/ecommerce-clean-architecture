using ECommerce.Application.Commands.Order;
using ECommerce.Application.Services.Order.CreateOrder;
using ECommerce.Entities.Constants;
using ECommerceCleanArchitecture.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCleanArchitecture.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateOrderController : ControllerBase
    {

        private readonly ILogger<CreateOrderController> _logger;
        private readonly ICreateOrderApplicationService createOrderService;

        public CreateOrderController(ILogger<CreateOrderController> logger, ICreateOrderApplicationService createOrderService)
        {
            _logger = logger;
            this.createOrderService = createOrderService;
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(typeof(OkObjectResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(StatusCodeResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
        {
            try
            {
                _logger.LogInformation("start create order");
                var result = await createOrderService.CreateOrderAsync(new CreateOrderRequestDTO()
                {
                    UserId = request.UserId,
                    Items = request.Items.Select(o => new CreateOrderItemRequestDTO() { ProductId = o.ProductId, Quantity = o.Quantity }).ToList(),
                    PaymentMethod = (PaymentMethodEnum)request.PaymentMethodId
                });
                if (result.Success)
                {
                    return Ok(result.Data);
                }
                else
                {
                    _logger.LogError("bad request while create order");
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("something went wrong while create order", e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
    }
}
