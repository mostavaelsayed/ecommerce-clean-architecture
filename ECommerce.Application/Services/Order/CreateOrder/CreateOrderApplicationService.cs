
using ECommerce.Application.Commands.Order;
using ECommerce.Application.Repositories.Read;
using ECommerce.Application.Repositories.Write;
using ECommerce.Entities.Services.OrderService;
using ECommerce.Application.Repositories;
using ECommerce.Application.Util;
using Microsoft.Extensions.Logging;

namespace ECommerce.Application.Services.Order.CreateOrder
{
    public class CreateOrderApplicationService : ICreateOrderApplicationService
    {
        private readonly IReadUserRepository readUserRepository;
        private readonly IReadProductRepository readProductRepository;
        private readonly IWriteOrderRepository writeOrderRepository;
        private readonly ICreateOrderService createOrderService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDateTimeService dateTimeService;
        private readonly ILogger<CreateOrderApplicationService> logger;

        public CreateOrderApplicationService(IReadUserRepository readUserRepository, IReadProductRepository readProductRepository,
            IWriteOrderRepository writeOrderRepository, ICreateOrderService createOrderService, IUnitOfWork unitOfWork, IDateTimeService dateTimeService,
        ILogger<CreateOrderApplicationService> logger
            )
        {
            this.readUserRepository = readUserRepository;
            this.readProductRepository = readProductRepository;
            this.writeOrderRepository = writeOrderRepository;
            this.createOrderService = createOrderService;
            this.unitOfWork = unitOfWork;
            this.dateTimeService = dateTimeService;
            this.logger = logger;
        }
        //add custom errors and validators
        public async Task<ApplicationResult> CreateOrderAsync(CreateOrderRequestDTO request)
        {
            logger.LogInformation("getting user for create order");
            var user = await readUserRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                logger.LogError("user not found while create order!");
                return ApplicationResult.FailureResult("User not found.");
            }
            logger.LogInformation($"getting product information");
            var products = await readProductRepository.GetAllByIdAsync([.. request.Items.Select(x => x.ProductId)]);
            List<CreateOrderItemDTO> orderItems = [];
            foreach (var item in request.Items)
            {
                orderItems.Add(new CreateOrderItemDTO()
                {
                    Quantity = item.Quantity,
                    Product = products.First(p => p.Id == item.ProductId)
                });
            }
            logger.LogInformation($"Create Order");
            var order = createOrderService.CreateOrder(user, orderItems, request.PaymentMethod, dateTimeService.Now());
            logger.LogInformation($"Add Order to context");
            await writeOrderRepository.AddAsync(order);
            logger.LogInformation($"Save Order Information!");
            await unitOfWork.SaveChangesAsync();
            logger.LogInformation($"Order Saved!");
            return ApplicationResult.SuccessResult(new CreateOrderResponseDTO
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                PaymentMethod = order.Payment.PaymentMethod.ToString(),
                Items = order.Items.Select(i => new OrderItemDto
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            });

        }
    }
}
