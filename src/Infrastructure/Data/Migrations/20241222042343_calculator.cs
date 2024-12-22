using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo_app.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CalculatorItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Value1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Value2 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Result = table.Column<decimal>(type: "TEXT", nullable: false),
                    Operation = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationItems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationItems");
        }
    }
}
