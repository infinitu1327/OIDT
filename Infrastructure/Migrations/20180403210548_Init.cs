using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema("Parameters");
            migrationBuilder.EnsureSchema("Events");

            migrationBuilder.CreateTable(
                name: "CurrencyPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Income = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                schema: "Parameters",
                constraints: table => { table.PrimaryKey("PK_CurrencyPurchase", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "FirstLaunch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Age = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true)
                },
                schema: "Parameters",
                constraints: table => { table.PrimaryKey("PK_FirstLaunch", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "GameLaunch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Udid = table.Column<string>(nullable: true)
                },
                schema: "Events",
                constraints: table => { table.PrimaryKey("PK_GameLaunchEvents", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "InGamePurchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Item = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                schema: "Parameters",
                constraints: table => { table.PrimaryKey("PK_InGamePurchase", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "StageEnd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Income = table.Column<int>(nullable: true),
                    Stage = table.Column<int>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    Win = table.Column<bool>(nullable: false)
                },
                schema: "Parameters",
                constraints: table => { table.PrimaryKey("PK_StageEnd", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "StageStart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Stage = table.Column<int>(nullable: false)
                },
                schema: "Parameters",
                constraints: table => { table.PrimaryKey("PK_StageStart", x => x.Id); });

            migrationBuilder.CreateTable(
                name: "CurrencyPurchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ParametersId = table.Column<int>(nullable: true),
                    Udid = table.Column<string>(nullable: true)
                },
                schema: "Events",
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyPurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyPurchase_CurrencyPurchase_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "CurrencyPurchase",
                        principalColumn: "Id",
                        principalSchema: "Parameters",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FirstLaunch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ParametersId = table.Column<int>(nullable: true),
                    Udid = table.Column<string>(nullable: true)
                },
                schema: "Events",
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstLaunch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirstLaunch_FirstLaunch_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "FirstLaunch",
                        principalColumn: "Id",
                        principalSchema: "Parameters",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InGamePurchase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ParametersId = table.Column<int>(nullable: true),
                    Udid = table.Column<string>(nullable: true)
                },
                schema: "Events",
                constraints: table =>
                {
                    table.PrimaryKey("PK_InGamePurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InGamePurchase_InGamePurchase_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "InGamePurchase",
                        principalColumn: "Id",
                        principalSchema: "Parameters",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StageEnd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ParametersId = table.Column<int>(nullable: true),
                    Udid = table.Column<string>(nullable: true)
                },
                schema: "Events",
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageEnd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageEnd_StageEnd_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "StageEnd",
                        principalColumn: "Id",
                        principalSchema: "Parameters",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StageStart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ParametersId = table.Column<int>(nullable: true),
                    Udid = table.Column<string>(nullable: true)
                },
                schema: "Events",
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageStartEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StageStart_StageStart_ParametersId",
                        column: x => x.ParametersId,
                        principalTable: "StageStart",
                        principalColumn: "Id",
                        principalSchema: "Parameters",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyPurchase_ParametersId",
                table: "CurrencyPurchase",
                schema: "Events",
                column: "ParametersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FirstLaunch_ParametersId",
                table: "FirstLaunch",
                schema: "Events",
                column: "ParametersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InGamePurchase_ParametersId",
                table: "InGamePurchase",
                schema: "Events",
                column: "ParametersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StageEnd_ParametersId",
                table: "StageEnd",
                schema: "Events",
                column: "ParametersId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StageStart_ParametersId",
                table: "StageStart",
                schema: "Events",
                column: "ParametersId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyPurchase",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "FirstLaunch",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "GameLaunch",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "InGamePurchase",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "StageEnd",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "StageStart",
                schema: "Events");

            migrationBuilder.DropTable(
                name: "CurrencyPurchase",
                schema: "Parameters");

            migrationBuilder.DropTable(
                name: "FirstLaunch",
                schema: "Parameters");

            migrationBuilder.DropTable(
                name: "InGamePurchase",
                schema: "Parameters");

            migrationBuilder.DropTable(
                name: "StageEnd",
                schema: "Parameters");

            migrationBuilder.DropTable(
                name: "StageStart",
                schema: "Parameters");
        }
    }
}