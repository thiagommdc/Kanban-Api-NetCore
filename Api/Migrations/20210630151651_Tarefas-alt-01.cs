using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class Tarefasalt01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TastblTarefak_tblUsuario_tblUsuariointUsuarioID",
                table: "TastblTarefak");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TastblTarefak",
                table: "TastblTarefak");

            migrationBuilder.RenameTable(
                name: "TastblTarefak",
                newName: "tblTarefa");

            migrationBuilder.RenameIndex(
                name: "IX_TastblTarefak_tblUsuariointUsuarioID",
                table: "tblTarefa",
                newName: "IX_tblTarefa_tblUsuariointUsuarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblTarefa",
                table: "tblTarefa",
                column: "intTarefaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTarefa_tblUsuario_tblUsuariointUsuarioID",
                table: "tblTarefa",
                column: "tblUsuariointUsuarioID",
                principalTable: "tblUsuario",
                principalColumn: "intUsuarioID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTarefa_tblUsuario_tblUsuariointUsuarioID",
                table: "tblTarefa");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblTarefa",
                table: "tblTarefa");

            migrationBuilder.RenameTable(
                name: "tblTarefa",
                newName: "TastblTarefak");

            migrationBuilder.RenameIndex(
                name: "IX_tblTarefa_tblUsuariointUsuarioID",
                table: "TastblTarefak",
                newName: "IX_TastblTarefak_tblUsuariointUsuarioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TastblTarefak",
                table: "TastblTarefak",
                column: "intTarefaID");

            migrationBuilder.AddForeignKey(
                name: "FK_TastblTarefak_tblUsuario_tblUsuariointUsuarioID",
                table: "TastblTarefak",
                column: "tblUsuariointUsuarioID",
                principalTable: "tblUsuario",
                principalColumn: "intUsuarioID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
