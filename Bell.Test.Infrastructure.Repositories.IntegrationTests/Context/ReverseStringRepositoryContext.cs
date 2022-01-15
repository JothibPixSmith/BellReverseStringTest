using Bell.Test.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Bell.Test.Infrastructure.Repositories.IntegrationTests.Context
{
    public class ReverseStringRepositoryContext
    {
        protected async Task GivenSQLLiteTestDB()
        {
            this.DbContext = new ReverseStringContext(new DbContextOptionsBuilder<ReverseStringContext>()
                .UseSqlite("Filename=testDb.db")
                .Options);

            await this.DbContext.ReversedStrings.AddRangeAsync(new[]
            {
                new ReverseString.Domain.ReverseString
                {
                    Value = "test1234dddddddddddddddddddddd"
                },
                 new ReverseString.Domain.ReverseString
                {
                    Value = "test1235sdafsdd"
                },
                  new ReverseString.Domain.ReverseString
                {
                    Value = "test1236ffff"
                },
                   new ReverseString.Domain.ReverseString
                {
                    Value = "test1237"
                },
                    new ReverseString.Domain.ReverseString
                {
                    Value = "test1238dssdfvsd"
                },
            });

            await this.DbContext.SaveChangesAsync();
        }

        public ReverseStringContext DbContext { get; private set; }
    }
}
