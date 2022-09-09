using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewGains.DataAccess.Migrations
{
    public partial class SeedingSomeInstructions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions");

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Instructions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Instructions",
                columns: new[] { "Id", "ExerciseId", "StepNumber", "Text" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lie flat on the bench holding the barbell with a shoulder width pronated grip." },
                    { 2, 1, 2, "Retract scapula and have elbows between 45 to 90 degree angle.\r\n						 Try to tuck the shoulders down into their sockets and driven back." },
                    { 3, 1, 3, "Lift bar from the rack and hold above the chest with arms extended." },
                    { 4, 1, 4, "Breathe in and lower bar to the middle chest." },
                    { 5, 1, 5, "After pausing at the bottom, push the bar towards the starting position squeezing the chest." },
                    { 6, 1, 6, "Repeat for reps" },
                    { 7, 2, 1, "Hold the pull up bar with a neutral grip with arms fully extended." },
                    { 8, 2, 2, "Retract scapula and pull upward by bringing chest to the bar." },
                    { 9, 2, 3, "Pause at the top and squeeze the back before lowering slowly to the starting position." },
                    { 10, 2, 4, "Repeat for reps" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions");

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Instructions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<int>(
                name: "ExerciseId",
                table: "Instructions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructions_Exercises_ExerciseId",
                table: "Instructions",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id");
        }
    }
}
