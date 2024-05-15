namespace SpamDetectionPoC.Domain.Response
{
    public class SpamCheckerResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public string Report { get; set; }
        public string Score { get; set; }
        public string Rules { get; set; }
    }
}
