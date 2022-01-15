using Bell.Test.Infrastructure.Repositories.IntegrationTests.Context;
using Bell.Test.Infrastructure.Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Bell.Test.Infrastructure.Repositories.IntegrationTests
{
    public class ReverseStringRepositoryTests : ReverseStringRepositoryContext
    {
        public ReverseStringRepositoryTests()
        {
            this.GivenSQLLiteTestDB();
        }

        [Fact]
        public async Task RetrieveShortestStringRawSqlTest()
        {
            IReverseStringRepository repository = new ReverseStringRepository(this.DbContext);

            var value = await repository.RetrieveShortestStringRawSql();

            Assert.Equal("test1237", value.Value);
        }

        [Fact]
        public async Task RetrieveShortestStringReversedRawSqlTest()
        {
            IReverseStringRepository repository = new ReverseStringRepository(this.DbContext);

            var value = await repository.RetrieveShortestStringRawSql();

            Assert.Equal("7321tset", value.Value);
        }

        [Fact]
        public async Task RetrieveShortestStringTest()
        {
            IReverseStringRepository repository = new ReverseStringRepository(this.DbContext);

            var value = await repository.RetrieveShortestString();

            Assert.Equal("test1237", value.Value);
        }

        [Fact]
        public async Task RetrieveShortestStringReversedTest()
        {
            IReverseStringRepository repository = new ReverseStringRepository(this.DbContext);

            var value = await repository.RetrieveShortestStringReversed();

            Assert.Equal("7321tset", value.Value);
        }

        [Fact]
        public async Task SaveReversedStringTest()
        {
            IReverseStringRepository repository = new ReverseStringRepository(this.DbContext);

            var value = await repository.SaveReversedString(new ReverseString.Domain.ReverseString
            {
                Value = "7321tset"
            });

            Assert.NotEqual(Guid.Empty, value.Id);
        }
    }
}