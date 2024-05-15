using SpamDetectionPoC.Domain.Request;

namespace SpamDetectionPoC.Services
{
    public interface IEmailSpamCheckerService
    {
        Task<bool> CheckSpamAsync(string email);
    }
    public class EmailSpamCheckerService : IEmailSpamCheckerService
    {
        private readonly ISpamChecker _spamChecker;
        private readonly int _allowedScore;

        public EmailSpamCheckerService(ISpamChecker spamChecker, IConfiguration configuration)
        {
            _spamChecker = spamChecker ?? throw new ArgumentNullException(nameof(spamChecker));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            _allowedScore = configuration.GetValue<int>("AllowedSpamCheckScore");
        }

        public async Task<bool> CheckSpamAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty", nameof(email));

            var spamCheckerRequest = new SpamCheckerRequest
            {
                Message = email
            };

            var scoreResponse = await _spamChecker.GetScore(spamCheckerRequest);

            if (scoreResponse == null)
                throw new InvalidOperationException("Spam checker response is null");

            if (!float.TryParse(scoreResponse.Score, out float score))
                throw new FormatException("Spam checker response message is not a valid integer");

            return !(score >= _allowedScore);
        }
    }
}
