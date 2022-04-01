using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpaceBank.Microservices.Media.Infrastructure.Data.Migrations
{
    public partial class Third_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Videos",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreayedBy",
                table: "Videos",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "VideoActors",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreayedBy",
                table: "VideoActors",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Streamers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreayedBy",
                table: "Streamers",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Directors",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreayedBy",
                table: "Directors",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Actors",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CreayedBy",
                table: "Actors",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<int>(
                name: "DirectorId",
                table: "Videos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Videos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "VideoActors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "VideoActors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VideoId",
                table: "VideoActors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Streamers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Directors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Actors",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IsActive",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "VideoActors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "VideoActors");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "VideoActors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Streamers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "VideoId",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Videos",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Videos",
                newName: "CreayedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "VideoActors",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "VideoActors",
                newName: "CreayedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Streamers",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Streamers",
                newName: "CreayedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Directors",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Directors",
                newName: "CreayedBy");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Actors",
                newName: "DateCreated");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Actors",
                newName: "CreayedBy");
        }
    }
}
