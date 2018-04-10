using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                "events");

            migrationBuilder.EnsureSchema(
                "parameters");

            migrationBuilder.CreateTable(
                "game_launch",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(),
                    udid = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("pk_game_launch", x => x.id); });

            migrationBuilder.CreateTable(
                "currency_purchase",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    income = table.Column<int>(),
                    name = table.Column<string>(nullable: true),
                    price = table.Column<decimal>()
                },
                constraints: table => { table.PrimaryKey("pk_currency_purchase", x => x.id); });

            migrationBuilder.CreateTable(
                "first_launch",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    age = table.Column<int>(),
                    country = table.Column<string>(nullable: true),
                    gender = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("pk_first_launch", x => x.id); });

            migrationBuilder.CreateTable(
                "in_game_purchase",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    item = table.Column<string>(nullable: true),
                    price = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("pk_in_game_purchase", x => x.id); });

            migrationBuilder.CreateTable(
                "stage_end",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    income = table.Column<int>(nullable: true),
                    stage = table.Column<int>(),
                    time = table.Column<int>(),
                    win = table.Column<bool>()
                },
                constraints: table => { table.PrimaryKey("pk_stage_end", x => x.id); });

            migrationBuilder.CreateTable(
                "stage_start",
                schema: "parameters",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    stage = table.Column<int>()
                },
                constraints: table => { table.PrimaryKey("pk_stage_start", x => x.id); });

            migrationBuilder.CreateTable(
                "currency_purchase",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(),
                    parameters_id = table.Column<int>(),
                    udid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currency_purchase", x => x.id);
                    table.ForeignKey(
                        "parameters_id",
                        x => x.parameters_id,
                        principalSchema: "parameters",
                        principalTable: "currency_purchase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "first_launch",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(),
                    parameters_id = table.Column<int>(),
                    udid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_first_launch", x => x.id);
                    table.ForeignKey(
                        "parameters_id",
                        x => x.parameters_id,
                        principalSchema: "parameters",
                        principalTable: "first_launch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "in_game_purchase",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(),
                    parameters_id = table.Column<int>(),
                    udid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_in_game_purchase", x => x.id);
                    table.ForeignKey(
                        "parameters_id",
                        x => x.parameters_id,
                        principalSchema: "parameters",
                        principalTable: "in_game_purchase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "stage_end",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(),
                    parameters_id = table.Column<int>(),
                    udid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_end", x => x.id);
                    table.ForeignKey(
                        "parameters_id",
                        x => x.parameters_id,
                        principalSchema: "parameters",
                        principalTable: "stage_end",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "stage_start",
                schema: "events",
                columns: table => new
                {
                    id = table.Column<int>()
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    date = table.Column<DateTime>(),
                    parameters_id = table.Column<int>(),
                    udid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_stage_start", x => x.id);
                    table.ForeignKey(
                        "parameters_id",
                        x => x.parameters_id,
                        principalSchema: "parameters",
                        principalTable: "stage_start",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_currency_purchase_parameters_id",
                schema: "events",
                table: "currency_purchase",
                column: "parameters_id",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_first_launch_parameters_id",
                schema: "events",
                table: "first_launch",
                column: "parameters_id",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_in_game_purchase_parameters_id",
                schema: "events",
                table: "in_game_purchase",
                column: "parameters_id",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_stage_end_parameters_id",
                schema: "events",
                table: "stage_end",
                column: "parameters_id",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_stage_start_parameters_id",
                schema: "events",
                table: "stage_start",
                column: "parameters_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "currency_purchase",
                "events");

            migrationBuilder.DropTable(
                "first_launch",
                "events");

            migrationBuilder.DropTable(
                "game_launch",
                "events");

            migrationBuilder.DropTable(
                "in_game_purchase",
                "events");

            migrationBuilder.DropTable(
                "stage_end",
                "events");

            migrationBuilder.DropTable(
                "stage_start",
                "events");

            migrationBuilder.DropTable(
                "currency_purchase",
                "parameters");

            migrationBuilder.DropTable(
                "first_launch",
                "parameters");

            migrationBuilder.DropTable(
                "in_game_purchase",
                "parameters");

            migrationBuilder.DropTable(
                "stage_end",
                "parameters");

            migrationBuilder.DropTable(
                "stage_start",
                "parameters");
        }
    }
}