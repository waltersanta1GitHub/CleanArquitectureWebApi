using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegistredUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistredUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tutors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tutors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_RegistredUsers_Id",
                        column: x => x.Id,
                        principalTable: "RegistredUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    TutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "Tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SchoolClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolClasses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolClasses_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RegistredUsers",
                columns: new[] { "Id", "Email", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "usuariouno@school.com", true, "Admin" },
                    { 3, "usuariodos@school.com", false, "Usuario" },
                    { 4, "usuariotres@school.com", true, "Usuario" },
                    { 8, "usuariocuatro@school.com", false, "Invitado" },
                    { 9, "usuariocinco@school.com", true, "Invitado" },
                    { 10, "usuarioseis@school.com", false, "Invitado" },
                    { 11, "usuariosiete@school.com", true, "Invitado" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "TutorId" },
                values: new object[,]
                {
                    { 9, 30, "Maria Caro", null },
                    { 10, 28, "Jose Botella", null }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name", "Speciality" },
                values: new object[,]
                {
                    { 3, "Dr. Fernandez", "Matematica" },
                    { 4, "Prof. Gomez", "Lengua" }
                });

            migrationBuilder.InsertData(
                table: "Tutors",
                columns: new[] { "Id", "Description", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Madre", "Maria Parra", "+3469850245" },
                    { 2, "Tio", "Pedro Caro", "+3463750285" }
                });

            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "Id", "Period", "StudentId", "TeacherId", "Time" },
                values: new object[,]
                {
                    { 2, 0, 10, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 0, 9, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Age", "Name", "TutorId" },
                values: new object[,]
                {
                    { 8, 24, "Ricardo Parra", 1 },
                    { 11, 34, "Marcos Aguilar", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "AvatarUrl", "NickName" },
                values: new object[,]
                {
                    { 1, "https://ejemplo.com/avatar1.png", "Bathman01" },
                    { 3, "https://ejemplo.com/avatar2.png", "Simpson01" },
                    { 4, "https://ejemplo.com/avatar3.png", "WonderWoman2" },
                    { 8, "https://ejemplo.com/avatar4.png", "Catwoman01" },
                    { 9, "https://ejemplo.com/avatar5.png", "Phinias&Frebs" },
                    { 10, "https://ejemplo.com/avatar6.png", "TomyYDaly" },
                    { 11, "https://ejemplo.com/avatar7.png", "Harrypotter" }
                });

            migrationBuilder.InsertData(
                table: "SchoolClasses",
                columns: new[] { "Id", "Period", "StudentId", "TeacherId", "Time" },
                values: new object[,]
                {
                    { 1, 0, 8, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 0, 11, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_StudentId",
                table: "SchoolClasses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_TeacherId",
                table: "SchoolClasses",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TutorId",
                table: "Students",
                column: "TutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SchoolClasses");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "RegistredUsers");

            migrationBuilder.DropTable(
                name: "Tutors");
        }
    }
}
