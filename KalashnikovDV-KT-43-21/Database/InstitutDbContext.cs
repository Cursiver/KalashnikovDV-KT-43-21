using KalashnikovDV_KT_43_21.Database.Configurations;
using KalashnikovDV_KT_43_21.Database.Helpers;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;

namespace KalashnikovDV_KT_43_21.Database
{
    public class InstitutDbContext : DbContext
    {
        //добавление таблиц
        DbSet<Departments> departments { get; set; }
        DbSet<Disciplines> disciplines { get; set; }
        DbSet<Teachers> teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new DepartmentsConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinesConfiguration());
            modelBuilder.ApplyConfiguration(new TeachersConfiguration());
        }

        public InstitutDbContext(DbContextOptions<InstitutDbContext> options) : base(options)
        {
        }
    }
}
