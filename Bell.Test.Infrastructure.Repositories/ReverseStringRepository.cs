using Bell.Test.Infrastructure.Database;
using Bell.Test.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Bell.Test.Infrastructure.Repositories
{
    public class ReverseStringRepository : IReverseStringRepository
    {
        private readonly ReverseStringContext context;

        public ReverseStringRepository(ReverseStringContext context)
        {
            this.context = context;
        }

        public async Task<ReverseString.Domain.ReverseString> RetrieveShortestString()
        {
            return await context.ReversedStrings.FirstOrDefaultAsync(x => x.Value.Length == context.ReversedStrings.Min(y => y.Value.Length));
        }

        public async Task<ReverseString.Domain.ReverseString> RetrieveShortestStringRawSql()
        {
            return await context.ReversedStrings.FromSqlRaw(@"
                    SELECT Value FROM ReversedStrings
                    ORDER BY LENGTH(Value)
                        ").FirstOrDefaultAsync();
        }

        public async Task<ReverseString.Domain.ReverseString> RetrieveShortestStringReversed()
        {
            var shortestString = await context.ReversedStrings
                .Where(x => x.Value.Length == context.ReversedStrings.Min(y => y.Value.Length))
                .Select(x => x.Value.Reverse())
                .FirstOrDefaultAsync();

            return new ReverseString.Domain.ReverseString
            {
                Value = new string(shortestString?.ToArray()),
            };
        }

        public async Task<ReverseString.Domain.ReverseString> RetrieveShortestStringReversedRawSql()
        {
            return await context.ReversedStrings.FromSqlRaw(@"
                    SELECT REVERSE(Value) FROM ReversedStrings
                    ORDER BY LENGTH(Value)
                        ").FirstOrDefaultAsync();
        }

        public async Task<ReverseString.Domain.ReverseString> SaveReversedString(ReverseString.Domain.ReverseString reversedString)
        {
            await context.AddAsync(reversedString);

            await context.SaveChangesAsync();

            return reversedString;
        }
    }
}
