using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ASP.NET_CRUD_example_2.Migrations
{
    public partial class CreacionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "alumnos",
                schema: "public",
                columns: table => new
                {
                    alumno_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alumno_nombre = table.Column<string>(type: "text", nullable: false),
                    alumno_apellidos = table.Column<string>(type: "text", nullable: false),
                    alumno_email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnos", x => x.alumno_id);
                });

            migrationBuilder.CreateTable(
                name: "asignaturas",
                schema: "public",
                columns: table => new
                {
                    asignatura_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    asignatura_nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignaturas", x => x.asignatura_id);
                });

            migrationBuilder.CreateTable(
                name: "relalumasig",
                schema: "public",
                columns: table => new
                {
                    relAlumAsig_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    alumno_id = table.Column<int>(type: "integer", nullable: false),
                    asignatura_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relalumasig", x => x.relAlumAsig_id);
                    table.ForeignKey(
                        name: "FK_relalumasig_alumnos_alumno_id",
                        column: x => x.alumno_id,
                        principalSchema: "public",
                        principalTable: "alumnos",
                        principalColumn: "alumno_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_relalumasig_asignaturas_asignatura_id",
                        column: x => x.asignatura_id,
                        principalSchema: "public",
                        principalTable: "asignaturas",
                        principalColumn: "asignatura_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_relalumasig_alumno_id",
                schema: "public",
                table: "relalumasig",
                column: "alumno_id");

            migrationBuilder.CreateIndex(
                name: "IX_relalumasig_asignatura_id",
                schema: "public",
                table: "relalumasig",
                column: "asignatura_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "relalumasig",
                schema: "public");

            migrationBuilder.DropTable(
                name: "alumnos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "asignaturas",
                schema: "public");
        }
    }
}
