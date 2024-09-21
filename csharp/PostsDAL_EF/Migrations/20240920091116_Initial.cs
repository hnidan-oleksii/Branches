using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PostsDAL_EF.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "branches",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_branches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    content = table.Column<string>(type: "text", nullable: false),
                    branchid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    createdat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_branches_branchid",
                        column: x => x.branchid,
                        principalTable: "branches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_posts_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "postvotes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    postid = table.Column<int>(type: "integer", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: false),
                    votetype = table.Column<short>(type: "smallint", nullable: false),
                    votedat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postvotes", x => x.id);
                    table.CheckConstraint("CK_PostVotes_VoteType", "votetype IN (-1, 1)");
                    table.ForeignKey(
                        name: "FK_postvotes_posts_postid",
                        column: x => x.postid,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_postvotes_users_userid",
                        column: x => x.userid,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_branchid",
                table: "posts",
                column: "branchid");

            migrationBuilder.CreateIndex(
                name: "IX_posts_userid",
                table: "posts",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_postvotes_postid_userid",
                table: "postvotes",
                columns: new[] { "postid", "userid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_postvotes_userid",
                table: "postvotes",
                column: "userid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postvotes");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "branches");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
