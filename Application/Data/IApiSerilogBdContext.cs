using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Application.Data
{
    public interface IApiSerilogBdContext
    {
        DbSet<Product> Products { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
