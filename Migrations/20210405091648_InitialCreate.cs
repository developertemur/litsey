using Microsoft.EntityFrameworkCore.Migrations;

namespace litsey.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Profession",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profession", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomi = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomi = table.Column<string>(type: "TEXT", nullable: false),
                    professionId = table.Column<long>(type: "INTEGER", nullable: true),
                    grade = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.id);
                    table.ForeignKey(
                        name: "FK_Group_Profession_professionId",
                        column: x => x.professionId,
                        principalTable: "Profession",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupSubject",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    groupId = table.Column<long>(type: "INTEGER", nullable: true),
                    subjectId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSubject", x => x.id);
                    table.ForeignKey(
                        name: "FK_GroupSubject_Group_groupId",
                        column: x => x.groupId,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupSubject_Subject_subjectId",
                        column: x => x.subjectId,
                        principalTable: "Subject",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nomi = table.Column<string>(type: "TEXT", nullable: false),
                    surname = table.Column<string>(type: "TEXT", nullable: false),
                    sharif = table.Column<string>(type: "TEXT", nullable: false),
                    groupId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_Group_groupId",
                        column: x => x.groupId,
                        principalTable: "Group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mark",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    studentId = table.Column<long>(type: "INTEGER", nullable: true),
                    s1 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    s2 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    s3 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    s4 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    q1 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    q2 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    q3 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    q4 = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    olimpiada = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0"),
                    tanlov = table.Column<long>(type: "INTEGER", nullable: true, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mark", x => x.id);
                    table.ForeignKey(
                        name: "FK_Mark_Student_studentId",
                        column: x => x.studentId,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Group_professionId",
                table: "Group",
                column: "professionId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSubject_groupId",
                table: "GroupSubject",
                column: "groupId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupSubject_subjectId",
                table: "GroupSubject",
                column: "subjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Mark_studentId",
                table: "Mark",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_groupId",
                table: "Student",
                column: "groupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupSubject");

            migrationBuilder.DropTable(
                name: "Mark");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Profession");
        }
    }
}
