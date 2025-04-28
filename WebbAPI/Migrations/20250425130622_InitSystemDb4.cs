using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebbAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitSystemDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 3, 1 });
        }
    }
}
