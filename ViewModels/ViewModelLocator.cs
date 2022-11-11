using Autofac;
using Maui7.Services.Navigation;
using Maui7.ViewModels;
using Maui7.Views;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

using IContainer = Autofac.IContainer;

namespace Maui7.ViewModels
{
    public static class ViewModelLocator
    {
        //The idea was taken from EshopOnContainers without shell
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        public static bool UseMockService { get; set; }

        public static void RegisterDependencies(bool useMockServices)
        {
            var builder = new ContainerBuilder();

            // View models

            
            builder.RegisterType<RootViewModel>();
            builder.RegisterType<FirstTabViewModel>();
            builder.RegisterType<SecondTabViewModel>();
           


            // Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
           

            
            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
