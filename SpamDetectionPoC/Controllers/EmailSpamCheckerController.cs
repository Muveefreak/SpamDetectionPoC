using Microsoft.AspNetCore.Mvc;
using SpamDetectionPoC.Domain.Request;
using SpamDetectionPoC.Services;

namespace SpamDetectionPoC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSpamCheckerController : ControllerBase
    {
        private IEmailSpamCheckerService _emailSpamCheckerService;
        public EmailSpamCheckerController(IEmailSpamCheckerService emailSpamCheckerService)
        {
            _emailSpamCheckerService = emailSpamCheckerService;
        }

        /// <summary>
        /// Method validates email message as spam or not
        /// </summary>
        /// /// <param name="EmailRequest">Query that contains email message.</param>
        /// <returns>Method returns boolean response on whether a test is seen as spam or not.</returns>
        [HttpPost]
        [Route("IsSpam")]
        public async Task<IActionResult> IsSpam(EmailRequest request)
        {
            var response = await _emailSpamCheckerService.CheckSpamAsync(request.Message);
            return Ok(response);
        }
    }
}
