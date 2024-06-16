using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHangHoaMaCT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaCT",
                table: "HangHoa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SoLuotMua",
                table: "HangHoa",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaCT",
                table: "HangHoa");

            migrationBuilder.DropColumn(
                name: "SoLuotMua",
                table: "HangHoa");
        }
    }
}
