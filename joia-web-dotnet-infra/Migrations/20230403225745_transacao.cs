using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace joia_web_dotnet_infra.Migrations
{
    /// <inheritdoc />
    public partial class transacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    nomeVendedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nomeComprador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "date", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacoes_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PecaTransacao",
                columns: table => new
                {
                    PecasId = table.Column<int>(type: "int", nullable: false),
                    TransacoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PecaTransacao", x => new { x.PecasId, x.TransacoesId });
                    table.ForeignKey(
                        name: "FK_PecaTransacao_Pecas_PecasId",
                        column: x => x.PecasId,
                        principalTable: "Pecas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PecaTransacao_Transacoes_TransacoesId",
                        column: x => x.TransacoesId,
                        principalTable: "Transacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PecaTransacao_TransacoesId",
                table: "PecaTransacao",
                column: "TransacoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacoes_AdministradorId",
                table: "Transacoes",
                column: "AdministradorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PecaTransacao");

            migrationBuilder.DropTable(
                name: "Transacoes");
        }
    }
}
