using Iqt.Base.BaseTypes;

namespace Metsi.Mobile.Models.Troubleshooting
{
    /// <summary>
    /// The model used to represent a problem object
    /// </summary>
    public class ProblemModel : ModelBase
    {
        #region Members

        private string _id;
        private string _problemContent;

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

        public int CausesCount { get; set; }
        public int CorrectiveActionsCount { get; set; }

        #endregion
    }
}
