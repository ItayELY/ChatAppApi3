using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatAppMVC.Migrations
{
    public partial class add_userid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_Userid",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "Userid",
                table: "Contact",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_Userid",
                table: "Contact",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_Userid",
                table: "Contact");

            migrationBuilder.AlterColumn<string>(
                name: "Userid",
                table: "Contact",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_Userid",
                table: "Contact",
                column: "Userid",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
