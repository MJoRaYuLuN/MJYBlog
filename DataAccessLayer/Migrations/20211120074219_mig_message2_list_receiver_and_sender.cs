using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_message2_list_receiver_and_sender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message2s",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SenderID = table.Column<int>(type: "int", nullable: true),
                    ReceiverID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessageDetails = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MessageDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MessageStatus = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message2s", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_ReceiverID",
                        column: x => x.ReceiverID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_SenderID",
                        column: x => x.SenderID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_ReceiverID",
                table: "Message2s",
                column: "ReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_SenderID",
                table: "Message2s",
                column: "SenderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message2s");
        }
    }
}
