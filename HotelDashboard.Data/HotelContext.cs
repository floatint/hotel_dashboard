using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HotelDashboard.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelDashboard.Data
{
    public class HotelContext : DbContext
    {
        public DbSet<Corps> Corps { set; get; }
        public DbSet<Floor> Floors { set; get; }
        public DbSet<Room> Rooms { set; get; }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Client>((e =>
            //{
            //    e.HasNoKey();
            //}));
        }
    }
}
