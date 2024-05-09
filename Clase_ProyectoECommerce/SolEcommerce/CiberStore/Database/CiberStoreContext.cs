using CiberStore.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CiberStore.Database
{

    /*
    dotnet ef migrations add DatabaseCreationScript --startup-project ./CiberStore/CiberStore.csproj --project ./CiberStore/CiberStore.csproj --context CiberStoreContext
    dotnet ef database update  --startup-project ./CiberStore/CiberStore.csproj --project ./CiberStore/CiberStore.csproj --context CiberStoreContext
    */
    public class CiberStoreContext : DbContext
    {

        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<OrderEntity> Order { get; set; }
        public DbSet<OrderDetailEntity> OrderDetail { get; set; }

        public CiberStoreContext(DbContextOptions<CiberStoreContext> option) : base(option)
        {
            
        }

    }
}
