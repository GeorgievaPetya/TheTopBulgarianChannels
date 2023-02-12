using Microsoft.EntityFrameworkCore.Migrations;

namespace TheTopBulgarianChannels.Migrations
{
    public partial class AddColomnInTableYouTubeChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChannelHandel",
                table: "YouTubeChannels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelHandel",
                table: "YouTubeChannels");
        }
    }
}
