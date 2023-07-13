using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portifolio.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableContactAddColumnCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Contacts",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Contacts");
        }
    }
}
