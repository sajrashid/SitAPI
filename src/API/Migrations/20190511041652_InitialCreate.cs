using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnetAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "API",
                columns: table => new
                {
                    APIId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_API", x => x.APIId);
                });

            migrationBuilder.CreateTable(
                name: "Verb",
                columns: table => new
                {
                    VerbId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Parameters = table.Column<string>(maxLength: 500, nullable: true),
                    APIId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verb", x => x.VerbId);
                    table.ForeignKey(
                        name: "FK_Verb_API_APIId",
                        column: x => x.APIId,
                        principalTable: "API",
                        principalColumn: "APIId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Verb_APIId",
                table: "Verb",
                column: "APIId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Verb");

            migrationBuilder.DropTable(
                name: "API");
        }
    }
}
