using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chat_Database.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUsers");

            migrationBuilder.CreateTable(
                name: "ChatEntityUserEntity",
                columns: table => new
                {
                    chatsid = table.Column<int>(type: "int", nullable: false),
                    usersid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatEntityUserEntity", x => new { x.chatsid, x.usersid });
                    table.ForeignKey(
                        name: "FK_ChatEntityUserEntity_Chats_chatsid",
                        column: x => x.chatsid,
                        principalTable: "Chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatEntityUserEntity_Users_usersid",
                        column: x => x.usersid,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatEntityUserEntity_usersid",
                table: "ChatEntityUserEntity",
                column: "usersid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatEntityUserEntity");

            migrationBuilder.CreateTable(
                name: "ChatUsers",
                columns: table => new
                {
                    chatId = table.Column<int>(type: "int", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUsers", x => new { x.chatId, x.userId });
                    table.ForeignKey(
                        name: "FK_ChatUsers_Chats_chatId",
                        column: x => x.chatId,
                        principalTable: "Chats",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatUsers_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatUsers_userId",
                table: "ChatUsers",
                column: "userId");
        }
    }
}
