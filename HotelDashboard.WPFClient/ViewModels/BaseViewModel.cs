using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

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
