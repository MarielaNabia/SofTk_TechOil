using Microsoft.EntityFrameworkCore;

namespace SofTk_TechOil.DataAccess.DBSeeding
{
    public interface IEntitySeeder
    {
        void SeedDatabase(ModelBuilder modelBuilder);
    }
}
