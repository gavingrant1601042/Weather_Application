using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clouds",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    All = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clouds", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Coord",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lon = table.Column<double>(type: "float", nullable: false),
                    Lat = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coord", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmailId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address_location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => new { x.EmailId, x.telephone });
                });

            migrationBuilder.CreateTable(
                name: "Main",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    Pressure = table.Column<long>(type: "bigint", nullable: false),
                    Humidity = table.Column<long>(type: "bigint", nullable: false),
                    TempMin = table.Column<double>(type: "float", nullable: false),
                    TempMax = table.Column<double>(type: "float", nullable: false),
                    Percepita = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<long>(type: "bigint", nullable: false),
                    weatherinformation = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sunrise = table.Column<long>(type: "bigint", nullable: false),
                    Sunset = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sys", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wind",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    Deg = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wind", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoordID = table.Column<int>(type: "int", nullable: true),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainID = table.Column<int>(type: "int", nullable: true),
                    Visibility = table.Column<long>(type: "bigint", nullable: false),
                    WindID = table.Column<int>(type: "int", nullable: true),
                    CloudsID = table.Column<int>(type: "int", nullable: true),
                    Dt = table.Column<long>(type: "bigint", nullable: false),
                    SysID = table.Column<int>(type: "int", nullable: true),
                    WeatherDetails = table.Column<long>(type: "bigint", nullable: false),
                    Cod = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Weather_Clouds_CloudsID",
                        column: x => x.CloudsID,
                        principalTable: "Clouds",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weather_Coord_CoordID",
                        column: x => x.CoordID,
                        principalTable: "Coord",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weather_Main_MainID",
                        column: x => x.MainID,
                        principalTable: "Main",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weather_Sys_SysID",
                        column: x => x.SysID,
                        principalTable: "Sys",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Weather_Wind_WindID",
                        column: x => x.WindID,
                        principalTable: "Wind",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Weather_CloudsID",
                table: "Weather",
                column: "CloudsID");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_CoordID",
                table: "Weather",
                column: "CoordID");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_MainID",
                table: "Weather",
                column: "MainID");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_SysID",
                table: "Weather",
                column: "SysID");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WindID",
                table: "Weather",
                column: "WindID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Clouds");

            migrationBuilder.DropTable(
                name: "Coord");

            migrationBuilder.DropTable(
                name: "Main");

            migrationBuilder.DropTable(
                name: "Sys");

            migrationBuilder.DropTable(
                name: "Wind");
        }
    }
}
