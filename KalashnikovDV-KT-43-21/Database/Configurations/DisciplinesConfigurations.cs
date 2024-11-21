using KalashnikovDV_KT_43_21.Database.Helpers;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace KalashnikovDV_KT_43_21.Database.Configurations
{
    public class DisciplinesConfigurations : IEntityTypeConfiguration<Disciplines>
    {
        private const string TableName = "cd_disciplines";
        public void Configure(EntityTypeBuilder<Disciplines> builder)
        {
            //задаём первичный ключ
            builder
                .HasKey(p => p.DisciplineId)
                .HasName($"pk_{TableName}_department_id")
                ;

            //для целочисленного первичного ключа задаём автогенерацию (id ++)
            builder.Property(p => p.DisciplineId)
                .ValueGeneratedOnAdd()
                //Расписываем как будут называться колонки в БД, а также их обязательность и т.д.
                .HasColumnName("discipline_id")
                .HasComment("Идентификатор записи дисциплины");

            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_department_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.DepartmentId)
                .IsRequired()
                .HasColumnName("c_teacher_id")
                .HasColumnType(ColumnType.Int);

            builder.ToTable(TableName)
                .HasOne(p => p.Department)
                .WithOne()
                .HasForeignKey<Department>(p => p.DepartmentId)
                .HasConstraintName("fk_f_department_id")
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable(TableName)
                .HasIndex(p => p.DepartmentId, $"idx_{TableName}_fk_f_department_id");

            builder.Navigation(p => p.Department)
                .AutoInclude();
            //public int DisciplineId { get; set; }
            //public str DisciplineName { get; set; } = string.Empty;
            //public int DepartmentId { get; set; } //Кафедра //дисциплин беск:1 кафедра
        }
    }
}