using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebKsu.Migrations
{
    public partial class tblShows : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblDogClases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDogClases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblSex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblSex", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblShowId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShowId", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblValidateShow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblValidateShow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblShow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShowId = table.Column<int>(type: "integer", nullable: false),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    Breed = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false),
                    NameDog = table.Column<string>(type: "text", nullable: false),
                    SexId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Pedigree = table.Column<string>(type: "text", nullable: false),
                    Chip = table.Column<string>(type: "text", nullable: false),
                    Father = table.Column<string>(type: "text", nullable: false),
                    Mather = table.Column<string>(type: "text", nullable: false),
                    Breeder = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<string>(type: "text", nullable: false),
                    Adress = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    StartPhoto1 = table.Column<string>(type: "text", nullable: true),
                    StartPhoto2 = table.Column<string>(type: "text", nullable: true),
                    StartPhoto3 = table.Column<string>(type: "text", nullable: true),
                    StartPhoto4 = table.Column<string>(type: "text", nullable: true),
                    StartPhoto5 = table.Column<string>(type: "text", nullable: true),
                    StartPhoto6 = table.Column<string>(type: "text", nullable: true),
                    ValidateShowId = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblShow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblShow_tblDogClases_ClassId",
                        column: x => x.ClassId,
                        principalTable: "tblDogClases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblShow_tblSex_SexId",
                        column: x => x.SexId,
                        principalTable: "tblSex",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblShow_tblShowId_ShowId",
                        column: x => x.ShowId,
                        principalTable: "tblShowId",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblShow_tblValidateShow_ValidateShowId",
                        column: x => x.ValidateShowId,
                        principalTable: "tblValidateShow",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblShow_ClassId",
                table: "tblShow",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_tblShow_SexId",
                table: "tblShow",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_tblShow_ShowId",
                table: "tblShow",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_tblShow_ValidateShowId",
                table: "tblShow",
                column: "ValidateShowId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblShow");

            migrationBuilder.DropTable(
                name: "tblDogClases");

            migrationBuilder.DropTable(
                name: "tblSex");

            migrationBuilder.DropTable(
                name: "tblShowId");

            migrationBuilder.DropTable(
                name: "tblValidateShow");
        }
    }
}
