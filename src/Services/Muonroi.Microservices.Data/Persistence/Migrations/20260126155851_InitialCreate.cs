using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Muonroi.Microservices.Data.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MLanguages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Icon = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    IsDisabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLanguages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MPermissionAuditLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    PerformedBy = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPermissionAuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MPermissionGroups",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPermissionGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MRefreshTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: false),
                    TokenValidityKey = table.Column<string>(type: "TEXT", nullable: false),
                    ExpiredDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RevokedDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastUsedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReasonRevoked = table.Column<string>(type: "TEXT", nullable: false),
                    IsRevoked = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRefreshTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MRolePermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PermissionId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRolePermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MRoles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    IsStatic = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MUserLoginAttempts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserGuid = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserNameOrEmailAddress = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ClientIpAddress = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    ClientName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    BrowserInfo = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Result = table.Column<byte>(type: "INTEGER", nullable: false),
                    AttemptTime = table.Column<int>(type: "INTEGER", nullable: false),
                    LockTo = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUserLoginAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MUserRoles",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "MUsers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    PasswordResetCode = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    IsPhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    SecurityStamp = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    IsTwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    NormalizedEmailAddress = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Salt = table.Column<string>(type: "TEXT", nullable: true),
                    ProfilePictureId = table.Column<int>(type: "INTEGER", nullable: true),
                    ShouldChangePasswordOnNextLogin = table.Column<bool>(type: "INTEGER", nullable: false),
                    SignInTokenExpireTimeUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsUseThirdPartyLogin = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExternalLoginProvider = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalLoginToken = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MUserTokens",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUserTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Samples",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Samples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MPermissions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    IsGranted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                    Type = table.Column<int>(type: "INTEGER", maxLength: 32, nullable: false),
                    UiKey = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    ParentUiKey = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    Label = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Icon = table.Column<string>(type: "TEXT", maxLength: 128, nullable: true),
                    Order = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 512, nullable: true),
                    ParentId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PermissionGroupId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDateTs = table.Column<double>(type: "REAL", nullable: false),
                    LastModificationTimeTs = table.Column<double>(type: "REAL", nullable: true),
                    DeletedDateTs = table.Column<double>(type: "REAL", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatorUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LastModificationUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DeletedUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    PermissionGroupId1 = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MPermissions", x => x.Id);
                    table.UniqueConstraint("AK_MPermissions_EntityId", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_MPermissions_MPermissionGroups_PermissionGroupId1",
                        column: x => x.PermissionGroupId1,
                        principalTable: "MPermissionGroups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MPermissions_MPermissions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "MPermissions",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MLanguages_Name",
                table: "MLanguages",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MPermissionAuditLogs_RoleId",
                table: "MPermissionAuditLogs",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MPermissionGroups_Name",
                table: "MPermissionGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MPermissions_Group_UiKey",
                table: "MPermissions",
                columns: new[] { "PermissionGroupId", "UiKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MPermissions_Name",
                table: "MPermissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MPermissions_ParentId",
                table: "MPermissions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_MPermissions_PermissionGroupId1",
                table: "MPermissions",
                column: "PermissionGroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_MRoles_Name",
                table: "MRoles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MUserLoginAttempt_UserNameOrEmailAddress",
                table: "MUserLoginAttempts",
                column: "UserNameOrEmailAddress");

            migrationBuilder.CreateIndex(
                name: "IX_MUser_UserName",
                table: "MUsers",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MUserToken_LoginProvider",
                table: "MUserTokens",
                column: "LoginProvider");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MLanguages");

            migrationBuilder.DropTable(
                name: "MPermissionAuditLogs");

            migrationBuilder.DropTable(
                name: "MPermissions");

            migrationBuilder.DropTable(
                name: "MRefreshTokens");

            migrationBuilder.DropTable(
                name: "MRolePermissions");

            migrationBuilder.DropTable(
                name: "MRoles");

            migrationBuilder.DropTable(
                name: "MUserLoginAttempts");

            migrationBuilder.DropTable(
                name: "MUserRoles");

            migrationBuilder.DropTable(
                name: "MUsers");

            migrationBuilder.DropTable(
                name: "MUserTokens");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Samples");

            migrationBuilder.DropTable(
                name: "MPermissionGroups");
        }
    }
}
