using System;
using System.Collections.Generic;
using System.Text;
using Iqt.Base.Interfaces;

namespace Metsi.Web
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string CompanyName => "Enviro Metsi Pty Ltd";
        public string PhoneNr => "021 204 0798";
        public string EmailAddress => "admin@metsi.co.za";
        public string PhysicalAddress => "Taaibos Close, Protea Height, Brackenfell, Cape Town";

        public string FacebookUrl => "#";
        public string TwitterUrl => "#";
        public string LinkedInUrl => "#";
        public string YouTubeUrl => "#";
        public string PrinterestUrl => "#";
        public string InstagramUrl => "#";

        public string BaseApiUrl  => "http://api.metsi.co.za";
        public string BaseImageUrl => "http://admin.metsi.co.za";
    }
}
