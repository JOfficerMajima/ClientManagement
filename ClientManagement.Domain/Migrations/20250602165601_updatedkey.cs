using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientManagement.Domain.Migrations
{
    /// <inheritdoc />
    public partial class updatedkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders");

            migrationBuilder.DropIndex(
                name: "IX_Founders_ClientId",
                table: "Founders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Founders");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Founders");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Founders",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "ClientName",
                table: "Clients",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "FounderClients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    FounderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FounderClients", x => new { x.ClientId, x.FounderId });
                    table.ForeignKey(
                        name: "FK_FounderClients_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FounderClients_Founders_FounderId",
                        column: x => x.FounderId,
                        principalTable: "Founders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FounderClients_FounderId",
                table: "FounderClients",
                column: "FounderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FounderClients");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Founders",
                newName: "ClientName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "ClientName");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Founders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Founders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Founders_ClientId",
                table: "Founders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Founders_Clients_ClientId",
                table: "Founders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
