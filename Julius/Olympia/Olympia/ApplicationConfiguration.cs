using System;
using System.Collections.Generic;
using System.Text;
using Iqt.Base.Interfaces;

namespace Olympia
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string CompanyName { get; } = "Olympia Holding Pty Ltd";
        public string RegistrationNr { get; }
        public string PhoneNr { get; } = "+27 73 008 2739";
        public string EmailAddress { get; } = "info@olympiahd.com";
        public string AdminEmailAddress { get; } = "admin@olympiahd.com";
        public string SupportEmailAddress { get; } = "support@olympiahd.com";
        public string AbuseEmailAddress { get; } = "abuse@olympiahd.com";
        public string InfoEmailAddress { get; } = "info@olympiahd.com";
        public string PhysicalAddress { get; } = "The Vineyards Office Estate, Manor House, 99 Jip De Jager, Bellville";
        public string FacebookUrl { get; }
        public string TwitterUrl { get; }
        public string LinkedInUrl { get; }
        public string YouTubeUrl { get; }
        public string PrinterestUrl { get; }
        public string InstagramUrl { get; }
        public string SkypeName { get; }
        public string BaseImageUrl { get; }
        public string BaseApiUrl { get; }
        public string BaseIdentityUrl { get; }

        public string ImageDefaultPlaceholder => "/images/placeholders/NoImageAvailable.jpg";
        public string ImageProfilePlaceholder => "/images/placeholders/profileImage128x128.png";

        public string PhysicalAddressLine1 => throw new NotImplementedException();

        public string PhysicalAddressLine2 => throw new NotImplementedException();

        public string DefaultWebsiteAddress => throw new NotImplementedException();

        public string GetRegistrationReturnUrl(string returnUrl)
        {
            throw new System.NotImplementedException();
        }
        public string GetLoginReturnUrl(string returnUrl)
        {
            throw new System.NotImplementedException();
        }
    }
}
