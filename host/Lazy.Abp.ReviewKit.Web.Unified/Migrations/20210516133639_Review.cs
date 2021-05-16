using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lazy.Abp.ReviewKit.Migrations
{
    public partial class Review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReviewKitReviewLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLike = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewKitReviewLikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewKitReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    SubjectId = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RootId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LikeCount = table.Column<int>(type: "int", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AuditRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewKitReviews", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewKitReviewLikes_ReviewId_UserId",
                table: "ReviewKitReviewLikes",
                columns: new[] { "ReviewId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewKitReviews_ModuleName_SubjectId",
                table: "ReviewKitReviews",
                columns: new[] { "ModuleName", "SubjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReviewKitReviews_ParentId",
                table: "ReviewKitReviews",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReviewKitReviews_RootId",
                table: "ReviewKitReviews",
                column: "RootId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReviewKitReviewLikes");

            migrationBuilder.DropTable(
                name: "ReviewKitReviews");
        }
    }
}
