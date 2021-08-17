using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Tarefas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblUsuario",
                columns: table => new
                {
                    intUsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    txtNome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUsuario", x => x.intUsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "TastblTarefak",
                columns: table => new
                {
                    intTarefaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    txtTitulo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    txtDescricao = table.Column<string>(type: "TEXT", nullable: false),
                    dteCadastro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    bitCompleto = table.Column<bool>(type: "INTEGER", nullable: false),
                    tblUsuariointUsuarioID = table.Column<int>(type: "INTEGER", nullable: true),
                    intUsuarioID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TastblTarefak", x => x.intTarefaID);
                    table.ForeignKey(
                        name: "FK_TastblTarefak_tblUsuario_tblUsuariointUsuarioID",
                        column: x => x.tblUsuariointUsuarioID,
                        principalTable: "tblUsuario",
                        principalColumn: "intUsuarioID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TastblTarefak_tblUsuariointUsuarioID",
                table: "TastblTarefak",
                column: "tblUsuariointUsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TastblTarefak");

            migrationBuilder.DropTable(
                name: "tblUsuario");
        }
    }
}
