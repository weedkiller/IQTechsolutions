using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Iqt.Base.Entities
{
    public class SocialMedia
    {
        #region Properties

        /// <summary>
        /// The website address of the user
        /// </summary>
        [DisplayName(@"Website")]
        public string WebSiteAddress { get; set; }

        /// <summary>
        /// The url of the user's facebook account
        /// </summary>
        public string Facebook { get; set; }

        /// <summary>
        /// The url of the user's google account
        /// </summary>
        public string Google { get; set; }

        /// <summary>
        /// The url of the user's linkedin account
        /// </summary>
        public string Linkedin { get; set; }

        /// <summary>
        /// The url of the user's twitter account
        /// </summary>
        public string Twitter { get; set; }

        /// <summary>
        /// The url of the user's youtube account
        /// </summary>
        public string Youtube { get; set; }

        #endregion
    }
}
