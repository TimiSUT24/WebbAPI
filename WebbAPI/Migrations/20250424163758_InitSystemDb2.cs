using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebbAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitSystemDb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonInteres_PersonId_InterestId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInteres_Interests_InterestId",
                table: "PersonInteres");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInteres_Persons_PersonId",
                table: "PersonInteres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInteres",
                table: "PersonInteres");

            migrationBuilder.RenameTable(
                name: "PersonInteres",
                newName: "PersonInterests");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInteres_InterestId",
                table: "PersonInterests",
                newName: "IX_PersonInterests_InterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "Id", "Description", "Interest" },
                values: new object[,]
                {
                    { 1, "Writing and debugging code.", "Programming" },
                    { 2, "Capturing moments with a camera.", "Photography" },
                    { 3, "Making delicious meals.", "Cooking" },
                    { 4, "Playing video games competitively or for fun.", "Gaming" },
                    { 5, "Enjoying books and novels.", "Reading" },
                    { 6, "Listening to and creating music.", "Music" },
                    { 7, "Exploring new places and cultures.", "Traveling" },
                    { 8, "Staying active and healthy.", "Fitness" },
                    { 9, "Growing and taking care of plants.", "Gardening" },
                    { 10, "Exploring the latest in tech.", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Firstname", "Lastname", "Phone" },
                values: new object[,]
                {
                    { 1, "Alice", "Smith", "0701111111" },
                    { 2, "Bob", "Johnson", "0702222222" },
                    { 3, "Clara", "Williams", "0703333333" },
                    { 4, "David", "Brown", "0704444444" },
                    { 5, "Ella", "Jones", "0705555555" },
                    { 6, "Felix", "Garcia", "0706666666" },
                    { 7, "Grace", "Miller", "0707777777" },
                    { 8, "Harry", "Davis", "0708888888" },
                    { 9, "Isla", "Martinez", "0709999999" },
                    { 10, "Jack", "Taylor", "0701010101" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterests",
                columns: new[] { "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Links",
                columns: new[] { "Id", "InterestId", "Link", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, "https://dev.to/alice", 1 },
                    { 2, 2, "https://unsplash.com/bob", 2 },
                    { 3, 3, "https://recipes.com/clara", 3 },
                    { 4, 4, "https://twitch.tv/davidplays", 4 },
                    { 5, 5, "https://goodreads.com/ella", 5 },
                    { 6, 6, "https://soundcloud.com/felix", 6 },
                    { 7, 7, "https://travelblog.com/grace", 7 },
                    { 8, 8, "https://fitgram.com/harry", 8 },
                    { 9, 9, "https://gardenershub.com/isla", 9 },
                    { 10, 10, "https://techtrends.com/jack", 10 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_Interests_InterestId",
                table: "PersonInterests",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInterests_Persons_PersonId",
                table: "PersonInterests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_PersonInterests_PersonId_InterestId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_Interests_InterestId",
                table: "PersonInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonInterests_Persons_PersonId",
                table: "PersonInterests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonInterests",
                table: "PersonInterests");

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Links",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "PersonInterests",
                keyColumns: new[] { "InterestId", "PersonId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Interests",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "PersonInterests",
                newName: "PersonInteres");

            migrationBuilder.RenameIndex(
                name: "IX_PersonInterests_InterestId",
                table: "PersonInteres",
                newName: "IX_PersonInteres_InterestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonInteres",
                table: "PersonInteres",
                columns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Links_PersonInteres_PersonId_InterestId",
                table: "Links",
                columns: new[] { "PersonId", "InterestId" },
                principalTable: "PersonInteres",
                principalColumns: new[] { "PersonId", "InterestId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInteres_Interests_InterestId",
                table: "PersonInteres",
                column: "InterestId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonInteres_Persons_PersonId",
                table: "PersonInteres",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
