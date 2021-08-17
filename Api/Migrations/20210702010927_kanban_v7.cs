using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class kanban_v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTarefa_tblUsuario_tblUsuariointUsuarioID",
                table: "tblTarefa");

            migrationBuilder.DropIndex(
                name: "IX_tblTarefa_tblUsuariointUsuarioID",
                table: "tblTarefa");

            migrationBuilder.DropColumn(
                name: "tblUsuariointUsuarioID",
                table: "tblTarefa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tblUsuariointUsuarioID",
                table: "tblTarefa",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblTarefa_tblUsuariointUsuarioID",
                table: "tblTarefa",
                column: "tblUsuariointUsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTarefa_tblUsuario_tblUsuariointUsuarioID",
                table: "tblTarefa",
                column: "tblUsuariointUsuarioID",
                principalTable: "tblUsuario",
                principalColumn: "intUsuarioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
