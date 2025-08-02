using Eventhub.WebApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eventhub.WebApp.Data
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public DbSet<Event>? Events { get; set; }
     
    }
}
