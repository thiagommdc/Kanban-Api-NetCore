using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class kanban_v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTarefa_tblEtapa_tblEtapaintEtapaID",
                table: "tblTarefa");

            migrationBuilder.DropIndex(
                name: "IX_tblTarefa_tblEtapaintEtapaID",
                table: "tblTarefa");

            migrationBuilder.DropColumn(
                name: "tblEtapaintEtapaID",
                table: "tblTarefa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tblEtapaintEtapaID",
                table: "tblTarefa",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblTarefa_tblEtapaintEtapaID",
                table: "tblTarefa",
                column: "tblEtapaintEtapaID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblTarefa_tblEtapa_tblEtapaintEtapaID",
                table: "tblTarefa",
                column: "tblEtapaintEtapaID",
                principalTable: "tblEtapa",
                principalColumn: "intEtapaID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
