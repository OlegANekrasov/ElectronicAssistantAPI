using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ElectronicAssistantAPI.Migrations
{
    public partial class Migration16052023 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesEquipment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TypeValue = table.Column<int>(type: "integer", nullable: true),
                    TypeEquipmentId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characteristics_TypesEquipment_TypeEquipmentId",
                        column: x => x.TypeEquipmentId,
                        principalTable: "TypesEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<string>(type: "text", nullable: false),
                    StatusId = table.Column<string>(type: "text", nullable: false),
                    TypeEquipmentId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Equipments_TypesEquipment_TypeEquipmentId",
                        column: x => x.TypeEquipmentId,
                        principalTable: "TypesEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentFeatures",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EquipmentId = table.Column<string>(type: "text", nullable: true),
                    CharacteristicId = table.Column<string>(type: "text", nullable: true),
                    TypeValue = table.Column<int>(type: "integer", nullable: true),
                    BoolValue = table.Column<bool>(type: "boolean", nullable: true),
                    IntValue = table.Column<int>(type: "integer", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "numeric", nullable: true),
                    StringValue = table.Column<string>(type: "text", nullable: true),
                    DateTimeValue = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EquipmentFeatures_Characteristics_CharacteristicId",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EquipmentFeatures_Equipments_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_TypeEquipmentId",
                table: "Characteristics",
                column: "TypeEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentFeatures_CharacteristicId",
                table: "EquipmentFeatures",
                column: "CharacteristicId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentFeatures_EquipmentId",
                table: "EquipmentFeatures",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_RoomId",
                table: "Equipments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_StatusId",
                table: "Equipments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_TypeEquipmentId",
                table: "Equipments",
                column: "TypeEquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentFeatures");

            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "TypesEquipment");
        }
    }
}
