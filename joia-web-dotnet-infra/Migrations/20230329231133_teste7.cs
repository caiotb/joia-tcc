using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace joia_web_dotnet_infra.Migrations
{
    /// <inheritdoc />
    public partial class teste7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Pecas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Pecas");
        }
    }
}
