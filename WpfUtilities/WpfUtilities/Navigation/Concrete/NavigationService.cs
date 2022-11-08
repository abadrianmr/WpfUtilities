using System;
using System.ComponentModel;
using System.Windows;
using Unity;
using WpfUtilities.Navigation.Abstract;

namespace WpfUtilities.Navigation.Concrete
{
    /// <summary>
    /// Service that manage window navigations
    /// </summary>
    public sealed class NavigationService : INavigationService
    {
#pragma warning disable CS8618
        [Dependency]
        public IUnityContainer Container { get; set; }
#pragma warning restore

        public T Show<T, U>() where T : Window where U : INotifyPropertyChanged
        {
            var window = Container.Resolve<T>();
            var viewModel = Container.Resolve<U>();
            window.DataContext = viewModel;
            window.Show();
            return window;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public T Show<T>() where T : Window
        {
            var window = Container.Resolve<T>();

            var @namespace = typeof( T ).Namespace?.Replace( ".View", ".ViewModel" );
            var viewModelName = window.GetType().Name.Replace( "Window", "" ) + "ViewModel";
            var viewModelType = Type.GetType( string.Format( "{0}.{1}", @namespace, viewModelName ) );

            if( viewModelType == null )
            {
                throw new ArgumentException( $"The viewmodel of the view {window.Name} could not be found" );
            }

            var viewModel = Container.Resolve( viewModelType );
            window.DataContext = viewModel;
            window.Show();
            return window;
        }
    }
}
