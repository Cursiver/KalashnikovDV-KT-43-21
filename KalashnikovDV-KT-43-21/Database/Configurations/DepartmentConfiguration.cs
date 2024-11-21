using KalashnikovDV_KT_43_21.Database.Helpers;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace KalashnikovDV_KT_43_21.Database.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        private const string TableName = "cd_department";
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            //задаём первичный ключ
            builder
                .HasKey(p => p.DepartmentId)
                .HasName($"pk_{TableName}_department_id")
                ;

            //для целочисленного первичного ключа задаём автогенерацию (id ++)
            builder .Property(p => p.DepartmentId)
                .ValueGeneratedOnAdd();

            //Расписываем как будут называться колонки в БД, а также их обязательность и т.д.
            builder.Property(p => p.DepartmentId)
                .HasColumnName("department_id")
                .HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.DepartmentName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.HeadTeacherID)
                .IsRequired()
                .HasColumnName("c_headteacher_id")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
                .HasOne(p => p.Teacher)
                .WithOne()
                .HasForeignKey<Department>(p => p.HeadTeacherID)
                .HasConstraintName("fk_f_headteacher_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasIndex(p => p.HeadTeacherID, $"idx_{TableName}_fk_f_headteacher_id");

            builder.Navigation(p => p.Teacher)
                .AutoInclude();
        }
    }
}
