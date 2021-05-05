﻿using FeawThings;
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
        public string SupportEmailAddress { get; } = "support@iqtechsolutions.co.za";
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

        public string BaseImageUrl { get; } = ServerLocations.AdminServer;
        public string BaseApiUrl { get; } = ServerLocations.ApiServer + "/api/v1";
        public string BaseIdentityUrl { get; } = ServerLocations.IdentityServer;
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
