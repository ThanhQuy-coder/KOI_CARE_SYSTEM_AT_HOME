using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiCareSystemAtHome.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    passWorkHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Account__349DA586BD287530", x => x.AccountID);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    postID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    author = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content = table.Column<string>(type: "ntext", nullable: false),
                    publishDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__News__DD0C73BA141E91D1", x => x.postID);
                });

            migrationBuilder.CreateTable(
                name: "_User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    AccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    _Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___User__1788CC4C0FA9730F", x => x.UserId);
                    table.ForeignKey(
                        name: "FK___User__AccountId__29572725",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "_Product",
                columns: table => new
                {
                    productID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    imageProduct = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    desciption = table.Column<string>(type: "ntext", nullable: false),
                    productType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    datePlace = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK___Product__2D10D14A9E48844F", x => x.productID);
                    table.ForeignKey(
                        name: "FK___Product__UserId__403A8C7D",
                        column: x => x.UserId,
                        principalTable: "_User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Pond",
                columns: table => new
                {
                    PondID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NamePond = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    imagePond = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    depth = table.Column<double>(type: "float", nullable: true),
                    volume = table.Column<double>(type: "float", nullable: true),
                    drainCount = table.Column<int>(type: "int", nullable: true),
                    pumpCapacity = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Pond__D18BF854BF5D6EE2", x => x.PondID);
                    table.ForeignKey(
                        name: "FK__Pond__UserId__2D27B809",
                        column: x => x.UserId,
                        principalTable: "_User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "KoiFish",
                columns: table => new
                {
                    fishID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PondID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    nameFish = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    imageFish = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bodyShape = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ageFish = table.Column<int>(type: "int", nullable: false),
                    size = table.Column<double>(type: "float", nullable: false),
                    weightFish = table.Column<double>(type: "float", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    origin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    fishLocation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KoiFish__5222DA39EDB1C1CB", x => x.fishID);
                    table.ForeignKey(
                        name: "FK_KoiFish_PondID",
                        column: x => x.PondID,
                        principalTable: "Pond",
                        principalColumn: "PondID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SaltCalculation",
                columns: table => new
                {
                    salt_CalculationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PondID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    requiredSaltAmount = table.Column<double>(type: "float", nullable: true),
                    calculationTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SaltCalc__69E08378212B7F83", x => x.salt_CalculationID);
                    table.ForeignKey(
                        name: "FK__SaltCalcu__PondI__3C69FB99",
                        column: x => x.PondID,
                        principalTable: "Pond",
                        principalColumn: "PondID");
                });

            migrationBuilder.CreateTable(
                name: "WaterParameter",
                columns: table => new
                {
                    WaterParameterID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    PondID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    temperature = table.Column<double>(type: "float", nullable: false),
                    saltLevel = table.Column<double>(type: "float", nullable: false),
                    pH = table.Column<double>(type: "float", nullable: false),
                    oxygen = table.Column<double>(type: "float", nullable: false),
                    nitrie = table.Column<double>(type: "float", nullable: false),
                    nitrate = table.Column<double>(type: "float", nullable: false),
                    phospate = table.Column<double>(type: "float", nullable: false),
                    measurementTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WaterPar__5D1C0C72B31FBE7E", x => x.WaterParameterID);
                    table.ForeignKey(
                        name: "FK__WaterPara__PondI__38996AB5",
                        column: x => x.PondID,
                        principalTable: "Pond",
                        principalColumn: "PondID");
                });

            migrationBuilder.CreateTable(
                name: "FeedingSchedule",
                columns: table => new
                {
                    feeding_ScheduleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    fishID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    feedingTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    requiredFoodAmount = table.Column<double>(type: "float", nullable: false),
                    foodType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FeedingS__1B08C845646F4CF3", x => x.feeding_ScheduleID);
                    table.ForeignKey(
                        name: "FK__FeedingSc__fishI__34C8D9D1",
                        column: x => x.fishID,
                        principalTable: "KoiFish",
                        principalColumn: "fishID");
                });

            migrationBuilder.CreateIndex(
                name: "IX__Product_UserId",
                table: "_Product",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX__User_AccountId",
                table: "_User",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "UQ__Account__536C85E498ADDC16",
                table: "Account",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Account__AB6E6164E9B079EA",
                table: "Account",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedingSchedule_fishID",
                table: "FeedingSchedule",
                column: "fishID");

            migrationBuilder.CreateIndex(
                name: "IX_KoiFish_PondID",
                table: "KoiFish",
                column: "PondID");

            migrationBuilder.CreateIndex(
                name: "UQ__News__C2E6DB67D7E9ABFB",
                table: "News",
                column: "author",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pond_UserId",
                table: "Pond",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SaltCalculation_PondID",
                table: "SaltCalculation",
                column: "PondID");

            migrationBuilder.CreateIndex(
                name: "IX_WaterParameter_PondID",
                table: "WaterParameter",
                column: "PondID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Product");

            migrationBuilder.DropTable(
                name: "FeedingSchedule");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "SaltCalculation");

            migrationBuilder.DropTable(
                name: "WaterParameter");

            migrationBuilder.DropTable(
                name: "KoiFish");

            migrationBuilder.DropTable(
                name: "Pond");

            migrationBuilder.DropTable(
                name: "_User");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
