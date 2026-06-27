using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.DAL.Context.Migrations
{
    /// <inheritdoc />
    public partial class Added_Relationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrainerId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "HealthRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    IsAttended = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Membership_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Membership_Plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CategoryId",
                table: "Sessions",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TrainerId",
                table: "Sessions",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthRecords_MemberId",
                table: "HealthRecords",
                column: "MemberId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_MemberId",
                table: "Booking",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SessionId",
                table: "Booking",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_MemberId",
                table: "Membership",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Membership_PlanId",
                table: "Membership",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthRecords_Members_MemberId",
                table: "HealthRecords",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Categories_CategoryId",
                table: "Sessions",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Trainers_TrainerId",
                table: "Sessions",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthRecords_Members_MemberId",
                table: "HealthRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Categories_CategoryId",
                table: "Sessions");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Trainers_TrainerId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CategoryId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_TrainerId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_HealthRecords_MemberId",
                table: "HealthRecords");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TrainerId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "HealthRecords");
        }
    }
}
