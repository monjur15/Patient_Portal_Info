using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientPortal.Migrations
{
    /// <inheritdoc />
    public partial class initfirstdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NCDs",
                columns: table => new
                {
                    NCDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NCDName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NCDs", x => x.NCDID);
                });

            migrationBuilder.CreateTable(
                name: "PatientsInformation",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientsInformation", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "DiseaseInformation",
                columns: table => new
                {
                    DiseaseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiseaseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiseaseInformation", x => x.DiseaseID);
                    table.ForeignKey(
                        name: "FK_DiseaseInformation_PatientsInformation_PatientId",
                        column: x => x.PatientId,
                        principalTable: "PatientsInformation",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiseaseInformation_PatientId",
                table: "DiseaseInformation",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiseaseInformation");

            migrationBuilder.DropTable(
                name: "NCDs");

            migrationBuilder.DropTable(
                name: "PatientsInformation");
        }
    }
}
