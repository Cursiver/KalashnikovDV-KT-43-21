using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KalashnikovDV_KT_43_21.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_disciplines",
                columns: table => new
                {
                    discipline_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи дисциплины")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    c_teacher_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_disciplines_department_id", x => x.discipline_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_teachers",
                columns: table => new
                {
                    teacher_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    c_teacher_firstname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_teacher_secondname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_teacher_lastname = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Отчество преподавателя")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_teachers_teacher_id", x => x.teacher_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_department",
                columns: table => new
                {
                    department_id = table.Column<int>(type: "integer", nullable: false, comment: "Идентификатор записи кафедры"),
                    c_department_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false),
                    c_headteacher_id = table.Column<int>(type: "int4", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_department_department_id", x => x.department_id);
                    table.ForeignKey(
                        name: "fk_f_department_id",
                        column: x => x.department_id,
                        principalTable: "cd_disciplines",
                        principalColumn: "discipline_id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "fk_f_headteacher_id",
                        column: x => x.c_headteacher_id,
                        principalTable: "cd_teachers",
                        principalColumn: "teacher_id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "idx_cd_department_fk_f_headteacher_id",
                table: "cd_department",
                column: "c_headteacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_department_c_headteacher_id",
                table: "cd_department",
                column: "c_headteacher_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_cd_disciplines_fk_f_department_id",
                table: "cd_disciplines",
                column: "c_teacher_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_department");

            migrationBuilder.DropTable(
                name: "cd_disciplines");

            migrationBuilder.DropTable(
                name: "cd_teachers");
        }
    }
}
