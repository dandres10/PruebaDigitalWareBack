using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Base.Datos.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(maxLength: 50, nullable: false),
                    SegundoNombre = table.Column<string>(maxLength: 50, nullable: true),
                    PrimerApellido = table.Column<string>(maxLength: 50, nullable: false),
                    SegundoApellido = table.Column<string>(maxLength: 50, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: true),
                    Cedula = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__06370DADD835A887", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Compra",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaCompra = table.Column<DateTime>(type: "datetime", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Compra__06370DAD216AE2A1", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__06370DAD224BF5AA", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "InventarioProducto",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Inventar__06370DAD1994EC35", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Productos_InventarioProductos_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Producto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Producto_Compra_Cliente",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoProducto = table.Column<int>(nullable: false),
                    CodigoCompra = table.Column<int>(nullable: false),
                    CodigoCliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__06370DADAEFC38D6", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Productos_Compras_Clientes_CodigoCliente",
                        column: x => x.CodigoCliente,
                        principalTable: "Cliente",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Compras_Clientes_CodigoCompra",
                        column: x => x.CodigoCompra,
                        principalTable: "Compra",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_Compras_Clientes_CodigoProducto",
                        column: x => x.CodigoProducto,
                        principalTable: "Producto",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UQ__Cliente__B4ADFE38FB4A6E10",
                table: "Cliente",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventarioProducto_CodigoProducto",
                table: "InventarioProducto",
                column: "CodigoProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Compra_Cliente_CodigoCliente",
                table: "Producto_Compra_Cliente",
                column: "CodigoCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Compra_Cliente_CodigoCompra",
                table: "Producto_Compra_Cliente",
                column: "CodigoCompra");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_Compra_Cliente_CodigoProducto",
                table: "Producto_Compra_Cliente",
                column: "CodigoProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventarioProducto");

            migrationBuilder.DropTable(
                name: "Producto_Compra_Cliente");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Compra");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
