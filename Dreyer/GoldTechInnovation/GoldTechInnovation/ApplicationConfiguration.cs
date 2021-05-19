using Iqt.Base.Interfaces;

namespace GoldTechInnovation
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string CompanyName { get; } = "Gold Tech Innovation";
        public string RegistrationNr { get; }
        public string PhoneNr { get; } = "+27 83 447 0329";
        public string EmailAddress { get; } = "info@goldtechinnovation.co.za";
        public string AdminEmailAddress { get; } = "admin@goldtechinnovation.co.za";
        public string SupportEmailAddress { get; } = "support@goldtechinnovation.co.za";
        public string AbuseEmailAddress { get; } = "abuse@goldtechinnovation.co.za";
        public string InfoEmailAddress { get; } = "info@goldtechinnovation.co.za";
        public string PhysicalAddress { get; } = "20 Strawberry Fields Goedemoed Durbanville";
        public string PhysicalAddressLine1 { get; } = "20 Strawberry Fields";
        public string PhysicalAddressLine2 { get; } = "Goedemoed Durbanville";
        public string DefaultWebsiteAddress { get; } = "www.goldtechinnovation.co.za";
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
