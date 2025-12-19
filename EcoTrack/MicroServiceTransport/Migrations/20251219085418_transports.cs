using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MicroServiceTransport.Migrations
{
    /// <inheritdoc />
    public partial class transports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FacteurEmission",
                table: "Transports");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "FacteurEmission",
                table: "Transports",
                type: "float",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
