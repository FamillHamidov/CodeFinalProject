﻿namespace Travel.Web.Models
{
    public class ServiceApiSettings
    {
        public string IdentityBaseUri { get; set; } = null!;
        public string GatewayBaseUri { get; set; } = null!;
        public string PhotoStockUri { get; set; }=null!;
        public ServiceApi? Catalog { get; set; }
    }
    public class ServiceApi
    {
        public string Path { get; set; } = null!;
    }
}
