using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerBirthDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: new Guid("03b30649-53f3-4151-a99d-08c182d91502"));

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: new Guid("ad50fcaf-ef3b-484c-ba56-425e674ed368"));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Customers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd") },
                column: "Id",
                value: new Guid("78ed9ab1-3adb-4de5-9d29-4deb45c53600"));

            migrationBuilder.UpdateData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c") },
                column: "Id",
                value: new Guid("9c4982a0-763b-4985-876d-1bba466fa599"));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"),
                column: "BirthDay",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "PromoCodes",
                columns: new[] { "Id", "BeginDate", "Code", "CustomerId", "EndDate", "PartnerManagerId", "PreferenceId", "ServiceInfo" },
                values: new object[,]
                {
                    { new Guid("738cbbe9-dbd4-46f3-95fe-032c08470128"), new DateTime(2024, 3, 27, 12, 30, 18, 230, DateTimeKind.Local).AddTicks(6775), "THEATER-123", new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new DateTime(2024, 5, 6, 12, 30, 18, 230, DateTimeKind.Local).AddTicks(6790), new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c"), "Скидка 10% на театральные услуги" },
                    { new Guid("a51b578d-81fb-4d93-a27a-d38faeae4d77"), new DateTime(2024, 3, 27, 12, 30, 18, 230, DateTimeKind.Local).AddTicks(6819), "FAMILY-456", new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new DateTime(2024, 6, 5, 12, 30, 18, 230, DateTimeKind.Local).AddTicks(6820), new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd"), "Скидка 20% на все семейные услуги" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: new Guid("738cbbe9-dbd4-46f3-95fe-032c08470128"));

            migrationBuilder.DeleteData(
                table: "PromoCodes",
                keyColumn: "Id",
                keyValue: new Guid("a51b578d-81fb-4d93-a27a-d38faeae4d77"));

            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd") },
                column: "Id",
                value: new Guid("efb73aa9-f551-4205-8bba-d02e43da9ecc"));

            migrationBuilder.UpdateData(
                table: "CustomerPreferences",
                keyColumns: new[] { "CustomerId", "PreferenceId" },
                keyValues: new object[] { new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c") },
                column: "Id",
                value: new Guid("a04c4d39-f1ce-4bbf-9e25-4ecb66a3c02f"));

            migrationBuilder.InsertData(
                table: "PromoCodes",
                columns: new[] { "Id", "BeginDate", "Code", "CustomerId", "EndDate", "PartnerManagerId", "PreferenceId", "ServiceInfo" },
                values: new object[,]
                {
                    { new Guid("03b30649-53f3-4151-a99d-08c182d91502"), new DateTime(2024, 3, 27, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(476), "FAMILY-456", new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new DateTime(2024, 6, 5, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(476), new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), new Guid("c4bda62e-fc74-4256-a956-4760b3858cbd"), "Скидка 20% на все семейные услуги" },
                    { new Guid("ad50fcaf-ef3b-484c-ba56-425e674ed368"), new DateTime(2024, 3, 27, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(403), "THEATER-123", new Guid("a6c8c6b1-4349-45b0-ab31-244740aaf0f0"), new DateTime(2024, 5, 6, 12, 28, 23, 691, DateTimeKind.Local).AddTicks(417), new Guid("f766e2bf-340a-46ea-bff3-f1700b435895"), new Guid("ef7f299f-92d7-459f-896e-078ed53ef99c"), "Скидка 10% на театральные услуги" }
                });
        }
    }
}
