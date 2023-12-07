using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yuta_SampleWeb01.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 30, nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "t_data_a",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    data_cls = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    period_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    download_flg = table.Column<bool>(type: "bit", nullable: false),
                    deleted_flg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_data_a", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "t_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    deleted_flg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "t_user_company",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    ccompany_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_user_company", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_t_user_company_t_user_user_id",
                        column: x => x.user_id,
                        principalTable: "t_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "t_data_a");

            migrationBuilder.DropTable(
                name: "t_user_company");

            migrationBuilder.DropTable(
                name: "t_user");
        }
    }
}
