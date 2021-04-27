using System;
using System.Collections.Generic;
using System.Text;
using Iqt.Base.BaseTypes;

namespace Metsi.Mobile.Models.Application
{
    /// <summary>
    /// The landing page navigation item model
    /// </summary>
    public class LandingPageNavigationItemModel : ModelBase
    {
        private string _itemName;
        private string _description;
        private string _image;

        #region Properties

        /// <summary>
        /// The name of the navigation item
        /// </summary>
        public string ItemName
        {
            get { return _itemName; }
            set
            {
                _itemName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// The description of the navigation item
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

        /// <summary>
        /// Gets or sets the image of an navigation item.
        /// </summary>
        /// <value>The image.</value>
        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

    }
}
