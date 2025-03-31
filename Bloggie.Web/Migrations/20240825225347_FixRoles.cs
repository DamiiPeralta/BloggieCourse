using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bloggie.Web.Migrations
{
    /// <inheritdoc />
    public partial class FixRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "2d367981-76e3-4bed-bcd2-89b36c2432d6", "7b9216e5-1a04-448d-8f6d-57fbd8d51f64" },
                    { "a45c9189-9704-4b1a-b315-26c2f1eaf893", "7b9216e5-1a04-448d-8f6d-57fbd8d51f64" },
                    { "b52d1f09-c02e-43b0-adf3-85a9eec1103f", "7b9216e5-1a04-448d-8f6d-57fbd8d51f64" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b9216e5-1a04-448d-8f6d-57fbd8d51f64",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d631b1c-64d4-4d91-bfa6-7e477a02fbd2", "AQAAAAIAAYagAAAAECO37LoWKmBn2GUZC+BpF0F0+bTf9M62JGOIwX/zCUV24tQuTjawZSILM2HzUp6zwA==", "291f0f9d-7bcb-4099-991b-f1585a3b9feb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2d367981-76e3-4bed-bcd2-89b36c2432d6", "7b9216e5-1a04-448d-8f6d-57fbd8d51f64" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a45c9189-9704-4b1a-b315-26c2f1eaf893", "7b9216e5-1a04-448d-8f6d-57fbd8d51f64" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b52d1f09-c02e-43b0-adf3-85a9eec1103f", "7b9216e5-1a04-448d-8f6d-57fbd8d51f64" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b9216e5-1a04-448d-8f6d-57fbd8d51f64",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b04f77b-ea4e-41cb-a8f9-63b311afbc14", "AQAAAAIAAYagAAAAEHUA17Yx6TKgTC/uClhWUs/P4MmZ0MptU6Ex7pZgryxPlRghsk9KejNvD9pDTVpf/w==", "5f2d842b-f6a4-473d-8e8a-838dd421fbc8" });
        }
    }
}
