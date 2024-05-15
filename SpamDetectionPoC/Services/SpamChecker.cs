using SpamDetectionPoC.Domain.Request;
using SpamDetectionPoC.Domain.Response;

namespace SpamDetectionPoC.Services
{
    public interface ISpamChecker
    {
        Task<SpamCheckerResponse> GetScore(SpamCheckerRequest request);
    }
}
