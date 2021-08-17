using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class kanban_v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "bitFavorito",
                table: "tblTarefa",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bitFavorito",
                table: "tblTarefa");
        }
    }
}
