using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cats_API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperament = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_codes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Life_span = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wikipedia_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vetstreet_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vcahospitals_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt_names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Indoor = table.Column<int>(type: "int", nullable: true),
                    Adaptability = table.Column<int>(type: "int", nullable: true),
                    Affection_level = table.Column<int>(type: "int", nullable: true),
                    Child_friendly = table.Column<int>(type: "int", nullable: true),
                    Dog_friendly = table.Column<int>(type: "int", nullable: true),
                    Energy_level = table.Column<int>(type: "int", nullable: true),
                    Grooming = table.Column<int>(type: "int", nullable: true),
                    Health_issues = table.Column<int>(type: "int", nullable: true),
                    Intelligence = table.Column<int>(type: "int", nullable: true),
                    Shedding_level = table.Column<int>(type: "int", nullable: true),
                    Social_needs = table.Column<int>(type: "int", nullable: true),
                    Stranger_friendly = table.Column<int>(type: "int", nullable: true),
                    Experimental = table.Column<int>(type: "int", nullable: true),
                    Hairless = table.Column<int>(type: "int", nullable: true),
                    Natural = table.Column<int>(type: "int", nullable: true),
                    Rare = table.Column<int>(type: "int", nullable: true),
                    Rex = table.Column<int>(type: "int", nullable: true),
                    Suppressed_tail = table.Column<int>(type: "int", nullable: true),
                    Short_legs = table.Column<int>(type: "int", nullable: true),
                    Hypoallergenic = table.Column<int>(type: "int", nullable: true),
                    Reference_image_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Weight",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imperial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Metric = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BreedId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weight_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    CatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Cats_CatId",
                        column: x => x.CatId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CatTag",
                columns: table => new
                {
                    CatsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatTag", x => new { x.CatsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_CatTag_Cats_CatsId",
                        column: x => x.CatsId,
                        principalTable: "Cats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BreedImage",
                columns: table => new
                {
                    BreedsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImagesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedImage", x => new { x.BreedsId, x.ImagesId });
                    table.ForeignKey(
                        name: "FK_BreedImage_Breeds_BreedsId",
                        column: x => x.BreedsId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedImage_Images_ImagesId",
                        column: x => x.ImagesId,
                        principalTable: "Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedImage_ImagesId",
                table: "BreedImage",
                column: "ImagesId");

            migrationBuilder.CreateIndex(
                name: "IX_CatTag_TagsId",
                table: "CatTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_CatId",
                table: "Images",
                column: "CatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weight_BreedId",
                table: "Weight",
                column: "BreedId",
                unique: true,
                filter: "[BreedId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedImage");

            migrationBuilder.DropTable(
                name: "CatTag");

            migrationBuilder.DropTable(
                name: "Weight");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Cats");
        }
    }
}
