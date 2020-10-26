using CrecheApp.Domain.Interface.Helper;

namespace CrecheApp.Domain.Helpers
{
    public class AppSettings : IAppSettings
    {
        public string Secret { get; set; }
    }
}
