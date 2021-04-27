using System;

namespace Metsi.Mobile.Views.Application
{
    /// <summary>
    /// The master menu item
    /// </summary>
    public class MainViewMasterMenuItem
    {
        /// <summary>
        /// The default constructor
        /// </summary>
        public MainViewMasterMenuItem()
        {
            TargetType = typeof(MainViewMasterMenuItem);
        }

        /// <summary>
        /// The identity of the menu item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the menu item
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The view model to target
        /// </summary>
        public Type TargetType { get; set; }
    }
}