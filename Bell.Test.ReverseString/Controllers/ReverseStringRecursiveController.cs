using Bell.Test.ReverseStringServices.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace Bell.Test.ReverseString.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverseStringRecursiveController : ControllerBase
    {
        private readonly IReverseStringService reverseStringService;

        private readonly ILogger<ReverseStringForController> _logger;

        public ReverseStringRecursiveController(ILogger<ReverseStringForController> logger, IReverseStringService reverseStringService)
        {
            _logger = logger;

            this.reverseStringService = reverseStringService;
        }

        [HttpPost(Name = "recursive")]
        public async Task<Domain.ReverseString> Recursive([FromBody] Domain.ReverseString stringToReverse)
        {
            return await this.reverseStringService.ReverseStringRecursive(stringToReverse);
        }
    }

}
