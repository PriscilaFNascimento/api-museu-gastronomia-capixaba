using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Sobrenome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SenhaHash = table.Column<string>(type: "text", nullable: false),
                    UriFotoPerfil = table.Column<string>(type: "text", nullable: false),
                    Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Desativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    UriImagem = table.Column<string>(type: "text", nullable: true),
                    Ingredientes = table.Column<string>(type: "character varying(1500)", maxLength: 1500, nullable: false),
                    ModoPreparo = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                    Historia = table.Column<string>(type: "character varying(3000)", maxLength: 3000, nullable: false),
                    Porcao = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PorcoesReceita = table.Column<int>(type: "integer", nullable: false),
                    CriadorId = table.Column<Guid>(type: "uuid", nullable: false),
                    UltimoEditorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Desativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receitas_Usuarios_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receitas_Usuarios_UltimoEditorId",
                        column: x => x.UltimoEditorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Conteudo = table.Column<string>(type: "text", nullable: false),
                    ComentaristaId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Desativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_ComentaristaId",
                        column: x => x.ComentaristaId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformacoesNutricionais",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    QuantidadePorcao = table.Column<decimal>(type: "numeric(6,3)", nullable: false),
                    ValorDiario = table.Column<decimal>(type: "numeric(6,3)", nullable: false),
                    ReceitaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Registro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Atualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Desativacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacoesNutricionais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformacoesNutricionais_Receitas_ReceitaId",
                        column: x => x.ReceitaId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ComentaristaId",
                table: "Comentarios",
                column: "ComentaristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ReceitaId",
                table: "Comentarios",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_InformacoesNutricionais_ReceitaId",
                table: "InformacoesNutricionais",
                column: "ReceitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_CriadorId",
                table: "Receitas",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Receitas_UltimoEditorId",
                table: "Receitas",
                column: "UltimoEditorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "InformacoesNutricionais");

            migrationBuilder.DropTable(
                name: "Receitas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
