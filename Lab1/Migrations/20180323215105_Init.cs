using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab1.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Parameters",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Income = table.Column<int>(nullable: true),
                    InGamePurchaseParameters_Price = table.Column<int>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true),
                    StageEndParameters_Income = table.Column<int>(nullable: true),
                    StageStartParameters_Stage = table.Column<int>(nullable: true),
                    Stage = table.Column<int>(nullable: true),
                    Time = table.Column<int>(nullable: true),
                    Win = table.Column<bool>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Parameters", x => x.Id); });

            migrationBuilder.CreateTable(
                "Events",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    ParametersId = table.Column<int>(nullable: true),
                    Udid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        "FK_Events_Parameters_ParametersId",
                        x => x.ParametersId,
                        "Parameters",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Events_ParametersId",
                "Events",
                "ParametersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Events");

            migrationBuilder.DropTable(
                "Parameters");
        }
    }
}