using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(252)", nullable: false),
                    PermissionName = table.Column<string>(type: "varchar(252)", nullable: false),
                    PermissionCode = table.Column<string>(type: "varchar(252)", nullable: false),
                    PermissionOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(252)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(252)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(252)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(252)", nullable: false),
                    RoleName = table.Column<string>(type: "varchar(252)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(252)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(252)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(252)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(252)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(252)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(252)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(50)", nullable: false),
                    Address = table.Column<string>(type: "varchar(252)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(252)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(252)", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(252)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    PermissionId = table.Column<string>(type: "varchar(252)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(252)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(252)", nullable: false),
                    RoleId = table.Column<string>(type: "varchar(252)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "PermissionCode", "PermissionName", "PermissionOrder", "Status" },
                values: new object[,]
                {
                    { "1", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9381), "", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9392), "USER", "USER", 1, 0 },
                    { "2", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9394), "", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9394), "USER-DELETE", "USER-DELETE", 2, 0 },
                    { "3", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9396), "", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9396), "USER-UPDATE", "USER-UPDATE", 2, 0 },
                    { "4", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9397), "", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9397), "USER-ADD", "USER-ADD", 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Description", "ModifiedBy", "ModifiedOn", "RoleName", "Status" },
                values: new object[,]
                {
                    { "1f6e351a-e9e0-43a4-8706-4626f3813977", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9553), "", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9553), "UserViewer", 0 },
                    { "gafsakfi-efhjsk-fshdbe-334jsfgs-486h", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9516), "", "", new DateTime(2022, 9, 11, 19, 43, 4, 658, DateTimeKind.Local).AddTicks(9517), "Admin", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedOn", "DateOfBirth", "Description", "Email", "FullName", "Gender", "ModifiedBy", "ModifiedOn", "Password", "Phone", "Status", "UserName" },
                values: new object[,]
                {
                    { "0a938ba1-b17d-477d-b4ae-53e30c928d52", "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", "CMCglobal_AGOS@gmail.com", "Viewer", 0, "", null, "Viewer", "", 0, "Viewer" },
                    { "dhgfd55-4234jdf-efhjsk-fshdbe-334jsfgs-486sdh", "", "", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "", "CMCglobal_AGOS@gmail.com", "Admin", 0, "", null, "Admin", "", 0, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { "1", "gafsakfi-efhjsk-fshdbe-334jsfgs-486h" },
                    { "2", "gafsakfi-efhjsk-fshdbe-334jsfgs-486h" },
                    { "3", "gafsakfi-efhjsk-fshdbe-334jsfgs-486h" },
                    { "4", "gafsakfi-efhjsk-fshdbe-334jsfgs-486h" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "gafsakfi-efhjsk-fshdbe-334jsfgs-486h", "dhgfd55-4234jdf-efhjsk-fshdbe-334jsfgs-486sdh" });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
