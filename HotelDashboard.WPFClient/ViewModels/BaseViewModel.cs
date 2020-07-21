using System.ComponentModel;

namespace HotelDashboard.WPFClient.ViewModels
{
    /// <summary>
    /// Базовый класс для всех ViewModel
    /// </summary>
    class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
