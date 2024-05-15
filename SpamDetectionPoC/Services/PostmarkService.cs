using postmarkspamcheck;
using SpamDetectionPoC.Domain.Request;
using SpamDetectionPoC.Domain.Response;

namespace SpamDetectionPoC.Services
{
    public class PostmarkService : ISpamChecker
    {
        public PostmarkService()
        {
        }

        public async Task<SpamCheckerResponse> GetScore(SpamCheckerRequest request)
        {
            var response = new SpamCheckerResponse();

            var spamChecker = new PostmarkSpamcheck();

            var spamResults = await spamChecker.GetScore(request.Message);

            if (spamResults?.success ?? false)
            {
                response.Report = spamResults.report;
                response.Score = spamResults.score;
            }
            else
            {
                response.Message = spamResults.message;
            }
            return response;
        }
    }
}
