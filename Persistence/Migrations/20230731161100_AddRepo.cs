using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddRepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("51ceaded-1d9f-4222-9414-b226108ae3ed"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("5e60b86f-2694-4838-a7aa-7e1d16c3beb3"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("8bb31a9e-d6be-4bc6-857f-c753a08415dc"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("a0d782a5-62cf-49f2-8f03-6a85bf4b0350"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "About", "AvatarPath", "Name" },
                values: new object[,]
                {
                    { new Guid("1688cc79-6d02-4fb5-a83e-93dc6bf229de"), "", "/contents/", "Billie Eilish" },
                    { new Guid("884a2098-09e6-4eeb-bc1a-63e9fbb90414"), "", "/contents/", "Harry Style" },
                    { new Guid("bfcc171c-def2-4aeb-a3a1-5683d3d92ddb"), "", "/contents/", "Ariana Grande" },
                    { new Guid("bfdf22c7-1bde-4dfc-bcc2-f7c61a00ec2c"), "", "/contents/", "The Weeknd" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0091cd54-a937-47ea-afa5-c7d3e3b5110b"), "Pop" },
                    { new Guid("1aff3bd4-5765-450b-8822-064f718f7708"), "Country" },
                    { new Guid("26667b92-df3a-4dfa-9290-0e9bd13742d2"), "Rock" },
                    { new Guid("684f6426-cc1c-4fbd-98ef-0c77f3957ffc"), "Rap" },
                    { new Guid("effdd9d5-d29d-4451-9031-ba7d5f82b203"), "R&B" }
                });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "AudioPath", "CoverPath", "Duration", "Name", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd"), null, "", "", "0", "Save Your Tears(Remix)", new DateTime(2023, 7, 31, 23, 10, 59, 633, DateTimeKind.Local).AddTicks(8289) },
                    { new Guid("a3ecf920-f5bd-4fc1-91da-e8078cbed599"), null, "", "", "0", "Blinding Lights", new DateTime(2023, 7, 31, 23, 10, 59, 633, DateTimeKind.Local).AddTicks(8289) },
                    { new Guid("a9e3a68a-8b25-47fa-aa40-8609f3f1171f"), null, "", "", "0", "Happier Than Ever", new DateTime(2023, 7, 31, 23, 10, 59, 633, DateTimeKind.Local).AddTicks(8275) }
                });

            migrationBuilder.InsertData(
                table: "GenreSongs",
                columns: new[] { "GenreId", "SongId" },
                values: new object[,]
                {
                    { new Guid("0091cd54-a937-47ea-afa5-c7d3e3b5110b"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") },
                    { new Guid("1aff3bd4-5765-450b-8822-064f718f7708"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") },
                    { new Guid("0091cd54-a937-47ea-afa5-c7d3e3b5110b"), new Guid("a3ecf920-f5bd-4fc1-91da-e8078cbed599") },
                    { new Guid("effdd9d5-d29d-4451-9031-ba7d5f82b203"), new Guid("a9e3a68a-8b25-47fa-aa40-8609f3f1171f") }
                });

            migrationBuilder.InsertData(
                table: "SongArtist",
                columns: new[] { "ArtistId", "SongId" },
                values: new object[,]
                {
                    { new Guid("1688cc79-6d02-4fb5-a83e-93dc6bf229de"), new Guid("a9e3a68a-8b25-47fa-aa40-8609f3f1171f") },
                    { new Guid("bfcc171c-def2-4aeb-a3a1-5683d3d92ddb"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") },
                    { new Guid("bfdf22c7-1bde-4dfc-bcc2-f7c61a00ec2c"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") },
                    { new Guid("bfdf22c7-1bde-4dfc-bcc2-f7c61a00ec2c"), new Guid("a3ecf920-f5bd-4fc1-91da-e8078cbed599") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("884a2098-09e6-4eeb-bc1a-63e9fbb90414"));

            migrationBuilder.DeleteData(
                table: "GenreSongs",
                keyColumns: new[] { "GenreId", "SongId" },
                keyValues: new object[] { new Guid("0091cd54-a937-47ea-afa5-c7d3e3b5110b"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") });

            migrationBuilder.DeleteData(
                table: "GenreSongs",
                keyColumns: new[] { "GenreId", "SongId" },
                keyValues: new object[] { new Guid("1aff3bd4-5765-450b-8822-064f718f7708"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") });

            migrationBuilder.DeleteData(
                table: "GenreSongs",
                keyColumns: new[] { "GenreId", "SongId" },
                keyValues: new object[] { new Guid("0091cd54-a937-47ea-afa5-c7d3e3b5110b"), new Guid("a3ecf920-f5bd-4fc1-91da-e8078cbed599") });

            migrationBuilder.DeleteData(
                table: "GenreSongs",
                keyColumns: new[] { "GenreId", "SongId" },
                keyValues: new object[] { new Guid("effdd9d5-d29d-4451-9031-ba7d5f82b203"), new Guid("a9e3a68a-8b25-47fa-aa40-8609f3f1171f") });

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("26667b92-df3a-4dfa-9290-0e9bd13742d2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("684f6426-cc1c-4fbd-98ef-0c77f3957ffc"));

            migrationBuilder.DeleteData(
                table: "SongArtist",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { new Guid("1688cc79-6d02-4fb5-a83e-93dc6bf229de"), new Guid("a9e3a68a-8b25-47fa-aa40-8609f3f1171f") });

            migrationBuilder.DeleteData(
                table: "SongArtist",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { new Guid("bfcc171c-def2-4aeb-a3a1-5683d3d92ddb"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") });

            migrationBuilder.DeleteData(
                table: "SongArtist",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { new Guid("bfdf22c7-1bde-4dfc-bcc2-f7c61a00ec2c"), new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd") });

            migrationBuilder.DeleteData(
                table: "SongArtist",
                keyColumns: new[] { "ArtistId", "SongId" },
                keyValues: new object[] { new Guid("bfdf22c7-1bde-4dfc-bcc2-f7c61a00ec2c"), new Guid("a3ecf920-f5bd-4fc1-91da-e8078cbed599") });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("1688cc79-6d02-4fb5-a83e-93dc6bf229de"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("bfcc171c-def2-4aeb-a3a1-5683d3d92ddb"));

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: new Guid("bfdf22c7-1bde-4dfc-bcc2-f7c61a00ec2c"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0091cd54-a937-47ea-afa5-c7d3e3b5110b"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("1aff3bd4-5765-450b-8822-064f718f7708"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("effdd9d5-d29d-4451-9031-ba7d5f82b203"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("2566688b-0f41-4e42-bc7d-39cbb172acfd"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("a3ecf920-f5bd-4fc1-91da-e8078cbed599"));

            migrationBuilder.DeleteData(
                table: "Songs",
                keyColumn: "Id",
                keyValue: new Guid("a9e3a68a-8b25-47fa-aa40-8609f3f1171f"));

            migrationBuilder.AlterColumn<Guid>(
                name: "AlbumId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("51ceaded-1d9f-4222-9414-b226108ae3ed"), "Disco" },
                    { new Guid("5e60b86f-2694-4838-a7aa-7e1d16c3beb3"), "R&B" },
                    { new Guid("8bb31a9e-d6be-4bc6-857f-c753a08415dc"), "Rap" },
                    { new Guid("a0d782a5-62cf-49f2-8f03-6a85bf4b0350"), "Pop" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
