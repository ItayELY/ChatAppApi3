using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatAppAPIForReal.Migrations
{
    public partial class changes_lastMessageContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastMessageContent",
                table: "Contacts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastMessageContent",
                table: "Contacts");
        }
    }
}
