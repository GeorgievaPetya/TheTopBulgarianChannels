using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTopBulgarianChannels.Migrations
{
    public partial class CreateTikTokTwitterFacebook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facebook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Followers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facebook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TikTok",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Followers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TikTok", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Twitter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Followers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Twitter", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facebook");

            migrationBuilder.DropTable(
                name: "TikTok");

            migrationBuilder.DropTable(
                name: "Twitter");
        }
    }
}
