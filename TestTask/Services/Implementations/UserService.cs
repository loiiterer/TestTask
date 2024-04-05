using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext db;

    public UserService(ApplicationDbContext db)
    {
        this.db = db;
    }

    public Task<User> GetUser()
    {
        var userWithMaxOrders = db.Users.OrderByDescending(u => u.Orders.Count).FirstOrDefault()!;
        return Task.FromResult(userWithMaxOrders);
    }

    public Task<List<User>> GetUsers()
    {
        var usersWithInactiveStatus = db.Users.Where(u => u.Status == Enums.UserStatus.Inactive);
        return Task.FromResult(usersWithInactiveStatus.ToList());
    }
}
