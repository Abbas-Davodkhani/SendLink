namespace SendingSMS.Service
{
    public interface IMessageService
    {
        Task Send(string message , string phoneNumber , CancellationToken cancellationToken);
    }
    public class MessageService : IMessageService
    {
        private readonly IShortLinkService _shortLinkService;
        private string _apiKey = "6446536649646658524B512F372B595A732F622B414E6435445A774D5556713878706F48597066737263633D";
        public MessageService(IShortLinkService shortLinkService) { _shortLinkService = shortLinkService; } 

        public async Task Send(string message , string phoneNumber , CancellationToken cancellationToken)
        {
            var sender = "1000596446";
            var receptor = phoneNumber;
            var api = new Kavenegar.KavenegarApi(_apiKey);
            api.Send(sender, receptor, message);
        }
    }
}
