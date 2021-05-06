using GoldTechInnovation;
using Iqt.Base.Interfaces;

namespace Metsi
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string CompanyName { get; } = "Enviro Metsi";
        public string RegistrationNr { get; }
        public string PhoneNr { get; } = "+27 21 204 0798";
        public string EmailAddress { get; } = "dewald@metsi.co.za";
        public string AdminEmailAddress { get; } = "admin@metsi.co.za";
        public string SupportEmailAddress { get; } = "support@metsi.co.za";
        public string AbuseEmailAddress { get; } = "abuse@metsi.co.za";
        public string InfoEmailAddress { get; } = "info@metsi.co.za";
        public string PhysicalAddress { get; } = "4 Taaibos Close, Brackenfell, Cape Town";
        public string FacebookUrl { get; }
        public string TwitterUrl { get; }
        public string LinkedInUrl { get; }
        public string YouTubeUrl { get; }
        public string PrinterestUrl { get; }
        public string InstagramUrl { get; }
        public string SkypeName { get; }

        public string BaseImageUrl { get; set; } = ServerLocations.AdminServer;
        public string BaseApiUrl { get; set; } = ServerLocations.ApiServer + "/api/v1";
        public string BaseIdentityUrl { get; set; } = ServerLocations.IdentityServer;

        public string ImageDefaultPlaceholder => "/images/placeholders/NoImageAvailable.jpg";
        public string ImageProfilePlaceholder => "/images/placeholders/profileImage128x128.png";

        public string GetRegistrationReturnUrl(string returnUrl)
        {
            return ServerLocations.IdentityServer + "/Authentication/Register?ReturnUrl=" + returnUrl;
        }
        public string GetLoginReturnUrl(string returnUrl)
        {
            return ServerLocations.IdentityServer + "/Authentication/Login?ReturnUrl=" + returnUrl;
        }
    }
}
