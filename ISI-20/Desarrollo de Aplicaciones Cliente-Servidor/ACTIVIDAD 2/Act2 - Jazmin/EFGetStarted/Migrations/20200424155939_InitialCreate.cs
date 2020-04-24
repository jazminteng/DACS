using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Matricula = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Matricula);
                });

            migrationBuilder.CreateTable(
                name: "Casos",
                columns: table => new
                {
                    CasoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Estado = table.Column<string>(nullable: true),
                    MedicosMatricula = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casos", x => x.CasoId);
                    table.ForeignKey(
                        name: "FK_Casos_Medicos_MedicosMatricula",
                        column: x => x.MedicosMatricula,
                        principalTable: "Medicos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    PacienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Dni = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    CasosForeignKey = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.PacienteId);
                    table.ForeignKey(
                        name: "FK_Pacientes_Casos_CasosForeignKey",
                        column: x => x.CasosForeignKey,
                        principalTable: "Casos",
                        principalColumn: "CasoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pruebas",
                columns: table => new
                {
                    PruebaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Resultado = table.Column<bool>(nullable: false),
                    CasosCasoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruebas", x => x.PruebaId);
                    table.ForeignKey(
                        name: "FK_Pruebas_Casos_CasosCasoId",
                        column: x => x.CasosCasoId,
                        principalTable: "Casos",
                        principalColumn: "CasoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DescripcionSintomas = table.Column<string>(nullable: true),
                    Diagnostico = table.Column<string>(nullable: true),
                    MedicosMatricula = table.Column<int>(nullable: true),
                    PacientesPacienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicosMatricula",
                        column: x => x.MedicosMatricula,
                        principalTable: "Medicos",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacientesPacienteId",
                        column: x => x.PacientesPacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "PacienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Casos_MedicosMatricula",
                table: "Casos",
                column: "MedicosMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicosMatricula",
                table: "Consultas",
                column: "MedicosMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacientesPacienteId",
                table: "Consultas",
                column: "PacientesPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CasosForeignKey",
                table: "Pacientes",
                column: "CasosForeignKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pruebas_CasosCasoId",
                table: "Pruebas",
                column: "CasosCasoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Pruebas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Casos");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
