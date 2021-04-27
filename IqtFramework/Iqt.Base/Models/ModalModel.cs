using System.Collections.Generic;

namespace Iqt.Base.Models
{
    public class ModalModel
    {
        /// <summary>
        /// Gets or Sets the parameters parameters for the modal
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; }

        /// <summary>
        /// The identity of the featured entity
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// Gets or Sets The header text
        /// </summary>
        public string HeaderString { get; set; }

        /// <summary>
        /// Gets or Sets The url where the controller resides
        /// </summary>
        public string ControllerUrl { get; set; }
    }
}
