using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendFungi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PublishDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Articles_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mushrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    SynonymousName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RedBook = table.Column<bool>(type: "boolean", nullable: false),
                    Eatable = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    HasStem = table.Column<bool>(type: "boolean", nullable: false),
                    StemSizeFrom = table.Column<int>(type: "integer", nullable: true),
                    StemSizeTo = table.Column<int>(type: "integer", nullable: true),
                    StemType = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    StemColor = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Mushrooms_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Roles_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParagraphText = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Paragraphs_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Paragraphs_ArticleId_fkey",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doppelgangers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MushroomId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoppelgangerName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doppelgangers_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Doppelgangers_MushroomId_fkey",
                        column: x => x.MushroomId,
                        principalTable: "Mushrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    PasswordHash = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Users_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Users_RoleId_fkey",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "fki_Doppelgangers_MushroomId_fkey",
                table: "Doppelgangers",
                column: "MushroomId");

            migrationBuilder.CreateIndex(
                name: "fki_Paragraphs_ArticleId_fkey",
                table: "Paragraphs",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "fki_Users_RoleId_fkey",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doppelgangers");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Mushrooms");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
