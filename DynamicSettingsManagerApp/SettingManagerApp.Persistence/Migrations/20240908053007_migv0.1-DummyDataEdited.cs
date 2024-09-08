using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SettingManagerApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class migv01DummyDataEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationName",
                value: "SERVICE-PRODUCT");

            migrationBuilder.UpdateData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationName",
                value: "SERVICE-PRODUCT");

            migrationBuilder.UpdateData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplicationName", "IsActive" },
                values: new object[] { "SERVICE-OTHER", true });

            migrationBuilder.InsertData(
                table: "AppConfigurations",
                columns: new[] { "Id", "ApplicationName", "IsActive", "Name", "Type", "Value" },
                values: new object[,]
                {
                    { 4, "SERVICE-PRODUCT", false, "Template", "string", "dark" },
                    { 5, "SERVICE-PRODUCT", true, "MaxProductCount", "int", "5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationName",
                value: "SERVICE-A");

            migrationBuilder.UpdateData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 2,
                column: "ApplicationName",
                value: "SERVICE-B");

            migrationBuilder.UpdateData(
                table: "AppConfigurations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplicationName", "IsActive" },
                values: new object[] { "SERVICE-A", false });
        }
    }
}
