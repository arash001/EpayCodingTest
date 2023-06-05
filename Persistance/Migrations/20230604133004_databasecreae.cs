using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class databasecreae : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PayoutCombinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayoutAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayoutCombinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Denominations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    PayoutCombinationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denominations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Denominations_PayoutCombinations_PayoutCombinationId",
                        column: x => x.PayoutCombinationId,
                        principalTable: "PayoutCombinations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Denominations_PayoutCombinationId",
                table: "Denominations",
                column: "PayoutCombinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Denominations");

            migrationBuilder.DropTable(
                name: "PayoutCombinations");
        }
    }
}
