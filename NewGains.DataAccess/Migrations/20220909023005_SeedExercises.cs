using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewGains.DataAccess.Migrations
{
    public partial class SeedExercises : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Exercises",
                columns: new[] { "Id", "BodyPart", "Category", "Name" },
                values: new object[,]
                {
                    { 1, 2, 0, "Bench Press" },
                    { 2, 1, 3, "Pull Up" },
                    { 3, 4, 0, "Squat" },
                    { 4, 5, 0, "Over Head Press" },
                    { 5, 0, 1, "Curls" },
                    { 6, 4, 4, "Outdoor Running" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Exercises",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
