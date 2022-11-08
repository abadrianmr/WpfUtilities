using System.ComponentModel;
using System.Windows;

namespace WpfUtilities.Navigation.Abstract
{
    public interface INavigationService
    {
        /// <summary>
        /// Show a window with its viewModel as DataContext
        /// </summary>
        /// <typeparam name="T">
        /// Generic type that inherit from <see cref="Window"/>
        /// </typeparam>
        /// <typeparam name="U">
        /// Generic type that implement <see cref="INotifyPropertyChanged"></see>/>
        /// </typeparam>
        /// <returns>
        /// An instance of <see cref="{T}"/>
        /// </returns>
        public T Show<T, U>() where T : Window where U : INotifyPropertyChanged;
        /// <summary>
        /// Show a window <see cref="{T}"/> and resolve its view model by name police.
        /// </summary>
        /// <typeparam name="T">
        /// Generic type that inherit from <see cref="Window"/>
        /// </typeparam>
        /// <returns>
        /// An instance of <see cref="{T}"/>
        /// </returns>
        public T Show<T>() where T : Window;
    }
}
