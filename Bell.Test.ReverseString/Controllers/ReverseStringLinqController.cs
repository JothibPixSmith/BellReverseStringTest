using Bell.Test.ReverseStringServices.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace Bell.Test.ReverseString.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverseStringLinqController : ControllerBase
    {
        private readonly IReverseStringService reverseStringService;

        private readonly ILogger<ReverseStringForController> _logger;

        public ReverseStringLinqController(ILogger<ReverseStringForController> logger, IReverseStringService reverseStringService)
        {
            _logger = logger;

            this.reverseStringService = reverseStringService;
        }

        [HttpPost(Name = "linq")]
        public async Task<Domain.ReverseString> Linq([FromBody] Domain.ReverseString stringToReverse)
        {
            return await this.reverseStringService.ReverseStringLinq(stringToReverse);
        }
    }

}
