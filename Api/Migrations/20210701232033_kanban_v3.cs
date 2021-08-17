using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Migrations
{
    public partial class kanban_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "intOrdem",
                table: "tblEtapa",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "intOrdem",
                table: "tblEtapa");
        }
    }
}
