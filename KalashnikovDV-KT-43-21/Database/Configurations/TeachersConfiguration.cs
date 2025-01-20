using KalashnikovDV_KT_43_21.Database.Helpers;
using KalashnikovDV_KT_43_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;

namespace KalashnikovDV_KT_43_21.Database.Configurations
{
    public class TeachersConfiguration : IEntityTypeConfiguration<Teachers>
    {
        private const string TableName = "cd_teachers";

        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(p => p.TeacherId)
                .HasName($"pk_{TableName}_teacher_id");

            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_teacher_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.SecondName)
                .IsRequired()
                .HasColumnName("c_teacher_secondname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.LastName)
                .HasColumnName("c_teacher_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.DisciplineID)
                .IsRequired()
                .HasColumnName("c_teacher_discipline_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор дисциплины");

            builder.ToTable(TableName)
                .HasOne(p => p.Disciplines)
                .WithMany()
                .HasForeignKey(p => p.DisciplineID)
                .HasConstraintName("fk_f_discipline_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable(TableName)
                .HasIndex(p => p.DisciplineID, $"idx_{TableName}_fk_f_discipline_id");

            builder.Navigation(p => p.Disciplines)
                .AutoInclude();
        }
    }
}