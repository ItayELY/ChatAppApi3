using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatAppAPIForReal.Migrations
{
    public partial class added_contact_key2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Contacts",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");


            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ContactKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        

            migrationBuilder.DropColumn(
                name: "ContactKey",
                table: "Contacts");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: null,
                column: "Id",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Contacts",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");
        }
    }
}
