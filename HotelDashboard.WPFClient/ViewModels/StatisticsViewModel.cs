using HotelDashboard.Data.Models.Enums;
using HotelDashboard.Services.DtoModels;
using HotelDashboard.WPFClient.Models;
using HotelDashboard.WPFClient.ViewModels.Commands;
using HotelDashboard.WPFClient.Views.Enums;
using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace HotelDashboard.WPFClient.ViewModels
{
    /// <summary>
    /// ViewModel статистики гостинницы
    /// </summary>
    class StatisticsViewModel : BaseViewModel
    {
        /*
            LiveCharts не умеет работать из разных графиков с одним SeriesCollection (выбрасывает
            NullReferenceException из своих недр при попытке показать график),
            ну или по крайней мере нужен какой-то особый подход. Поэтому вместо одного свойства
            PlotSeries будут свойства под каждый тип графика, использующие общую коллекцию.
        */

        /// <summary>
        /// Данные для графика из столбцов
        /// </summary>
        public SeriesCollection ColumnPlotSeries

        {
            set
            {
                _seriesView = value;
                OnPropertyChanged(nameof(ColumnPlotSeries));
            }
            get
            {
                return _seriesView;
            }
        }

        /// <summary>
        /// Данные для графика из строк
        /// </summary>
        public SeriesCollection RowPlotSeries
        {
            set
            {
                _seriesView = value;
                OnPropertyChanged(nameof(RowPlotSeries));
            }
            get
            {
                return _seriesView;
            }
        }

        /// <summary>
        /// Данные для кругогово графика
        /// </summary>
        public SeriesCollection PiePlotSeries
        {
            set
            {
                _seriesView = value;
                OnPropertyChanged(nameof(PiePlotSeries));
            }
            get
            {
                return _seriesView;
            }
        }
        /// <summary>
        /// Корпусы
        /// </summary>
        public ObservableCollection<CorpsDto> Corps
        {
            set
            {
                _corps = value;
                OnPropertyChanged(nameof(Corps));
            }
            get
            {
                return _corps;
            }
        }

        /// <summary>
        /// Этажи
        /// </summary>
        public ObservableCollection<FloorDto> Floors
        {
            set
            {
                _floors = value;
                OnPropertyChanged(nameof(Floors));
            }
            get
            {
                return _floors;
            }
        }

        /// <summary>
        /// Список типов комнаты
        /// </summary>
        public ObservableCollection<RoomType> RoomTypes { get; } = new ObservableCollection<RoomType>(Enum.GetValues(typeof(RoomType)).Cast<RoomType>().ToArray());
        
        /// <summary>
        /// Список типов графика
        /// </summary>
        public ObservableCollection<PlotType> PlotTypes { get; } = new ObservableCollection<PlotType>(Enum.GetValues(typeof(PlotType)).Cast<PlotType>().ToArray());
       
        /// <summary>
        /// Выбранный корпус
        /// </summary>
        public CorpsDto SelectedCorps
        {
            set
            {
                _selectedCorps = value;
                OnPropertyChanged(nameof(SelectedCorps));
                // сбрасываем выбранный этаж
                SelectedFloor = null;
                // подкачиваем этажи корпуса
                Floors = _controlModel.GetCorpsFloors(SelectedCorps);
                // подкачиваем статистику корпуса
                StatisticsInfo = _statisticsModel.GetCorpsStatistics(SelectedCorps);
            }
            get
            {
                return _selectedCorps;
            }
        }

        /// <summary>
        /// Выбранный этаж
        /// </summary>
        public FloorDto SelectedFloor
        {
            set
            {
                _selectedFloor = value;
                OnPropertyChanged(nameof(SelectedFloor));
                // сбрасываем выбранный тип комнаты
                SelectedRoomType = null;
                // подкачиваваем статистику этажа
                if (SelectedFloor != null)
                {
                    StatisticsInfo = _statisticsModel.GetFloorStatistics(SelectedFloor);
                }
            }
            get
            {
                return _selectedFloor;
            }
        }

        /// <summary>
        /// Выбранный тип комнаты
        /// </summary>
        public RoomType? SelectedRoomType
        {
            set
            {
                _selectedRoomType = value;
                OnPropertyChanged(nameof(SelectedRoomType));
                // подкачиваем статистику по типу комнаты на этаже
                if (SelectedRoomType != null)
                {
                    StatisticsInfo = _statisticsModel.GetRoomTypeStatistics(SelectedFloor, SelectedRoomType.GetValueOrDefault());
                }
            }
            get
            {
                return _selectedRoomType;
            }
        }
        /// <summary>
        /// Выбранный тип графика
        /// </summary>
        public PlotType? SelectedPlotType
        {
            set
            {
                _selectedPlotType = value;
                OnPropertyChanged(nameof(SelectedPlotType));
                // обновляем представление для конкретного графика
                UpdatePlotSeries();
            }
            get
            {
                return _selectedPlotType;
            }
        }


        /// <summary>
        /// Команда выбора корпуса
        /// </summary>
        public ICommand OnSelectCorps => new BaseCommand(o =>
        {
            SelectedCorps = (CorpsDto)o;
        });

        public ICommand OnSelectFloor => new BaseCommand(o => {
            SelectedFloor = (FloorDto)o;
        });

        /// <summary>
        /// Команда выбора типа комнаты
        /// </summary>
        public ICommand OnSelectRoomType => new BaseCommand(o => {
            SelectedRoomType = (RoomType)o;
        });

        /// <summary>
        /// Команда выбора типа графика
        /// </summary>
        public ICommand OnSelectPlotType => new BaseCommand(o => {
            SelectedPlotType = (PlotType)o;
        });

        public StatisticsViewModel()
        {
            // начальное заполнение данными
            Corps = new ObservableCollection<CorpsDto>(_controlModel.GetCorps());
        }

        /// <summary>
        /// Приватное свойство. Вызывает конвертацию статистики в формат графика
        /// </summary>
        public StatisticsInfoDto StatisticsInfo
        {
            set
            {
                _statisticsInfoDto = value;
                OnPropertyChanged(nameof(StatisticsInfo));
                // обновляем график согласно выбраному типу
                UpdatePlotSeries();
            }
            get
            {
                return _statisticsInfoDto;
            }
        }

        /// <summary>
        /// Конвертер статистики в данные для графика
        /// </summary>
        /// <param name="statisticsInfoDto">Статистика</param>
        private SeriesCollection StatisticsInfoToSeriesCollection(StatisticsInfoDto statisticsInfoDto)
        {
            if (statisticsInfoDto == null)
            {
                return null;
            }
            // надписи
            string freeRoomTitle = "Свободно";
            string reservedRoomTitle = "Зарезервировано";
            string populatedRoomTitle = "Заселено";
            // 
            SolidColorBrush freeRoomBrush = (SolidColorBrush)Application.Current.Resources["FreeRoomBrush"];
            SolidColorBrush reservedRoomBrush = (SolidColorBrush)Application.Current.Resources["ReservedRoomBrush"];
            SolidColorBrush populatedRoomBrush = (SolidColorBrush)Application.Current.Resources["PopulatedRoomBrush"];

            SeriesCollection seriesViews = new SeriesCollection();
            switch (_selectedPlotType)
            {
                case PlotType.Column:
                    {
                        seriesViews.Add(new ColumnSeries()
                        {
                            Title = freeRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.FreeRoomCount},
                            Fill = freeRoomBrush,
                            DataLabels = true
                        });
                        seriesViews.Add(new ColumnSeries()
                        {
                            Title = reservedRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.ReservedRoomCount},
                            Fill = reservedRoomBrush,
                            DataLabels = true
                        });
                        seriesViews.Add(new ColumnSeries()
                        {
                            Title = populatedRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.PopulatedRoomCount},
                            Fill = populatedRoomBrush,
                            DataLabels = true
                        });
                        return seriesViews;
                    }
                case PlotType.Row:
                    {
                        seriesViews.Add(new RowSeries()
                        {
                            Title = freeRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.FreeRoomCount },
                            Fill = freeRoomBrush,
                            DataLabels = true
                        });
                        seriesViews.Add(new RowSeries()
                        {
                            Title = reservedRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.ReservedRoomCount },
                            Fill = reservedRoomBrush,
                            DataLabels = true
                        });
                        seriesViews.Add(new RowSeries()
                        {
                            Title = populatedRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.PopulatedRoomCount },
                            Fill = populatedRoomBrush,
                            DataLabels = true
                        });
                        return seriesViews;
                    }
                case PlotType.Pie:
                    {
                        seriesViews.Add(new PieSeries()
                        {
                            Title = freeRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.FreeRoomCount },
                            Fill = freeRoomBrush,
                            DataLabels = true
                        });
                        seriesViews.Add(new PieSeries()
                        {
                            Title = reservedRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.ReservedRoomCount },
                            Fill = reservedRoomBrush,
                            DataLabels = true
                        });
                        seriesViews.Add(new PieSeries()
                        {
                            Title = populatedRoomTitle,
                            Values = new ChartValues<int> { statisticsInfoDto.PopulatedRoomCount },
                            Fill = populatedRoomBrush,
                            DataLabels = true
                            
                        });
                        return seriesViews;
                    }
                default:
                    // ничего не возвращаем
                    return null;
            }
        }

        /// <summary>
        /// Обновление данных для выбранного типа графика
        /// </summary>
        private void UpdatePlotSeries()
        {
            // если статистики нет или тип графика не выбран, то обнуляем все графики
            if (StatisticsInfo == null || SelectedPlotType == null)
            {
                ColumnPlotSeries = null;
                RowPlotSeries = null;
                PiePlotSeries = null;
            }
            else
            {
                // иначе формируем нужный
                switch (SelectedPlotType)
                {
                    case PlotType.Column:
                        ColumnPlotSeries = StatisticsInfoToSeriesCollection(StatisticsInfo);
                        break;
                    case PlotType.Row:
                        RowPlotSeries = StatisticsInfoToSeriesCollection(StatisticsInfo);
                        break;
                    case PlotType.Pie:
                        PiePlotSeries = StatisticsInfoToSeriesCollection(StatisticsInfo);
                        break;
                }
            }
        }

        // данные
        private readonly ControlModel _controlModel = new ControlModel();
        private readonly StatisticsModel _statisticsModel = new StatisticsModel();
        private ObservableCollection<CorpsDto> _corps;
        private CorpsDto _selectedCorps;
        private ObservableCollection<FloorDto> _floors;
        private FloorDto _selectedFloor;
        private StatisticsInfoDto _statisticsInfoDto;
        private SeriesCollection _seriesView;
        private RoomType? _selectedRoomType;
        private PlotType? _selectedPlotType;
    }
}
