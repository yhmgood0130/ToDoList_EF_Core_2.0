using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApp.Data.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoLists_Schedules_ScheduleId",
                table: "ToDoLists");

            migrationBuilder.DropIndex(
                name: "IX_ToDoLists_ScheduleId",
                table: "ToDoLists");

            migrationBuilder.DropColumn(
                name: "ScheduleId",
                table: "ToDoLists");

            migrationBuilder.CreateTable(
                name: "ScretIdentity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RealName = table.Column<string>(nullable: true),
                    ToDoListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScretIdentity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScretIdentity_ToDoLists_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ToDoListSchedule",
                columns: table => new
                {
                    ToDoListId = table.Column<int>(nullable: false),
                    ScheduleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListSchedule", x => new { x.ToDoListId, x.ScheduleId });
                    table.ForeignKey(
                        name: "FK_ToDoListSchedule_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ToDoListSchedule_ToDoLists_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScretIdentity_ToDoListId",
                table: "ScretIdentity",
                column: "ToDoListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListSchedule_ScheduleId",
                table: "ToDoListSchedule",
                column: "ScheduleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScretIdentity");

            migrationBuilder.DropTable(
                name: "ToDoListSchedule");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleId",
                table: "ToDoLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ToDoLists_ScheduleId",
                table: "ToDoLists",
                column: "ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoLists_Schedules_ScheduleId",
                table: "ToDoLists",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
