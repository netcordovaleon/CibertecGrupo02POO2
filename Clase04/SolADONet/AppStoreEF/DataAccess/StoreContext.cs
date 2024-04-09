using AppStoreEF.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppStoreEF.DataAccess
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> option) : base(option)
        {
        }

        public DbSet<ProductEntity> Product { get; set; }
    }
}
