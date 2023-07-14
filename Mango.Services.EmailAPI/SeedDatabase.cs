using Mango.Services.EmailAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.EmailAPI
{
    public static class SeedDatabase
    {
        public static void ApplyMigration(WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (db.Database.GetPendingMigrations().Any())
            {
                db.Database.Migrate();
            }
        }
    }
}