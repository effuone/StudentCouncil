using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentCouncil.Data.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Extension = table.Column<string>(type: "char(4)", unicode: false, fixedLength: true, maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.FileId);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    GroupChar = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryID = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_To_Countries",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "CouncilUsers",
                columns: table => new
                {
                    CouncilUserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouncilUsers", x => x.CouncilUserId);
                    table.ForeignKey(
                        name: "FK_CouncilUsers_To_Documents",
                        column: x => x.FileId,
                        principalTable: "Documents",
                        principalColumn: "FileId");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentDocuments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    FileID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DepartmentDocuments_To_Departments",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_DepartmentDocuments_To_Documents",
                        column: x => x.FileID,
                        principalTable: "Documents",
                        principalColumn: "FileId");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_To_Cities",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_Locations_To_Countries",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    OpeningDate = table.Column<DateTime>(type: "date", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.SchoolId);
                    table.ForeignKey(
                        name: "FK_Schools_To_Locations",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CouncilUserId = table.Column<int>(type: "int", nullable: false),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_To_Groups",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_Students_To_Schools",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "SchoolId");
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                    table.ForeignKey(
                        name: "FK_Members_To_Students",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId");
                });

            migrationBuilder.CreateTable(
                name: "Curators",
                columns: table => new
                {
                    CuratorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BecameReason = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    BecameDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curators", x => x.CuratorId);
                    table.ForeignKey(
                        name: "FK_Curators_To_Departments",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_Curators_To_Members",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentMembers",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_DepartmentMembers_To_Departments",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_DepartmentMembers_To_Members",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanShort = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    PlanDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Investments = table.Column<decimal>(type: "money", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_Plans_To_Members",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuratorId = table.Column<int>(type: "int", nullable: false),
                    ReportName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_To_Curators",
                        column: x => x.CuratorId,
                        principalTable: "Curators",
                        principalColumn: "CuratorId");
                });

            migrationBuilder.CreateTable(
                name: "PlanDocuments",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    LastChangedTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PlanDocuments_To_Documents",
                        column: x => x.FileId,
                        principalTable: "Documents",
                        principalColumn: "FileId");
                    table.ForeignKey(
                        name: "FK_PlanDocuments_To_Plans",
                        column: x => x.PlanId,
                        principalTable: "Plans",
                        principalColumn: "PlanId");
                });

            migrationBuilder.CreateTable(
                name: "ReportDocuments",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: false),
                    LastChangedTime = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ReportDocuments_To_Documents",
                        column: x => x.FileId,
                        principalTable: "Documents",
                        principalColumn: "FileId");
                    table.ForeignKey(
                        name: "FK_ReportDocuments_To_Reports",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "ReportId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "QK_Cities_CityName",
                table: "Cities",
                column: "CityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CouncilUsers_FileId",
                table: "CouncilUsers",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "QK_Countries_CountryName",
                table: "Countries",
                column: "CountryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curators_DepartmentId",
                table: "Curators",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Curators_MemberId",
                table: "Curators",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDocuments_DepartmentId",
                table: "DepartmentDocuments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentDocuments_FileID",
                table: "DepartmentDocuments",
                column: "FileID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_DepartmentId",
                table: "DepartmentMembers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentMembers_MemberId",
                table: "DepartmentMembers",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "QK_Departments_DepartmentName",
                table: "Departments",
                column: "DepartmentName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CountryId",
                table: "Locations",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_StudentId",
                table: "Members",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDocuments_FileId",
                table: "PlanDocuments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanDocuments_PlanId",
                table: "PlanDocuments",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Plans_MemberId",
                table: "Plans",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDocuments_FileId",
                table: "ReportDocuments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDocuments_ReportId",
                table: "ReportDocuments",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CuratorId",
                table: "Reports",
                column: "CuratorId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_LocationId",
                table: "Schools",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "QK_Schools_SchoolName",
                table: "Schools",
                column: "SchoolName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupId",
                table: "Students",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolId",
                table: "Students",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CouncilUsers");

            migrationBuilder.DropTable(
                name: "DepartmentDocuments");

            migrationBuilder.DropTable(
                name: "DepartmentMembers");

            migrationBuilder.DropTable(
                name: "PlanDocuments");

            migrationBuilder.DropTable(
                name: "ReportDocuments");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Curators");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
