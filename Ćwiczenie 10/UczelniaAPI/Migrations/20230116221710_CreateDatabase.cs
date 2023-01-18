using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UczelniaAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studies",
                columns: table => new
                {
                    IdStudia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tryb = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studies", x => x.IdStudia);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IdStudent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NrIndeksu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RokStudiow = table.Column<int>(type: "int", nullable: false),
                    IdStudia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IdStudent);
                    table.ForeignKey(
                        name: "FK_Students_Studies_IdStudia",
                        column: x => x.IdStudia,
                        principalTable: "Studies",
                        principalColumn: "IdStudia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Studies",
                columns: new[] { "IdStudia", "Nazwa", "Tryb" },
                values: new object[,]
                {
                    { 1, "Informatyka", "Stacjonarny" },
                    { 2, "Ekonomia", "Niestacjonarny" },
                    { 3, "Zarządzanie", "Stacjonarny" },
                    { 4, "Prawo", "Niestacjonarny" },
                    { 5, "Architektura", "Stacjonarny" },
                    { 6, "Mechanika", "Niestacjonarny" },
                    { 7, "Fizyka", "Stacjonarny" },
                    { 8, "Matematyka", "Niestacjonarny" },
                    { 9, "Chemia", "Stacjonarny" },
                    { 10, "Biologia", "Niestacjonarny" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "IdStudent", "IdStudia", "Imie", "Nazwisko", "NrIndeksu", "RokStudiow" },
                values: new object[,]
                {
                    { 1, 1, "Anna", "Kowalska", "A001", 3 },
                    { 2, 1, "Jan", "Nowak", "A002", 2 },
                    { 3, 2, "Katarzyna", "Wiśniewska", "A003", 4 },
                    { 4, 2, "Piotr", "Wojtyła", "A004", 1 },
                    { 5, 3, "Agnieszka", "Kowalczyk", "A005", 3 },
                    { 6, 3, "Adam", "Majewski", "A006", 2 },
                    { 7, 4, "Ewa", "Kozłowska", "A007", 4 },
                    { 8, 4, "Tomasz", "Jabłoński", "A008", 1 },
                    { 9, 5, "Magdalena", "Wróbel", "A009", 3 },
                    { 10, 5, "Dariusz", "Kaczmarek", "A010", 2 },
                    { 11, 5, "Adam", "Szczepanowski", "A011", 1 },
                    { 12, 7, "Ewa", "Kowalska", "A012", 2 },
                    { 13, 7, "Jan", "Nowak", "A013", 3 },
                    { 14, 7, "Anna", "Kowalska", "A014", 4 },
                    { 15, 8, "Katarzyna", "Wiśniewska", "A015", 5 },
                    { 16, 9, "Piotr", "Wojtyła", "A016", 1 },
                    { 17, 9, "Agnieszka", "Kowalczyk", "A017", 2 },
                    { 18, 9, "Adam", "Majewski", "A018", 3 },
                    { 19, 10, "Ewa", "Kozłowska", "A019", 4 },
                    { 20, 10, "Tomasz", "Jabłoński", "A020", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_IdStudia",
                table: "Students",
                column: "IdStudia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Studies");
        }
    }
}
