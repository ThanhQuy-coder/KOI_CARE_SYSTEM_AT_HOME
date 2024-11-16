using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KoiCareSystemAtHome.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class minhquan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UserId",
                table: "_Product");

            migrationBuilder.DropForeignKey(
                name: "FK___User__AccountId__29572725",
                table: "_User");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedingSchedule_KoiFish_FishId",
                table: "FeedingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK_KoiFish_PondID",
                table: "KoiFish");

            migrationBuilder.DropForeignKey(
                name: "FK_Pond_User",
                table: "Pond");

            migrationBuilder.DropForeignKey(
                name: "FK_SaltCalculation_Pond_PondId",
                table: "SaltCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK_WaterParameter_Pond_PondId",
                table: "WaterParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK__WaterPar__5D1C0C72B31FBE7E",
                table: "WaterParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SaltCalc__69E08378212B7F83",
                table: "SaltCalculation");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Pond__D18BF854BF5D6EE2",
                table: "Pond");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__DD0C73BA141E91D1",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__KoiFish__5222DA39EDB1C1CB",
                table: "KoiFish");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FeedingS__1B08C845646F4CF3",
                table: "FeedingSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Account__349DA586BD287530",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK___User__1788CC4C0FA9730F",
                table: "_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK___Product__2D10D14A9E48844F",
                table: "_Product");

            migrationBuilder.RenameIndex(
                name: "UQ__Account__AB6E6164E9B079EA",
                table: "Account",
                newName: "UQ__Account__AB6E61647D497C94");

            migrationBuilder.RenameIndex(
                name: "UQ__Account__536C85E498ADDC16",
                table: "Account",
                newName: "UQ__Account__536C85E4E411DF1D");

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

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PassWordHash",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK__WaterPar__5D1C0C728A04E1A9",
                table: "WaterParameter",
                column: "WaterParameterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SaltCalc__69E0837868F56082",
                table: "SaltCalculation",
                column: "salt_CalculationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Pond__D18BF8541C4B2D40",
                table: "Pond",
                column: "PondID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__DD0C73BA884B0BE7",
                table: "News",
                column: "postID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__KoiFish__5222DA391BAAB9AE",
                table: "KoiFish",
                column: "fishID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FeedingS__1B08C84542D06A71",
                table: "FeedingSchedule",
                column: "feeding_ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Account__349DA586BFFA8EDE",
                table: "Account",
                column: "AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK___User__1788CC4C688C32AF",
                table: "_User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK___Product__2D10D14AF3D98433",
                table: "_Product",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "UQ__News__C2E6DB671928440D",
                table: "News",
                column: "author",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK___Product__UserId__534D60F1",
                table: "_Product",
                column: "UserId",
                principalTable: "_User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK___User__AccountId__3C69FB99",
                table: "_User",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK__FeedingSc__fishI__47DBAE45",
                table: "FeedingSchedule",
                column: "fishID",
                principalTable: "KoiFish",
                principalColumn: "fishID");

            migrationBuilder.AddForeignKey(
                name: "FK__KoiFish__PondID__440B1D61",
                table: "KoiFish",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID");

            migrationBuilder.AddForeignKey(
                name: "FK__Pond__UserId__403A8C7D",
                table: "Pond",
                column: "UserId",
                principalTable: "_User",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK__SaltCalcu__PondI__4F7CD00D",
                table: "SaltCalculation",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID");

            migrationBuilder.AddForeignKey(
                name: "FK__WaterPara__PondI__4BAC3F29",
                table: "WaterParameter",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK___Product__UserId__534D60F1",
                table: "_Product");

            migrationBuilder.DropForeignKey(
                name: "FK___User__AccountId__3C69FB99",
                table: "_User");

            migrationBuilder.DropForeignKey(
                name: "FK__FeedingSc__fishI__47DBAE45",
                table: "FeedingSchedule");

            migrationBuilder.DropForeignKey(
                name: "FK__KoiFish__PondID__440B1D61",
                table: "KoiFish");

            migrationBuilder.DropForeignKey(
                name: "FK__Pond__UserId__403A8C7D",
                table: "Pond");

            migrationBuilder.DropForeignKey(
                name: "FK__SaltCalcu__PondI__4F7CD00D",
                table: "SaltCalculation");

            migrationBuilder.DropForeignKey(
                name: "FK__WaterPara__PondI__4BAC3F29",
                table: "WaterParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK__WaterPar__5D1C0C728A04E1A9",
                table: "WaterParameter");

            migrationBuilder.DropPrimaryKey(
                name: "PK__SaltCalc__69E0837868F56082",
                table: "SaltCalculation");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Pond__D18BF8541C4B2D40",
                table: "Pond");

            migrationBuilder.DropPrimaryKey(
                name: "PK__News__DD0C73BA884B0BE7",
                table: "News");

            migrationBuilder.DropIndex(
                name: "UQ__News__C2E6DB671928440D",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK__KoiFish__5222DA391BAAB9AE",
                table: "KoiFish");

            migrationBuilder.DropPrimaryKey(
                name: "PK__FeedingS__1B08C84542D06A71",
                table: "FeedingSchedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Account__349DA586BFFA8EDE",
                table: "Account");

            migrationBuilder.DropPrimaryKey(
                name: "PK___User__1788CC4C688C32AF",
                table: "_User");

            migrationBuilder.DropPrimaryKey(
                name: "PK___Product__2D10D14AF3D98433",
                table: "_Product");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "News");

            migrationBuilder.DropColumn(
                name: "PassWordHash",
                table: "Account");

            migrationBuilder.RenameIndex(
                name: "UQ__Account__AB6E61647D497C94",
                table: "Account",
                newName: "UQ__Account__AB6E6164E9B079EA");

            migrationBuilder.RenameIndex(
                name: "UQ__Account__536C85E4E411DF1D",
                table: "Account",
                newName: "UQ__Account__536C85E498ADDC16");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK__WaterPar__5D1C0C72B31FBE7E",
                table: "WaterParameter",
                column: "WaterParameterID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__SaltCalc__69E08378212B7F83",
                table: "SaltCalculation",
                column: "salt_CalculationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Pond__D18BF854BF5D6EE2",
                table: "Pond",
                column: "PondID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__News__DD0C73BA141E91D1",
                table: "News",
                column: "postID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__KoiFish__5222DA39EDB1C1CB",
                table: "KoiFish",
                column: "fishID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__FeedingS__1B08C845646F4CF3",
                table: "FeedingSchedule",
                column: "feeding_ScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Account__349DA586BD287530",
                table: "Account",
                column: "AccountID");

            migrationBuilder.AddPrimaryKey(
                name: "PK___User__1788CC4C0FA9730F",
                table: "_User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK___Product__2D10D14A9E48844F",
                table: "_Product",
                column: "productID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UserId",
                table: "_Product",
                column: "UserId",
                principalTable: "_User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK___User__AccountId__29572725",
                table: "_User",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedingSchedule_KoiFish_FishId",
                table: "FeedingSchedule",
                column: "fishID",
                principalTable: "KoiFish",
                principalColumn: "fishID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KoiFish_PondID",
                table: "KoiFish",
                column: "PondID",
                principalTable: "Pond",
                principalColumn: "PondID",
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
    }
}
