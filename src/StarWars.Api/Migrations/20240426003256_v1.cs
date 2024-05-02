using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarWars.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    Episode = table.Column<string>(type: "VARCHAR", maxLength: 2, nullable: false),
                    OpeningCrawl = table.Column<string>(type: "TEXT", nullable: false),
                    Director = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: false),
                    Producer = table.Column<string>(type: "VARCHAR", maxLength: 40, nullable: false),
                    ReleaseDate = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    RotationPeriod = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    OrbitalPeriod = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Diameter = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Climate = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    Gravity = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    Terrain = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    SurfaceWater = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false),
                    Population = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spaceship",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    Manufacturer = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    CostInCredits = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Length = table.Column<string>(type: "TEXT", nullable: false),
                    MaxSpeed = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    Crew = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false),
                    Passengers = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false),
                    CargoCapacity = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Consumables = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Class = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    HyperdriveRating = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false),
                    MGLT = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaceship", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    Model = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false),
                    Manufacturer = table.Column<string>(type: "VARCHAR", maxLength: 50, nullable: false),
                    CostInCredits = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Length = table.Column<string>(type: "TEXT", nullable: false),
                    MaxSpeed = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    Crew = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false),
                    Passengers = table.Column<string>(type: "VARCHAR", maxLength: 4, nullable: false),
                    CargoCapacity = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Consumables = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    Class = table.Column<string>(type: "VARCHAR", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 80, nullable: false),
                    Height = table.Column<string>(type: "VARCHAR", maxLength: 5, nullable: false),
                    Weight = table.Column<string>(type: "VARCHAR", maxLength: 5, nullable: false),
                    HairColor = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    SkinColor = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    EyeColor = table.Column<string>(type: "VARCHAR", maxLength: 20, nullable: false),
                    BirthYear = table.Column<string>(type: "VARCHAR", maxLength: 10, nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR", maxLength: 15, nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false),
                    FK_Character_Planet = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Planet_FK_Character_Planet",
                        column: x => x.FK_Character_Planet,
                        principalTable: "Planet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Film_Planet",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    PlanetId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_Planet", x => new { x.FilmId, x.PlanetId });
                    table.ForeignKey(
                        name: "FK_Film_Planet_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Planet_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Film_Spaceship",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpaceshipId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_Spaceship", x => new { x.FilmId, x.SpaceshipId });
                    table.ForeignKey(
                        name: "FK_Film_Spaceship_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Spaceship_Spaceship_SpaceshipId",
                        column: x => x.SpaceshipId,
                        principalTable: "Spaceship",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Film_Vehicle",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_Vehicle", x => new { x.FilmId, x.VehicleId });
                    table.ForeignKey(
                        name: "FK_Film_Vehicle_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Vehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Film_Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    FilmId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film_Characters", x => new { x.CharacterId, x.FilmId });
                    table.ForeignKey(
                        name: "FK_Film_Characters_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Film_Characters_Film_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_FK_Character_Planet",
                table: "Character",
                column: "FK_Character_Planet");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Characters_FilmId",
                table: "Film_Characters",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Planet_PlanetId",
                table: "Film_Planet",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Spaceship_SpaceshipId",
                table: "Film_Spaceship",
                column: "SpaceshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Film_Vehicle_VehicleId",
                table: "Film_Vehicle",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film_Characters");

            migrationBuilder.DropTable(
                name: "Film_Planet");

            migrationBuilder.DropTable(
                name: "Film_Spaceship");

            migrationBuilder.DropTable(
                name: "Film_Vehicle");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Spaceship");

            migrationBuilder.DropTable(
                name: "Film");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Planet");
        }
    }
}
