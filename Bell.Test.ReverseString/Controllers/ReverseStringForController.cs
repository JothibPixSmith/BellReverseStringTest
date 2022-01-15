using Bell.Test.ReverseStringServices.Infrastructure;
using Microsoft.AspNetCore.Mvc;
namespace Bell.Test.ReverseString.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverseStringForController : ControllerBase
    {
        private readonly IReverseStringService reverseStringService;

        private readonly ILogger<ReverseStringForController> _logger;

        public ReverseStringForController(ILogger<ReverseStringForController> logger, IReverseStringService reverseStringService)
        {
            _logger = logger;

            this.reverseStringService = reverseStringService;
        }

        [HttpPost(Name = "forLoop")]
        public async Task<Domain.ReverseString> ForLoop([FromBody] Domain.ReverseString stringToReverse)
        {
            return await this.reverseStringService.ReverseStringForLoop(stringToReverse);
        }

    }




}