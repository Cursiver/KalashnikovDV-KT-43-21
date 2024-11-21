using KalashnikovDV_KT_43_21.Database.Configurations;
using KalashnikovDV_KT_43_21.Database.Helpers;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;

namespace KalashnikovDV_KT_43_21.Database
{
    public class InstitutDbContext : DbContext
    {
        //добавление таблиц
        DbSet<Department> departments {  get; set; }
        DbSet<Disciplines> disciplines {  get; set; }
        DbSet<Teachers> teachers {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplinesConfigurations());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }

        public InstitutDbContext(DbContextOptions<InstitutDbContext> options) : base(options)
        {
        }
    }
}
