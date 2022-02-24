﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class PetOwnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Pets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets",
                column: "petOwnerid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets",
                column: "petOwnerid",
                principalTable: "PetOwners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pets_PetOwners_petOwnerid",
                table: "Pets");

            migrationBuilder.DropIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Pets");
        }
    }
}
