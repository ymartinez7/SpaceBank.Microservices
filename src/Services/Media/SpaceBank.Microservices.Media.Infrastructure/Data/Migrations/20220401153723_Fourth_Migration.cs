using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceBank.Microservices.Media.Infrastructure.Data.Migrations
{
    public partial class Fourth_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Videos_VideoId",
                table: "Actors");

            migrationBuilder.DropForeignKey(
                name: "FK_Videos_Directors_DirectorId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Videos_DirectorId",
                table: "Videos");

            migrationBuilder.DropIndex(
                name: "IX_Actors_VideoId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "DirectorId",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Directors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActorVideo",
                columns: table => new
                {
                    ActoresId = table.Column<int>(type: "int", nullable: false),
                    VideosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorVideo", x => new { x.ActoresId, x.VideosId });
                    table.ForeignKey(
                        name: "FK_ActorVideo_Actors_ActoresId",
                        column: x => x.ActoresId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorVideo_Videos_VideosId",
                        column: x => x.VideosId,
                        principalTable: "Videos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_VideoId",
                table: "Directors",
                column: "VideoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActorVideo_VideosId",
                table: "ActorVideo",
                column: "VideosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Videos_VideoId",
                table: "Directors",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Videos_VideoId",
                table: "Directors");

            migrationBuilder.DropTable(
                name: "ActorVideo");

            migrationBuilder.DropIndex(
                name: "IX_Directors_VideoId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Actors");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Videos_DirectorId",
                table: "Videos",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Actors_VideoId",
                table: "Actors",
                column: "VideoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Videos_VideoId",
                table: "Actors",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Videos_Directors_DirectorId",
                table: "Videos",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
