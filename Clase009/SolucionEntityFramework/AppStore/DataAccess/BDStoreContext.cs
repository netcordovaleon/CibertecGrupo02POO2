using AppStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppStore.DataAccess
{
    public class BDStoreContext : DbContext
    {
        public BDStoreContext(DbContextOptions<BDStoreContext> option) : base(option)
        {
            //El contenido que esta aqui se va ejecutar
        }

        public DbSet<ProductEntity> Products { get; set; }
    }

}
