using System.Collections.Generic;
using System.Runtime.Serialization;
using Iqt.Base.BaseTypes;
using Xamarin.Forms.Internals;

namespace Metsi.Mobile.Models.Faqs
{
    /// <summary>
    /// Model for the FAQ page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class FAQ : ModelBase
    {
        private string _question;

        #region Properties

        public string Question
        {
            get { return _question;}
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        public List<string> Answer { get; set; }

        #endregion

    }
}
