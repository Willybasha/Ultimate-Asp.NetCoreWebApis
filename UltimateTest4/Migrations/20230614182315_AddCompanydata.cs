using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UltimateTest4.Migrations
{
    public partial class AddCompanydata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "CompanyId", "Address", "Country", "Name" },
                values: new object[] { 3, "217 Elgiesh_St", "Egypt", "yalla belslamat" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "CompanyId",
                keyValue: 3);
        }
    }
}
