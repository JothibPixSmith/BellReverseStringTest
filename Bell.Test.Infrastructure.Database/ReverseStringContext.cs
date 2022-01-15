using Microsoft.EntityFrameworkCore;

namespace Bell.Test.Infrastructure.Database
{
    public class ReverseStringContext : DbContext
    {
        public ReverseStringContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ReverseString.Domain.ReverseString> ReversedStrings { get; set; }
    }
}
