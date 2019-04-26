using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace W3Tools
{
    /// <summary>
    /// Represents an abstract object that provides notifications when properties are changed or are changing.
    /// Implements <see cref="INotifyPropertyChanged"/> and <see cref="INotifyPropertyChanging"/>
    /// </summary>
    public abstract class ObservableObject : INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region NotifyPropertyChanged
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Invoke the PropertyChanged event using the caller property name with <see cref="CallerMemberNameAttribute"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property that was changed.</param>
        protected virtual void InvokePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Invoke the PropertyChanged event using a custom <see cref="PropertyChangedEventArgs"/> instance.
        /// </summary>
        /// <param name="args">The property changed event arguments.</param>
        protected virtual void InvokePropertyChanged(PropertyChangedEventArgs args)
        {
            var propertyChanged = PropertyChanged;
            propertyChanged?.Invoke(this, args);
        }
        #endregion

        #region NotifyPropertyChanging
        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Invoke the PropertyChanging event using the caller property name with <see cref="CallerMemberNameAttribute"/>.
        /// </summary>
        /// <param name="propertyName">The name of the property that is changing.</param>
        protected virtual void InvokePropertyChanging([CallerMemberName] string propertyName = null)
        {
            var propertyChanging = PropertyChanging;
            propertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }
        /// <summary>
        /// Invoke the PropertyChanging event using a custom <see cref="PropertyChangingEventArgs"/> instance.
        /// </summary>
        /// <param name="args">The property changing event arguments.</param>
        protected virtual void InvokePropertyChanging(PropertyChangingEventArgs args)
        {
            var propertyChanging = PropertyChanging;
            propertyChanging?.Invoke(this, args);
        }
        #endregion
    }
}
