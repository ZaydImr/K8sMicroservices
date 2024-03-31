using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "APPUSERID",
                table: "ASPNETROLES",
                type: "NVARCHAR2(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ASPNETROLES_APPUSERID",
                table: "ASPNETROLES",
                column: "APPUSERID");

            migrationBuilder.AddForeignKey(
                name: "FK_ASPNETROLES_ASPNETUSERS_APPUSERID",
                table: "ASPNETROLES",
                column: "APPUSERID",
                principalTable: "ASPNETUSERS",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ASPNETROLES_ASPNETUSERS_APPUSERID",
                table: "ASPNETROLES");

            migrationBuilder.DropIndex(
                name: "IX_ASPNETROLES_APPUSERID",
                table: "ASPNETROLES");

            migrationBuilder.DropColumn(
                name: "APPUSERID",
                table: "ASPNETROLES");
        }
    }
}
