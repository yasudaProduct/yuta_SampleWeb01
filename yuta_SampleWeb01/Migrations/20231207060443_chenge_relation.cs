using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yuta_SampleWeb01.Migrations
{
    public partial class chenge_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "t_data_a",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_t_data_a_user_id",
                table: "t_data_a",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_t_data_a_t_user_company_user_id",
                table: "t_data_a",
                column: "user_id",
                principalTable: "t_user_company",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_data_a_t_user_company_user_id",
                table: "t_data_a");

            migrationBuilder.DropIndex(
                name: "IX_t_data_a_user_id",
                table: "t_data_a");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "t_data_a",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
