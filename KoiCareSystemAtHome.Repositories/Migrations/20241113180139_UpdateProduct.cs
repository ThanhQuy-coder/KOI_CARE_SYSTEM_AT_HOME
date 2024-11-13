using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiCareSystemAtHome.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK___Product__UserId__403A8C7D",
                table: "_Product");

            migrationBuilder.DropForeignKey(
                name: "FK__FeedingSc__fishI__34C8D9D1",
                table: "FeedingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK__Pond__UserId__2D27B809",
                table: "Pond");

            migrationBuilder.DropForeignKey(
                name: "FK__SaltCalcu__PondI__3C69FB99",
                table: "SaltCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK__WaterPara__PondI__38996AB5",
                table: "WaterParameter");

            migrationBuilder.DropIndex(
                name: "UQ__News__C2E6DB67D7E9ABFB",
                table: "News");

            migrationBuilder.AlterColumn<double>(
                name: "volume",
                table: "Pond",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "pumpCapacity",
                table: "Pond",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "imagePond",
                table: "Pond",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "drainCount",
                table: "Pond",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "depth",
                table: "Pond",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NamePond",
                table: "Pond",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "author",
                table: "News",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UserId",
                table: "_Product",
                column: "UserId",
                principalTable: "_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedule_KoiFish_FishId",
                table: "FeedingSchedule",
                column: "fishID",
                principalTable: "KoiFish",
                principalColumn: "fishID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pond_User",
                table: "Pond",
                column: "UserId",
                principalTable: "_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaltCalculation_Pond_PondId",
                table: "SaltCalculation",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WaterParameter_Pond_PondId",
                table: "WaterParameter",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UserId",
                table: "_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedule_KoiFish_FishId",
                table: "FeedingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Pond_User",
                table: "Pond");

            migrationBuilder.DropForeignKey(
                name: "FK_SaltCalculation_Pond_PondId",
                table: "SaltCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterParameter_Pond_PondId",
                table: "WaterParameter");

            migrationBuilder.AlterColumn<double>(
                name: "volume",
                table: "Pond",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "pumpCapacity",
                table: "Pond",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "imagePond",
                table: "Pond",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "drainCount",
                table: "Pond",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "depth",
                table: "Pond",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "NamePond",
                table: "Pond",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "author",
                table: "News",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "UQ__News__C2E6DB67D7E9ABFB",
                table: "News",
                column: "author",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK___Product__UserId__403A8C7D",
                table: "_Product",
                column: "UserId",
                principalTable: "_User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__FeedingSc__fishI__34C8D9D1",
                table: "FeedingSchedule",
                column: "fishID",
                principalTable: "KoiFish",
                principalColumn: "fishID");

            migrationBuilder.AddForeignKey(
                name: "FK__Pond__UserId__2D27B809",
                table: "Pond",
                column: "UserId",
                principalTable: "_User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__SaltCalcu__PondI__3C69FB99",
                table: "SaltCalculation",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID");

            migrationBuilder.AddForeignKey(
                name: "FK__WaterPara__PondI__38996AB5",
                table: "WaterParameter",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID");
        }
    }
}
