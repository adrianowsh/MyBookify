using MyBookify.Domain.Apartments;

namespace MyBookify.Infrastructure.Repositories;
internal sealed class ApartmentRepository : Repository<Apartment>, IApartmentRepository
{
    public ApartmentRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }
}

