namespace HotelDashboard.WPFClient.ViewModels.Dialogs
{
    /// <summary>
    /// Интерфейс ViewModel для всех диалогов
    /// </summary>
    interface IDialogViewModel
    {
        /// <summary>
        /// Данные, переданные в диалог
        /// </summary>
        object[] Data { set; get; }
        /// <summary>
        /// Заголовок
        /// </summary>
        string Title { set; get; }
        /// <summary>
        /// Результат диалога
        /// </summary>
        object Result { get; }
    }
}
