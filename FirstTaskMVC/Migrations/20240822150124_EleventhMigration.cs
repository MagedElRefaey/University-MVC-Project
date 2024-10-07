using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstTaskMVC.Migrations
{
    /// <inheritdoc />
    public partial class EleventhMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Role_RolesRoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_RolesUserId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "RolesUserId",
                table: "RoleUser",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "RolesRoleId",
                table: "RoleUser",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_RolesUserId",
                table: "RoleUser",
                newName: "IX_RoleUser_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Role_RoleId",
                table: "RoleUser",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_UserId",
                table: "RoleUser",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Role_RoleId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_User_UserId",
                table: "RoleUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RoleUser",
                newName: "RolesUserId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "RoleUser",
                newName: "RolesRoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                newName: "IX_RoleUser_RolesUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Role_RolesRoleId",
                table: "RoleUser",
                column: "RolesRoleId",
                principalTable: "Role",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_User_RolesUserId",
                table: "RoleUser",
                column: "RolesUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
