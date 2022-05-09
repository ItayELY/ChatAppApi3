using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatAppMVC.Migrations
{
    public partial class intify_Contactid_message : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message_Contact_Contactid",
                table: "Message");

            migrationBuilder.DropIndex(
                name: "IX_Message_Contactid",
                table: "Message");



            migrationBuilder.AlterColumn<int>(
                name: "Contactid",
                table: "Message",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

   
        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.AlterColumn<string>(
                name: "Contactid",
                table: "Message",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");


            migrationBuilder.CreateIndex(
                name: "IX_Message_Contactid",
                table: "Message",
                column: "Contactid");

            migrationBuilder.AddForeignKey(
                name: "FK_Message_Contact_Contactid",
                table: "Message",
                column: "Contactid",
                principalTable: "Contact",
                principalColumn: "id");
        }
    }
}
