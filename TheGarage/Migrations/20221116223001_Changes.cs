using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheGarage.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RegistryNumbers",
                table: "Car");

            migrationBuilder.AlterColumn<int>(
                name: "YearModel",
                table: "Car",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistryNumber",
                table: "Car",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "RegistryNumber");

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "RegistryNumber", "Brand", "Color", "Model", "YearModel" },
                values: new object[] { "OMH525", "Volksvagen", "White", "Golf Manhattan", 2000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Car",
                table: "Car");

            migrationBuilder.DeleteData(
                table: "Car",
                keyColumn: "RegistryNumber",
                keyColumnType: "nvarchar(450)",
                keyValue: "OMH525");

            migrationBuilder.DropColumn(
                name: "RegistryNumber",
                table: "Car");

            migrationBuilder.AlterColumn<string>(
                name: "YearModel",
                table: "Car",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegistryNumbers",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Car",
                table: "Car",
                column: "RegistryNumbers");
        }
    }
}
