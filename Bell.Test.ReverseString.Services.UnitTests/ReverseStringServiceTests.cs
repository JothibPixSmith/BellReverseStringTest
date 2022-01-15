using Bell.Test.ReverseString.Services.UnitTests.Context;
using Bell.Test.ReverseStringServices;
using Bell.Test.ReverseStringServices.Infrastructure;
using System.Threading.Tasks;
using Xunit;

namespace Bell.Test.ReverseString.Services.UnitTests
{
    public class ReverseStringServiceTests : ReverseStringServiceTestContext
    {
        private const string ReversedString = "4321tset";

        private const string StringToReverse = "test1234";

        public ReverseStringServiceTests()
        {
            this.GivenRepositoryMock();
        }

        [Fact]
        public async Task ReverseStringWithForLoop()
        {
            IReverseStringService service = new ReverseStringService(this.ReverseStringRepository);

            var reversedStringObject = await service.ReverseStringForLoop(new Domain.ReverseString
            {
                Value = StringToReverse
            });

            Assert.Equal(ReversedString, reversedStringObject.Value);
        }

        [Fact]
        public async Task ReverseStringWithRecursive()
        {
            IReverseStringService service = new ReverseStringService(this.ReverseStringRepository);

            var reversedStringObject = await service.ReverseStringRecursive(new Domain.ReverseString
            {
                Value = StringToReverse
            });

            Assert.Equal(ReversedString, reversedStringObject.Value);
        }

        [Fact]
        public async Task ReverseStringWithLinq()
        {
            IReverseStringService service = new ReverseStringService(this.ReverseStringRepository);

            var reversedStringObject = await service.ReverseStringLinq(new Domain.ReverseString
            {
                Value = StringToReverse
            });

            Assert.Equal(ReversedString, reversedStringObject.Value);
        }
    }
}