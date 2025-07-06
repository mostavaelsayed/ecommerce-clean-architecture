
using ECommerce.Application.Commands.Order;
using ECommerce.Application.Repositories.Read;
using ECommerce.Application.Repositories.Write;
using ECommerce.Application.TransactionManager;
using ECommerce.Entities.Aggregates;

namespace ECommerce.Application.Services.Order.CreateOrder
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IReadUserRepository readUserRepository;
        private readonly IReadProductRepository readProductRepository;
        private readonly IWriteProductRepository writeProductRepository;
        private readonly IWriteOrderRepository writeOrderRepository;
        private readonly ITransactionCommand transaction;

        public CreateOrderService(IReadUserRepository readUserRepository, IReadProductRepository readProductRepository
            , IWriteProductRepository writeProductRepository, IWriteOrderRepository writeOrderRepository, ITransactionCommand transactionCommand)
        {
            this.readUserRepository = readUserRepository;
            this.readProductRepository = readProductRepository;
            this.writeProductRepository = writeProductRepository;
            this.writeOrderRepository = writeOrderRepository;
            this.transaction = transactionCommand;
        }
        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest request)
        {
            var user = await readUserRepository.GetByIdAsync(request.UserId)
               ?? throw new Exception("User not found.");

            if (!user.IsActive)
                throw new InvalidOperationException("User is not active.");

            var order = new OrderAggregate();
            order.SetUser(user.Id);
            await transaction.ExecuteAsync(async () =>
            {
                foreach (var item in request.Items)
                {
                    var product = await readProductRepository.GetByIdAsync(item.ProductId)
                                  ?? throw new Exception($"Product {item.ProductId} not found.");

                    product.ReduceQuantity(item.Quantity);
                    order.AddItem(product.Id, product.Name, item.Quantity, product.Price);
                    await writeProductRepository.UpdateAsync(product);
                }

                order.CalculateTotal();
                order.SetPayment(order.TotalAmount, request.PaymentMethod);

                var orderEntity = new Entities.Order
                {
                    UserId = order.UserId,
                    OrderDate = order.OrderDate,
                    Status = order.Status,
                    TotalAmount = order.TotalAmount,
                    PaymentId = order.Payment.Id
                };
                await writeOrderRepository.AddAsync(orderEntity);
            });

            return new CreateOrderResponse
            {
                OrderId = order.Id,
                OrderDate = order.OrderDate,
                TotalAmount = order.TotalAmount,
                PaymentMethod = order.Payment.PaymentMethod,
                Items = order.Items.Select(i => new OrderItemDto
                {
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

        }
    }
}
