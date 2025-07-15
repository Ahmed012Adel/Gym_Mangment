using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GYMMAngment.Presistente.Migrations
{
    /// <inheritdoc />
    public partial class ubdateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGYMClasses_AspNetUsers_TrainerId",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGYMClasses_Classes_ClassesId",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.DropTable(
                name: "ApplicationUserGYMClasses1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserGYMClasses",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserGYMClasses_TrainerId",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.RenameColumn(
                name: "TrainerId",
                table: "ApplicationUserGYMClasses",
                newName: "MemberId");

            migrationBuilder.RenameColumn(
                name: "ClassesId",
                table: "ApplicationUserGYMClasses",
                newName: "MembersAttendId");

            migrationBuilder.AddColumn<string>(
                name: "TrainerId",
                table: "Classes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserGYMClasses",
                table: "ApplicationUserGYMClasses",
                columns: new[] { "MemberId", "MembersAttendId" });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TrainerId",
                table: "Classes",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGYMClasses_MembersAttendId",
                table: "ApplicationUserGYMClasses",
                column: "MembersAttendId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGYMClasses_AspNetUsers_MemberId",
                table: "ApplicationUserGYMClasses",
                column: "MemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGYMClasses_Classes_MembersAttendId",
                table: "ApplicationUserGYMClasses",
                column: "MembersAttendId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_TrainerId",
                table: "Classes",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGYMClasses_AspNetUsers_MemberId",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserGYMClasses_Classes_MembersAttendId",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_TrainerId",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Classes_TrainerId",
                table: "Classes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserGYMClasses",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserGYMClasses_MembersAttendId",
                table: "ApplicationUserGYMClasses");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Classes");

            migrationBuilder.RenameColumn(
                name: "MembersAttendId",
                table: "ApplicationUserGYMClasses",
                newName: "ClassesId");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "ApplicationUserGYMClasses",
                newName: "TrainerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserGYMClasses",
                table: "ApplicationUserGYMClasses",
                columns: new[] { "ClassesId", "TrainerId" });

            migrationBuilder.CreateTable(
                name: "ApplicationUserGYMClasses1",
                columns: table => new
                {
                    MemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MembersAttendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserGYMClasses1", x => new { x.MemberId, x.MembersAttendId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserGYMClasses1_AspNetUsers_MemberId",
                        column: x => x.MemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserGYMClasses1_Classes_MembersAttendId",
                        column: x => x.MembersAttendId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGYMClasses_TrainerId",
                table: "ApplicationUserGYMClasses",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserGYMClasses1_MembersAttendId",
                table: "ApplicationUserGYMClasses1",
                column: "MembersAttendId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGYMClasses_AspNetUsers_TrainerId",
                table: "ApplicationUserGYMClasses",
                column: "TrainerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserGYMClasses_Classes_ClassesId",
                table: "ApplicationUserGYMClasses",
                column: "ClassesId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
