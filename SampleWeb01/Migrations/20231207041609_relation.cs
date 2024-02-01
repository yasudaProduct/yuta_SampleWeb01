using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleWeb01.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_data_a_detail",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    column1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    column2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    column3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    column4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    column5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataId = table.Column<int>(type: "int", nullable: false),
                    create_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_pgm_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_data_a_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_data_a_detail_t_data_a_DataId",
                        column: x => x.DataId,
                        principalTable: "t_data_a",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_data_a_detail_DataId",
                table: "t_data_a_detail",
                column: "DataId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_data_a_detail");
        }
    }
}
