using MyBookify.Domain.Users;
using StackExchange.Redis;

namespace MyBookify.Infrastructure.Repositories;
internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public override void Add(User user)
    {
        DbContext.Add(user);
    }
}

