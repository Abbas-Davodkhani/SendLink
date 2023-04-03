using Newtonsoft.Json;

namespace SendingSMS.Service
{
    public interface IShortLinkService
    {
        Task<ShortLink> GetShortLinkAsync(string longUrl, CancellationToken cancellationToken);
    }
    public class ShortLinkService : IShortLinkService   
    {
        private string BaseUrl = "https://rizy.ir/api?api=2b3a365e30d848f536a8a07252ee0c2fd38b0225&url=";
        public ShortLinkService()
        {

        }

        public async Task<ShortLink> GetShortLinkAsync(string longUrl, CancellationToken cancellationToken)
        {
            using HttpClient client = new HttpClient();

            string url = !string.IsNullOrEmpty(longUrl) ? BaseUrl += longUrl : BaseUrl+= "https://burux.com"; 
            HttpRequestMessage requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,              
                RequestUri = new Uri(url)
            };

            var response = await client.SendAsync(requestMessage , cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();  

            return JsonConvert.DeserializeObject<ShortLink>(responseBody);
        }
    }

    public class ShortLink
    {
        [JsonProperty("shortenedUrl")]    
        public string ShortEnedUrl { get; set; }
    }
}
