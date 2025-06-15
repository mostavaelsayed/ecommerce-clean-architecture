using ECommerce.Application.Services.Order.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceCleanArchitecture.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreateOrderController : ControllerBase
    {

        private readonly ILogger<CreateOrderController> _logger;
        private readonly ICreateOrderService createOrderService;

        public CreateOrderController(ILogger<CreateOrderController> logger,ICreateOrderService createOrderService)
        {
            _logger = logger;
            this.createOrderService = createOrderService;
        }

        [HttpPost]
        public async Task<bool> CreateOrder([FromBody]string orderName)
        {
            var result = await createOrderService.CreateOrderAsync(orderName);
            return result;
        }
    }
}
