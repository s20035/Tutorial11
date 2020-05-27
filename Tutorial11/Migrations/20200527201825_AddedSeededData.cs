using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial11.Migrations
{
    public partial class AddedSeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "EMail", "FirstName", "LastName" },
                values: new object[] { 245, "Iamhere@yahoo.con", "Simphiwe", "Dlamini" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "EMail", "FirstName", "LastName" },
                values: new object[] { 268, "Kingof@Earth.coz", "Ntokozo", "Ndabandaba" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "EMail", "FirstName", "LastName" },
                values: new object[] { 472, "Lifeis@LG.faz", "Nosimilo", "Ntshangase" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 472);
        }
    }
}
