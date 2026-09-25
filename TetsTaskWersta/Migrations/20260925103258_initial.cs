using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TetsTaskWersta.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    SenderCity = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    SenderAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    RecipientCity = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RecipientAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Weight = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    PickupDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderNumber",
                table: "orders",
                column: "OrderNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orders");
        }
    }
}
