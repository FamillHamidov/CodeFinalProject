namespace Travel.Web.Models
{
    public class ClientSettings
    {
        public Client WebClient { get; set; } = null!;
        public Client WebClientForUser { get; set; } = null!;
    }
    public class Client
    {
        public string ClientId { get; set; } = null!;
        public string ClientSecret { get; set; }=null!; 
    }
}
