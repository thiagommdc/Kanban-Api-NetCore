using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class kanban_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "txtSubtitulo",
                table: "tblTarefa",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "txtSubtitulo",
                table: "tblTarefa");
        }
    }
}
