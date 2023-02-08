using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace listtodo.Migrations
{
    public partial class IntialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "Descripcion", "Nombre", "Peso" },
                values: new object[,]
                {
                    { new Guid("20047306-0797-461d-800d-74e736547342"), null, "Actividades Personales", 30 },
                    { new Guid("2ccf4029-8541-40f4-b897-76179426ec58"), null, "Actividades Académicas", 60 },
                    { new Guid("5a43313d-6e2a-4666-b098-14c6202585cd"), null, "Actividades Profesionales", 20 }
                });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaId", "CategoriaId", "Descripcion", "Fecha_Creacion", "PrioridadTarea", "Titulo" },
                values: new object[,]
                {
                    { new Guid("56e5f716-7371-42b5-b406-f71ec23e610a"), new Guid("5a43313d-6e2a-4666-b098-14c6202585cd"), "Realizar el curso en cualquier momento", new DateTime(2023, 2, 8, 20, 35, 0, 124, DateTimeKind.Utc).AddTicks(5182), 0, "Realizar curso de Python" },
                    { new Guid("56e5f716-7371-42b5-b406-f71ec23e610b"), new Guid("20047306-0797-461d-800d-74e736547342"), "Realizar el curso en cualquier momento", new DateTime(2023, 2, 8, 20, 35, 0, 124, DateTimeKind.Utc).AddTicks(5185), 0, "Ir a casa de mi mamá" },
                    { new Guid("56e5f716-7371-42b5-b406-f71ec23e610e"), new Guid("5a43313d-6e2a-4666-b098-14c6202585cd"), "Realizar el curso en cualquier momento", new DateTime(2023, 2, 8, 20, 35, 0, 124, DateTimeKind.Utc).AddTicks(5172), 0, "Realizar curso de Flask" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("2ccf4029-8541-40f4-b897-76179426ec58"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("56e5f716-7371-42b5-b406-f71ec23e610a"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("56e5f716-7371-42b5-b406-f71ec23e610b"));

            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaId",
                keyValue: new Guid("56e5f716-7371-42b5-b406-f71ec23e610e"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("20047306-0797-461d-800d-74e736547342"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaId",
                keyValue: new Guid("5a43313d-6e2a-4666-b098-14c6202585cd"));

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Tarea",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Categoria",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
