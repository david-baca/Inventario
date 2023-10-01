using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace inventarioAPI.Migrations
{
    /// <inheritdoc />
    public partial class Inventario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    PkArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.PkArea);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    PkCatalogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.PkCatalogo);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Fuentes",
                columns: table => new
                {
                    PkFuente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fuentes", x => x.PkFuente);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Provedores",
                columns: table => new
                {
                    PkProvedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provedores", x => x.PkProvedor);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    PkCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(type: "longtext", nullable: false),
                    Modelo = table.Column<string>(type: "longtext", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    FkCatalogo = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.PkCategoria);
                    table.ForeignKey(
                        name: "FK_Categorias_Catalogos_FkCatalogo",
                        column: x => x.FkCatalogo,
                        principalTable: "Catalogos",
                        principalColumn: "PkCatalogo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Responsables",
                columns: table => new
                {
                    PkResponsable = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    ApellidoP = table.Column<string>(type: "longtext", nullable: false),
                    ApellidoM = table.Column<string>(type: "longtext", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsables", x => x.PkResponsable);
                    table.ForeignKey(
                        name: "FK_Responsables_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombres = table.Column<string>(type: "longtext", nullable: false),
                    ApellidoP = table.Column<string>(name: "Apellido_P", type: "longtext", nullable: false),
                    ApellidoM = table.Column<string>(name: "Apellido_M", type: "longtext", nullable: false),
                    Contrseña = table.Column<string>(type: "longtext", nullable: false),
                    NUsuario = table.Column<string>(name: "N_Usuario", type: "longtext", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    PkArticulo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FEQADD = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FEQASC = table.Column<DateTime>(name: "FEQ_ASC", type: "datetime(6)", nullable: false),
                    Costo = table.Column<int>(type: "int", nullable: false),
                    Polisa = table.Column<string>(type: "longtext", nullable: false),
                    Factura = table.Column<string>(type: "longtext", nullable: false),
                    Token = table.Column<string>(type: "longtext", nullable: false),
                    FkCategoria = table.Column<int>(type: "int", nullable: false),
                    FkProvedor = table.Column<int>(type: "int", nullable: false),
                    FkFuente = table.Column<int>(type: "int", nullable: false),
                    FkArea = table.Column<int>(type: "int", nullable: false),
                    FkResponsable = table.Column<int>(type: "int", nullable: false),
                    EstadoArticulo = table.Column<bool>(name: "Estado_Articulo", type: "tinyint(1)", nullable: false),
                    Estado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.PkArticulo);
                    table.ForeignKey(
                        name: "FK_Articulos_Areas_FkArea",
                        column: x => x.FkArea,
                        principalTable: "Areas",
                        principalColumn: "PkArea",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_FkCategoria",
                        column: x => x.FkCategoria,
                        principalTable: "Categorias",
                        principalColumn: "PkCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Fuentes_FkFuente",
                        column: x => x.FkFuente,
                        principalTable: "Fuentes",
                        principalColumn: "PkFuente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Provedores_FkProvedor",
                        column: x => x.FkProvedor,
                        principalTable: "Provedores",
                        principalColumn: "PkProvedor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Responsables_FkResponsable",
                        column: x => x.FkResponsable,
                        principalTable: "Responsables",
                        principalColumn: "PkResponsable",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_FkArea",
                table: "Articulos",
                column: "FkArea");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_FkCategoria",
                table: "Articulos",
                column: "FkCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_FkFuente",
                table: "Articulos",
                column: "FkFuente");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_FkProvedor",
                table: "Articulos",
                column: "FkProvedor");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_FkResponsable",
                table: "Articulos",
                column: "FkResponsable");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_FkCatalogo",
                table: "Categorias",
                column: "FkCatalogo");

            migrationBuilder.CreateIndex(
                name: "IX_Responsables_FkRol",
                table: "Responsables",
                column: "FkRol");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRol",
                table: "Usuarios",
                column: "FkRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Fuentes");

            migrationBuilder.DropTable(
                name: "Provedores");

            migrationBuilder.DropTable(
                name: "Responsables");

            migrationBuilder.DropTable(
                name: "Catalogos");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
