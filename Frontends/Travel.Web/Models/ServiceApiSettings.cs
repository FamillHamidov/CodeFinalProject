namespace Travel.Web.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; } = null!;
        public string GatewayBaseUri { get; set; } = null!;
        public string PhotoStockUri { get; set; }=null!;
        public ServiceApi? Catalog { get; set; }
        public ServiceApi? PhotoStock { get; set; }
        public ServiceApi Basket { get; set; }=null!;
        public ServiceApi Discount { get; set; }=null!;
        public ServiceApi Payment { get; set; }=null!;
        public ServiceApi Order { get; set; }=null!;
    }
    public class ServiceApi
    {
        public string Path { get; set; } = null!;
    }
}
