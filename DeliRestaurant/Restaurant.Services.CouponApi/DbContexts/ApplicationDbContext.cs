using Microsoft.EntityFrameworkCore;

namespace Restaurant.Services.CouponApi.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
    
}
