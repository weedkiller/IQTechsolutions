using Iqt.Base.BaseTypes;

namespace Metsi.Mobile.Models.Troubleshooting
{
    /// <summary>
    /// The model used to represent a problem object
    /// </summary>
    public class CauseModel : ModelBase
    {
        #region Members

        private string _id;
        private string _problemContent;
        private string _description;

        #endregion

        #region Properties

        /// <summary>
        /// The identity of the problem
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }
            set 
            {
                if (_id == value)
                {
                    return;
                };
                _id = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The content of the problem
        /// </summary>
        public string ProblemContent
        {
            get { return _problemContent; }
            set
            {
                if (_problemContent == value)
                {
                    return;
                }

                _problemContent = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The content of the problem
        /// </summary>
        public string ItemDescription
        {
            get { return _description; }
            set
            {
                if (_description == value)
                {
                    return;
                }

                _description = value;
                OnPropertyChanged();
            }
        }

        public int CorrectiveActionsCount { get; set; }

        #endregion
    }
}
