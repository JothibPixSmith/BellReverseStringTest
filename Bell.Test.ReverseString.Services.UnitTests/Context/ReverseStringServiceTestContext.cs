using Bell.Test.Infrastructure.Repositories.Interfaces;
using Moq;
using System.Threading.Tasks;

namespace Bell.Test.ReverseString.Services.UnitTests.Context
{
    public class ReverseStringServiceTestContext
    {
        private Mock<IReverseStringRepository> repositoryMock;


        protected void GivenRepositoryMock()
        {
            this.repositoryMock = new Mock<IReverseStringRepository>();

            this.repositoryMock.Setup(x => x.SaveReversedString(It.IsAny<Domain.ReverseString>()))
                .Returns<Domain.ReverseString>(x => Task.FromResult(x));
        }

        protected IReverseStringRepository ReverseStringRepository => repositoryMock.Object;
    }
}
