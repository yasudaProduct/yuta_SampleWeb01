using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWeb01.Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    password = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    mail_address = table.Column<string>(type: "character varying(319)", maxLength: 319, nullable: false),
                    deleted_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    create_pgm_id = table.Column<string>(type: "text", nullable: false),
                    create_user_id = table.Column<string>(type: "text", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_pgm_id = table.Column<string>(type: "text", nullable: false),
                    update_user_id = table.Column<string>(type: "text", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "m_user_company",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    company_name = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    remarks = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    deleted_flg = table.Column<string>(type: "character varying(1)", maxLength: 1, nullable: false),
                    create_pgm_id = table.Column<string>(type: "text", nullable: false),
                    create_user_id = table.Column<string>(type: "text", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    update_pgm_id = table.Column<string>(type: "text", nullable: false),
                    update_user_id = table.Column<string>(type: "text", nullable: false),
                    update_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_user_company", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_m_user_company_m_user_user_id",
                        column: x => x.user_id,
                        principalTable: "m_user",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_user_company");

            migrationBuilder.DropTable(
                name: "m_user");
        }
    }
}
