using Microsoft.Extensions.Options;
using Travel.Web.Models;

namespace Travel.Web.Helpers
{
    public class PhotoHelper
    {
        private readonly ServiceApiSettings _settings;

        public PhotoHelper(IOptions<ServiceApiSettings> settings)
        {
            _settings = settings.Value;
        }
        public string GetPhotoStockUrl(string photoUrl)
        {
            return $"{_settings.PhotoStockUri}/photos/{photoUrl}";
        }
    }
}
