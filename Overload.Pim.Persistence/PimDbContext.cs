using Microsoft.EntityFrameworkCore;

namespace Overload.Pim.Persistence

{
    //EF Core will auto dispose context after done transactions
    public class PimDbContext : DbContext
    {
    }
}
