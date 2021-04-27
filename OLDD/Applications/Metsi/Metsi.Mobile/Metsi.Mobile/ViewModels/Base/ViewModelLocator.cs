using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace Metsi.Mobile.ViewModels.Base
{
    public static class ViewModelLocator
    {
        #region Dependency Properties

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Runs when a viewmodel is auto wired to a view
        /// </summary>
        /// <param name="bindable">The bind able object/view</param>
        /// <param name="oldValue">The old view model</param>
        /// <param name="newValue">The new view model</param>
        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName?.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = Startup.ServiceProvider.GetService(viewModelType);
            view.BindingContext = viewModel;
        }

        #endregion
    }
}
