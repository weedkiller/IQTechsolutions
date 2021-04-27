using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Iqt.Base.BaseTypes
{
    /// <summary>
    /// The base for any Model
    /// </summary>
    public class ModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        /// <summary>
        /// The property changed event handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Runs when <see cref="PropertyChanged"/> is invoked
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
