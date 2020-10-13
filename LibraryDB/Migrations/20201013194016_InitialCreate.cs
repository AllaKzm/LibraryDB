using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryDB.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenID = table.Column<int>(type: "INT", nullable: false),
                    GenTitle = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false),
                    PositionTitle = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Salary = table.Column<double>(type: "FLOAT", nullable: false),
                    Duties = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Demands = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publicist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false),
                    PublicistTitle = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    City = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Readers",
                columns: table => new
                {
                    ReadID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Gender = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    PassportData = table.Column<string>(type: "VARCHAR(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readers", x => x.ReadID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Gender = table.Column<string>(type: "CHAR(5)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    ID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpID);
                    table.ForeignKey(
                        name: "FK_Employee_Positions_ID",
                        column: x => x.ID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "INT", nullable: false),
                    BookTitle = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Author = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    PubYear = table.Column<DateTime>(type: "DateTime", nullable: false),
                    GenID = table.Column<int>(type: "INT", nullable: false),
                    ID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenID",
                        column: x => x.GenID,
                        principalTable: "Genres",
                        principalColumn: "GenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publicist_ID",
                        column: x => x.ID,
                        principalTable: "Publicist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssuedBooks",
                columns: table => new
                {
                    ReturnMark = table.Column<string>(type: "CHAR (5)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "DateTime", nullable: false),
                    EmpID = table.Column<int>(type: "INT", nullable: false),
                    ReadID = table.Column<int>(type: "INT", nullable: false),
                    BookID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedBooks", x => x.ReturnMark);
                    table.ForeignKey(
                        name: "FK_IssuedBooks_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssuedBooks_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssuedBooks_Readers_ReadID",
                        column: x => x.ReadID,
                        principalTable: "Readers",
                        principalColumn: "ReadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenID",
                table: "Books",
                column: "GenID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_ID",
                table: "Books",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ID",
                table: "Employee",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedBooks_BookID",
                table: "IssuedBooks",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedBooks_EmpID",
                table: "IssuedBooks",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedBooks_ReadID",
                table: "IssuedBooks",
                column: "ReadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuedBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Readers");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publicist");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
