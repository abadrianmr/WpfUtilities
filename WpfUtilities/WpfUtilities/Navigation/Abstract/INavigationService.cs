using System.ComponentModel;
using System.Windows;

namespace WpfUtilities.Navigation.Abstract
{
    public interface INavigationService
    {
        public T Show<T, U>() where T : Window where U : INotifyPropertyChanged;
        public T Show<T>() where T : Window;
    }
}
