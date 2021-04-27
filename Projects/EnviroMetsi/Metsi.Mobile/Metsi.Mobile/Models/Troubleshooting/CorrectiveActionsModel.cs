using Iqt.Base.BaseTypes;

namespace Metsi.Mobile.Models.Troubleshooting
{
    public class CorrectiveActionsModel : ModelBase
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">The identity of the corrective action associated with this model</param>
        /// <param name="description">The description of the corrective action associated with this model</param>
        public CorrectiveActionsModel(string id, string description, string parentId)
        {
            _id = id;
            _parentId = parentId;
            _description = description;
        }

        #endregion

        #region Members

        private string _id;
        private string _parentId;
        private string _description;

        #endregion

        #region Properties

        /// <summary>
        /// The identity of the corrective action featured by this model
        /// </summary>
        public string Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The identity of the corrective action featured by this model
        /// </summary>
        public string ParentId
        {
            get { return _parentId; }
            set
            {
                if (_parentId == value)
                {
                    return;
                }

                _parentId = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The descriptions of the corrective action featured by this model
        /// </summary>
        public string Description
        {
            get { return _description; }
            set
            {

                _description = value;
                OnPropertyChanged();
            }
        }

        #endregion

    }
}
