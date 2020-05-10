using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Counters.Migrations
{
    public partial class AddDAta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Counters",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counters", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Counters",
                columns: new[] { "ID", "Number", "Value" },
                values: new object[,]
                {
                    { -7, 1, 1 },
                    { -6, 1, 2 },
                    { -5, 1, 3 },
                    { -4, 2, 1 },
                    { -3, 2, 1 },
                    { -2, 2, 3 },
                    { -1, 2, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Counters");
        }
    }
}
