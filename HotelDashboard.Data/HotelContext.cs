using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDashboard.Data
{
    public class HotelContext : DbContext
    {
        public DbSet<Corps> Corps { set; get; }
        public DbSet<Floor> Floors { set; get; }
        public DbSet<Room> Rooms { set; get; }
        public DbSet<Client> Clients { set; get; }
        public DbSet<RoomStatus> RoomStatuses { set; get; }

        private const int PRESET_CORPS_COUNT = 4;
        private const int PRESET_FLOORS_COUNT = 8;
        private const int PRESET_SINGLE_ROOM_COUNT = 4;
        private const int PRESET_DOUBLE_ROOM_COUNT = 4;
        private const int PRESET_FAMILY_ROOM_COUNT = 2;

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //заполняем базу
            SetPresetData(modelBuilder);
        }

        /// <summary>
        /// Заполнение базы данными
        /// </summary>
        /// <param name="modelBuilder">Билдер модели БД</param>
        private void SetPresetData(ModelBuilder modelBuilder)
        {
            //Корпусы
            modelBuilder.Entity<Corps>()
                .HasData(PresetCorpses());
            //Этажи
            modelBuilder.Entity<Floor>()
                .HasData(PresetFloors());
            //Комнаты
            modelBuilder.Entity<Room>()
                .HasData(PresetRooms());
        }

        /// <summary>
        /// Формирование набора корпусов
        /// </summary>
        private Corps[] PresetCorpses()
        {
            Corps[] corps = new Corps[PRESET_CORPS_COUNT];
            for (int i = 1; i <= PRESET_CORPS_COUNT; i++)
            {
                corps[i - 1] = new Corps
                {
                    Id = i
                };
            }
            return corps;
        }

        /// <summary>
        /// Формирование набора этажей
        /// </summary>
        private Floor[] PresetFloors()
        {
            int floorIndex = 0;
            Floor[] floors = new Floor[PRESET_CORPS_COUNT * PRESET_FLOORS_COUNT];
            for (int corpsId = 1; corpsId <= PRESET_CORPS_COUNT; corpsId++)
            {
                for (int _ = 0; _ < PRESET_FLOORS_COUNT; _++)
                {
                    floors[floorIndex] = new Floor
                    {
                        Id = ++floorIndex,
                        CorpsId = corpsId
                    };
                }
            }
            return floors;
        }

        /// <summary>
        /// Формирование набора комнат
        /// </summary>
        private Room[] PresetRooms()
        {
            //считаем общее кол-во комнат
            int roomsCount = (PRESET_SINGLE_ROOM_COUNT +
                              PRESET_DOUBLE_ROOM_COUNT +
                              PRESET_FAMILY_ROOM_COUNT) * (PRESET_CORPS_COUNT * PRESET_FLOORS_COUNT);

            Room[] rooms = new Room[roomsCount];
            int roomIndex = 0;
            for (int floorId = 1; floorId <= (PRESET_CORPS_COUNT * PRESET_FLOORS_COUNT); floorId++)
            {
                //однокомнатные
                for (int _ = 0; _ < PRESET_SINGLE_ROOM_COUNT; _++)
                {
                    rooms[roomIndex] = new Room
                    {
                        Id = ++roomIndex,
                        FloorId = floorId,
                        Type = Models.Enums.RoomType.Single
                    };
                }
                //двухкомнатные
                for (int _ = 0; _ < PRESET_DOUBLE_ROOM_COUNT; _++)
                {
                    rooms[roomIndex] = new Room
                    {
                        Id = ++roomIndex,
                        FloorId = floorId,
                        Type = Models.Enums.RoomType.Double
                    };
                }
                //семейные
                for (int _ = 0; _ < PRESET_FAMILY_ROOM_COUNT; _++)
                {
                    rooms[roomIndex] = new Room
                    {
                        Id = ++roomIndex,
                        FloorId = floorId,
                        Type = Models.Enums.RoomType.Family
                    };
                }
            }

            return rooms;
        }
    }
}
