using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Chat5.Migrations
{
    /// <inheritdoc />
    public partial class addne1w : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Conversations",
                columns: table => new
                {
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conversations", x => x.ConversationId);
                });

            migrationBuilder.CreateTable(
                name: "GroupMembers",
                columns: table => new
                {
                    GroupMemberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JoinTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeftTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMembers", x => x.GroupMemberId);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMembers_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SentDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "ConversationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "FirstName", "LastName", "Number", "UserId" },
                values: new object[,]
                {
                    { new Guid("4641435b-150f-4119-be3d-79ac6f5dbb89"), "Rafał", "NN", null, new Guid("b90f513d-5b7a-43bc-7e3d-08dc3dd09d7f") },
                    { new Guid("a5610a23-0b7c-4790-852a-c411edaa5db1"), "Darek", "Nieara", null, new Guid("6dfc52b2-3a59-4ed9-f302-08dc41c91e0b") }
                });

            migrationBuilder.InsertData(
                table: "Conversations",
                columns: new[] { "ConversationId", "ConversationName" },
                values: new object[,]
                {
                    { new Guid("0620fc74-3645-404e-93cf-cb0673453342"), "Testowe 3343" },
                    { new Guid("0620fc74-3645-404e-93cf-cb0673453349"), "Testowe2" }
                });

            migrationBuilder.InsertData(
                table: "GroupMembers",
                columns: new[] { "GroupMemberId", "ContactId", "ConversationId", "JoinTime", "LeftTime" },
                values: new object[,]
                {
                    { new Guid("a547818e-894f-46ab-a9ca-191cea5d25f7"), new Guid("a5610a23-0b7c-4790-852a-c411edaa5db1"), new Guid("0620fc74-3645-404e-93cf-cb0673453349"), new DateTime(2024, 3, 28, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9447), new DateTime(2024, 3, 28, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9449) },
                    { new Guid("d5b19dcb-dca9-4cbf-b6f0-7d541db0da12"), new Guid("4641435b-150f-4119-be3d-79ac6f5dbb89"), new Guid("0620fc74-3645-404e-93cf-cb0673453349"), new DateTime(2024, 3, 28, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9382), new DateTime(2024, 3, 27, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9431) },
                    { new Guid("d5b19dcb-dca9-4cbf-b6f0-7d541db0da26"), new Guid("4641435b-150f-4119-be3d-79ac6f5dbb89"), new Guid("0620fc74-3645-404e-93cf-cb0673453349"), new DateTime(2024, 3, 28, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9441), new DateTime(2024, 3, 27, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9442) }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "ConversationId", "From", "Name", "SentDateTime", "Text" },
                values: new object[,]
                {
                    { new Guid("1ea1d5af-d77f-4594-b7d4-0fe0785521ce"), new Guid("0620fc74-3645-404e-93cf-cb0673453349"), new Guid("4641435b-150f-4119-be3d-79ac6f5dbb89"), null, new DateTime(2024, 3, 28, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9456), "test sdajdfskjfdsjfdskl" },
                    { new Guid("9ce32327-e691-4cc5-8355-97f8caf41a4c"), new Guid("0620fc74-3645-404e-93cf-cb0673453349"), new Guid("a5610a23-0b7c-4790-852a-c411edaa5db1"), null, new DateTime(2024, 3, 28, 14, 2, 36, 892, DateTimeKind.Local).AddTicks(9460), "test dfgfdg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_ContactId",
                table: "GroupMembers",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMembers_ConversationId",
                table: "GroupMembers",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ConversationId",
                table: "Messages",
                column: "ConversationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMembers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Conversations");
        }
    }
}
