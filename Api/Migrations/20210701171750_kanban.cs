using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class kanban : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "intEtapaID",
                table: "tblTarefa",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tblEtapaintEtapaID",
                table: "tblTarefa",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblEtapa",
                columns: table => new
                {
                    intEtapaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    txtNome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEtapa", x => x.intEtapaID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblTarefa_tblEtapa_tblEtapaintEtapaID",
                table: "tblTarefa");

            migrationBuilder.DropTable(
                name: "tblEtapa");

            migrationBuilder.DropIndex(
                name: "IX_tblTarefa_tblEtapaintEtapaID",
                table: "tblTarefa");

            migrationBuilder.DropColumn(
                name: "intEtapaID",
                table: "tblTarefa");

            migrationBuilder.DropColumn(
                name: "tblEtapaintEtapaID",
                table: "tblTarefa");
        }
    }
}
