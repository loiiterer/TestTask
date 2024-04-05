using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext db;

    public OrderService(ApplicationDbContext db)
    {
        this.db = db;
    }

    public Task<Order> GetOrder()
    {
        var orderWithLargestOrderPrice = db.Orders.OrderByDescending(o => o.Price).FirstOrDefault()!;
        return Task.FromResult(orderWithLargestOrderPrice);
    }

    public Task<List<Order>> GetOrders()
    {
        var ordersInWhichTheQuantityOfGoodsIsMoreThanTen = db.Orders.Where(o => o.Quantity > 10);
        return Task.FromResult(ordersInWhichTheQuantityOfGoodsIsMoreThanTen.ToList());
    }
}
