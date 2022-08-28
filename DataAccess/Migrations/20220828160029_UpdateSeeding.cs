using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class UpdateSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CoffeShops",
                columns: new[] { "Id", "Address", "Name", "OpeningHours" },
                values: new object[] { "239ba06b-389b-4bd8-b656-49bf1dfae01c", "12 - Duy Tan - Ha Noi", "Ume", "7.00 Am" });

            migrationBuilder.InsertData(
                table: "CoffeShops",
                columns: new[] { "Id", "Address", "Name", "OpeningHours" },
                values: new object[] { "3db25205-d340-4b25-a8e3-2f2f2e75e681", "19 - Pham Van Dong - Ha Noi", "Matchas", "7.00 Am" });

            migrationBuilder.InsertData(
                table: "CoffeShops",
                columns: new[] { "Id", "Address", "Name", "OpeningHours" },
                values: new object[] { "ed3b07c5-fe83-4ea0-b97f-906776aea217", "52 - Nguyen Van Huyen - Ha Noi", "King Top", "7.00 Am" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CoffeShops",
                keyColumn: "Id",
                keyValue: "239ba06b-389b-4bd8-b656-49bf1dfae01c");

            migrationBuilder.DeleteData(
                table: "CoffeShops",
                keyColumn: "Id",
                keyValue: "3db25205-d340-4b25-a8e3-2f2f2e75e681");

            migrationBuilder.DeleteData(
                table: "CoffeShops",
                keyColumn: "Id",
                keyValue: "ed3b07c5-fe83-4ea0-b97f-906776aea217");
        }
    }
}
