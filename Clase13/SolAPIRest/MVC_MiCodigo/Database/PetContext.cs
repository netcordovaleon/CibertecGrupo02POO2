using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace APIRest.Database
{
    /*
      dotnet ef migrations add DatabaseCreationScript --startup-project ./APIRest/APIRest.csproj --project ./APIRest/APIRest.csproj --context PetContext

      dotnet ef database update --startup-project ./APIRest/APIRest.csproj --project ./APIRest/APIRest.csproj --context PetContext


     */
    public class PetContext : DbContext
    {
        public DbSet<PetEntity> Pet { get; set; }
        public PetContext(DbContextOptions<PetContext> option) : base(option)
        {
        }
    }
}
