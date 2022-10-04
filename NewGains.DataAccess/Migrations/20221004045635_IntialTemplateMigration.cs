using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewGains.DataAccess.Migrations
{
    public partial class IntialTemplateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Instructions",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemplateSetGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetGroupNumber = table.Column<int>(type: "int", nullable: false),
                    TemplateId = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateSetGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateSetGroups_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TemplateSetGroups_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemplateSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    SetGroupId = table.Column<int>(type: "int", nullable: false),
                    PercentIntensity = table.Column<double>(type: "float", nullable: true),
                    WeightInPounds = table.Column<double>(type: "float", nullable: true),
                    TimeInSeconds = table.Column<int>(type: "int", nullable: true),
                    Reps = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemplateSets_Exercises_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TemplateSets_TemplateSetGroups_SetGroupId",
                        column: x => x.SetGroupId,
                        principalTable: "TemplateSetGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, null, "Push" });

            migrationBuilder.InsertData(
                table: "TemplateSetGroups",
                columns: new[] { "Id", "ExerciseId", "Note", "SetGroupNumber", "TemplateId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, 1 },
                    { 2, 2, null, 2, 1 },
                    { 3, 4, null, 3, 1 },
                    { 4, 3, null, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "TemplateSets",
                columns: new[] { "Id", "ExerciseId", "PercentIntensity", "Reps", "SetGroupId", "SetNumber", "TimeInSeconds", "WeightInPounds" },
                values: new object[,]
                {
                    { 1, 1, null, null, 1, 1, null, null },
                    { 2, 2, null, null, 2, 1, null, null },
                    { 3, 4, null, null, 3, 1, null, null },
                    { 4, 3, null, null, 4, 1, null, null },
                    { 5, 1, null, null, 1, 2, null, null },
                    { 6, 2, null, null, 2, 2, null, null },
                    { 7, 4, null, null, 3, 2, null, null },
                    { 8, 3, null, null, 4, 2, null, null },
                    { 9, 1, null, null, 1, 3, null, null },
                    { 10, 2, null, null, 2, 3, null, null },
                    { 11, 4, null, null, 3, 3, null, null },
                    { 12, 3, null, null, 4, 3, null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TemplateSetGroups_ExerciseId",
                table: "TemplateSetGroups",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateSetGroups_TemplateId",
                table: "TemplateSetGroups",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateSets_ExerciseId",
                table: "TemplateSets",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_TemplateSets_SetGroupId",
                table: "TemplateSets",
                column: "SetGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateSets");

            migrationBuilder.DropTable(
                name: "TemplateSetGroups");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Instructions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
