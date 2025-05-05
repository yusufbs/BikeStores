using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lp.AngularBlog.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removednewdatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 3, 19, 14, 52, 188, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 5, 3, 19, 14, 52, 184, DateTimeKind.Local).AddTicks(766));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 3, 19, 14, 52, 188, DateTimeKind.Local).AddTicks(2549),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 5, 3, 19, 14, 52, 184, DateTimeKind.Local).AddTicks(766),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
