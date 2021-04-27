using FeawThings;
using Iqt.Base.Interfaces;

namespace IQTechSolutions
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string CompanyName { get; } = "IQ Tech Solutions";
        public string RegistrationNr { get; } = "2016/276869/07";
        public string PhoneNr { get; } = "+27 76 434 8180";
        public string EmailAddress { get; } = "ivanrossouw@iqtechsolutions.co.za";
        public string AdminEmailAddress { get; } = "admin@iqtechsolutions.co.za";
        public string AbuseEmailAddress { get; } = "abuse@iqtechsolutions.co.za";
        public string InfoEmailAddress { get; } = "admin@iqtechsolutions.co.za";

        public string PhysicalAddress { get; } = "Clarendon Hills Unit6, Saronsberg Close, Buh-Rein Estates, Cape Town";
        public string FacebookUrl { get; }
        public string TwitterUrl { get; }
        public string LinkedInUrl { get; }
        public string YouTubeUrl { get; }
        public string PrinterestUrl { get; }
        public string InstagramUrl { get; }
        public string SkypeName { get; }

        public string BaseImageUrl { get; } = "https://localhost:44362/";
        public string BaseApiUrl { get; } = "https://localhost:5001/";
        public string BaseIdentityUrl { get; } = "https://localhost:4001/";

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
