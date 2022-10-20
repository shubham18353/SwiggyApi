using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwiggyApi.Migrations
{
    public partial class SwiggyDb3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_registers",
                table: "registers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "registers");

            migrationBuilder.RenameColumn(
                name: "UsernameOrEmail",
                table: "Logins",
                newName: "Username");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "registers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registers",
                table: "registers",
                columns: new[] { "Username", "Password" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_registers",
                table: "registers");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Logins",
                newName: "UsernameOrEmail");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "registers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "registers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registers",
                table: "registers",
                column: "UserId");
        }
    }
}
