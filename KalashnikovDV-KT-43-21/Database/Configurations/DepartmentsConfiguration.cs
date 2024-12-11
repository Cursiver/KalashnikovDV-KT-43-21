using KalashnikovDV_KT_43_21.Database.Helpers;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace KalashnikovDV_KT_43_21.Database.Configurations
{
    public class DepartmentsConfiguration : IEntityTypeConfiguration<Departments>
    {
        private const string TableName = "cd_department";
        public void Configure(EntityTypeBuilder<Departments> builder)
        {
            //задаём первичный ключ
            builder
                .HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_department_id")
                ;

            //для целочисленного первичного ключа задаём автогенерацию (id ++)
            builder.Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а также их обязательность и т.д.
            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);
        }
    }
}
