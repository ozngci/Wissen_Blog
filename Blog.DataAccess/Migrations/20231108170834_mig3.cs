using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4adbd822-77a4-4232-9c69-b478eaa0369d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "adb6277e-381b-4fd3-9437-79a7a85f457b", "wissenadmin@wissen.com", "WISSENADMIN@WISSEN.COM", "WISSENADMIN@WISSEN.COM", "AQAAAAIAAYagAAAAEGjyPWj6DDhaWTetr0+SjruZiynBe+ToQyG9xqBvYU40k/gukQs1sxhZRPnDNRzbdw==", "89a42422-1668-45cd-bbb8-abe74ee99898", "wissenadmin@wissen.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4adbd822-77a4-4232-9c69-b478eaa0369d",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "2b3ce0ec-0c59-4c7c-9944-777c9d86e651", "superadmin@bloggie.com", "SUPERADMİN@BLOGGİE.COM", "SUPERADMİN@BLOGGİE.COM", "AQAAAAIAAYagAAAAEGC1li3xwcQD9rzeJK3TZFvoqS0FPLZ+QElN0/Y6EGAp41ec40FSyNO65ULBJOXa3A==", "41e775b2-af3b-4430-bcdf-a0e120da8774", "superadmin@bloggie.com" });
        }
    }
}
