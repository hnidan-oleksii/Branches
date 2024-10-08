using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "wall_posts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_user_id = table.Column<int>(type: "integer", nullable: false),
                    profile_user_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wall_posts", x => x.id);
                    table.ForeignKey(
                        name: "fk_wall_posts_users_author_user_id",
                        column: x => x.author_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_wall_posts_users_profile_user_id",
                        column: x => x.profile_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wall_comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    post_id = table.Column<int>(type: "integer", nullable: false),
                    author_user_id = table.Column<int>(type: "integer", nullable: false),
                    content = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wall_comments", x => x.id);
                    table.ForeignKey(
                        name: "fk_wall_comments_users_author_user_id",
                        column: x => x.author_user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_wall_comments_wall_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "wall_posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Kaycee Will" },
                    { 2, "Corine Rau" },
                    { 3, "Marcus Breitenberg" },
                    { 4, "Isabelle Rolfson" },
                    { 5, "Xzavier Walter" },
                    { 6, "Zackery Boehm" },
                    { 7, "Clovis Rosenbaum" },
                    { 8, "Frieda Bruen" },
                    { 9, "Adela Kreiger" },
                    { 10, "Marie Feest" },
                    { 11, "Leanne Brekke" },
                    { 12, "Nils Schroeder" },
                    { 13, "Otis Kuhlman" },
                    { 14, "Gage Torp" },
                    { 15, "Asa Kerluke" },
                    { 16, "Russel Schinner" },
                    { 17, "Ignatius Runolfsdottir" },
                    { 18, "Tyrique Flatley" },
                    { 19, "Filiberto Fisher" },
                    { 20, "Frieda Kuhic" },
                    { 21, "Petra Johnston" },
                    { 22, "Lauriane Wisoky" },
                    { 23, "Shayna Jenkins" },
                    { 24, "Hillard Franecki" },
                    { 25, "Trystan Kuhic" },
                    { 26, "Jenifer Berge" },
                    { 27, "Alessia Daniel" },
                    { 28, "Berenice Denesik" },
                    { 29, "Annamarie Volkman" },
                    { 30, "Jasmin Treutel" }
                });

            migrationBuilder.InsertData(
                table: "wall_posts",
                columns: new[] { "id", "author_user_id", "content", "created_at", "profile_user_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 15, "At nam sed suscipit sed ipsa velit ut omnis et. Esse dignissimos qui quo qui atque. Explicabo eos non quos aspernatur adipisci aut eos est culpa. Sequi fugit et optio ratione omnis temporibus facere.", new DateTime(2024, 8, 5, 20, 6, 41, 801, DateTimeKind.Utc).AddTicks(9195), 12, new DateTime(2024, 10, 7, 8, 48, 1, 369, DateTimeKind.Utc).AddTicks(9713) },
                    { 2, 6, "Repudiandae nemo optio et quo blanditiis eveniet omnis quisquam. Facere et perspiciatis dignissimos. Beatae ut quaerat ipsa ducimus est praesentium dolores aut consequuntur.", new DateTime(2024, 7, 30, 12, 37, 45, 104, DateTimeKind.Utc).AddTicks(463), 16, null },
                    { 3, 24, "Sint rerum sit et consequuntur eius. Natus sint ea. Ratione soluta et. A et et facilis. Veniam minus pariatur natus provident. Porro quis voluptas adipisci aspernatur qui dolores dolores.", new DateTime(2024, 7, 6, 7, 5, 10, 34, DateTimeKind.Utc).AddTicks(9512), 18, null },
                    { 4, 3, "At quia vel nam est ut est. Dolor delectus magni nisi quod provident adipisci consequatur et. Vel aperiam doloribus ea.", new DateTime(2024, 4, 23, 23, 28, 4, 397, DateTimeKind.Utc).AddTicks(7064), 9, null },
                    { 5, 15, "Et asperiores molestiae quia expedita perferendis mollitia voluptatem delectus. Accusamus vero atque molestiae sequi. Possimus labore velit perspiciatis pariatur nihil sunt ratione. Sequi quis qui voluptatem aut quis aliquid. Non sit tenetur dolores tempora maxime. Accusamus neque eos.", new DateTime(2024, 4, 13, 5, 18, 8, 600, DateTimeKind.Utc).AddTicks(8601), 27, new DateTime(2024, 10, 7, 10, 52, 59, 34, DateTimeKind.Utc).AddTicks(2523) },
                    { 6, 27, "Facilis amet possimus aut qui aut architecto neque ratione consequatur. Dolore eos unde. Libero pariatur qui et et. Et deserunt maiores ea culpa et id molestias nam.", new DateTime(2024, 10, 7, 12, 3, 49, 824, DateTimeKind.Utc).AddTicks(313), 9, null },
                    { 7, 18, "Neque consectetur neque eaque repellendus facere et quo exercitationem. Aliquid incidunt aspernatur vero ad autem. Esse aut nihil sunt dolorem. Nemo consequatur molestias voluptatem similique.", new DateTime(2024, 2, 10, 4, 1, 51, 110, DateTimeKind.Utc).AddTicks(7447), 4, null },
                    { 8, 15, "Ut explicabo sunt ut qui aut est. Minus omnis quos possimus occaecati rem ratione delectus est. Pariatur deserunt accusamus inventore voluptatem eos ipsum et aut accusantium. Consequuntur officia tempore. Dolorem nihil illum error blanditiis officia qui omnis excepturi aut. Asperiores repellendus possimus magnam a ipsam maiores hic voluptates dolore.", new DateTime(2024, 8, 2, 17, 24, 54, 57, DateTimeKind.Utc).AddTicks(118), 8, null },
                    { 9, 16, "Laboriosam eligendi saepe quo magni ipsum et unde odio. Temporibus expedita beatae corporis placeat quos quidem ut. Vel praesentium ad sit quas ut soluta similique.", new DateTime(2024, 6, 27, 0, 48, 56, 784, DateTimeKind.Utc).AddTicks(1456), 16, new DateTime(2024, 10, 7, 8, 11, 54, 595, DateTimeKind.Utc).AddTicks(469) },
                    { 10, 7, "Architecto aperiam facilis aliquid nihil nihil consequatur. Ex ullam voluptatem ut error. Enim doloribus reiciendis et fuga quia quia. Sunt blanditiis minus et ut voluptate quaerat qui aut.", new DateTime(2024, 2, 28, 11, 36, 29, 186, DateTimeKind.Utc).AddTicks(5504), 23, new DateTime(2024, 10, 7, 13, 57, 43, 580, DateTimeKind.Utc).AddTicks(1103) },
                    { 11, 5, "Quisquam nobis cupiditate ullam quia quasi velit. Quis ipsum aspernatur ut officiis quam. Est et illo. Officiis vel doloribus accusantium. Ullam dolores ab nulla.", new DateTime(2024, 7, 9, 7, 41, 16, 45, DateTimeKind.Utc).AddTicks(2190), 28, new DateTime(2024, 10, 7, 15, 18, 57, 495, DateTimeKind.Utc).AddTicks(9157) },
                    { 12, 28, "Nam cumque tenetur fugiat ut earum voluptas officiis. Vel modi velit magni id voluptate qui quo. Voluptatibus et in ullam qui optio non dolor vel cupiditate. Aperiam error incidunt enim perspiciatis quis illo ea. Facere libero voluptate impedit quasi. Mollitia aut quidem facere aut.", new DateTime(2024, 7, 26, 6, 40, 38, 661, DateTimeKind.Utc).AddTicks(3479), 6, new DateTime(2024, 10, 7, 10, 20, 33, 505, DateTimeKind.Utc).AddTicks(9116) },
                    { 13, 5, "Quisquam unde quibusdam recusandae laborum cupiditate ipsum reiciendis. Harum aut voluptatibus veritatis omnis animi sed sit reiciendis eaque. Aliquid quia ex.", new DateTime(2023, 12, 16, 18, 47, 48, 765, DateTimeKind.Utc).AddTicks(3488), 11, new DateTime(2024, 10, 7, 23, 19, 5, 991, DateTimeKind.Utc).AddTicks(3867) },
                    { 14, 10, "Fugit aut laborum iure sapiente doloremque est odio veniam. Fugiat soluta pariatur vero quis aut et. Est distinctio et qui ex. Magni aut et adipisci reprehenderit vitae est. Est repudiandae ducimus dicta fugit.", new DateTime(2024, 1, 3, 7, 2, 9, 745, DateTimeKind.Utc).AddTicks(5838), 1, null },
                    { 15, 19, "Porro dolor illo recusandae tempora nobis modi. Velit dolorem consequatur atque. Facere dolorem dolore. Provident officiis nihil rem est consectetur sed aliquid corporis omnis.", new DateTime(2024, 1, 14, 8, 51, 57, 792, DateTimeKind.Utc).AddTicks(3911), 1, null },
                    { 16, 10, "Libero voluptatem provident aperiam soluta facere atque reiciendis. Eveniet et aspernatur nemo enim et sed. Ad voluptatibus dignissimos. Veniam exercitationem explicabo quidem aut. Ad nostrum eligendi odit illo consequatur. Occaecati dolorum minus ipsa.", new DateTime(2024, 1, 6, 3, 37, 6, 578, DateTimeKind.Utc).AddTicks(6959), 27, null },
                    { 17, 4, "Consectetur inventore veniam qui et possimus omnis cupiditate. Eius veniam ut quae molestiae. Ad et id voluptatum earum at est. Repellat et est sit harum.", new DateTime(2024, 9, 9, 10, 56, 11, 680, DateTimeKind.Utc).AddTicks(3635), 26, null },
                    { 18, 14, "Recusandae vitae possimus quo voluptas qui minus dolores. Voluptatem impedit dolorem adipisci. Neque et et voluptatum suscipit. Doloribus exercitationem sint doloribus minima vitae alias ut. Architecto eligendi ea quis.", new DateTime(2024, 5, 19, 8, 35, 58, 488, DateTimeKind.Utc).AddTicks(8668), 9, null },
                    { 19, 25, "Neque fugiat et. Voluptatem adipisci rerum placeat laudantium deleniti exercitationem. Laudantium rerum quia maiores. Et officiis laborum suscipit quia nobis. Consequatur aliquam qui non voluptatem culpa autem. Qui sed qui dolor quam quia.", new DateTime(2023, 11, 4, 21, 20, 47, 723, DateTimeKind.Utc).AddTicks(5100), 14, null },
                    { 20, 4, "Quia autem eligendi mollitia. Illum est quia nesciunt labore et quibusdam. Nesciunt repudiandae reiciendis. Voluptas voluptates possimus. Occaecati qui quibusdam ullam.", new DateTime(2024, 10, 5, 16, 31, 15, 911, DateTimeKind.Utc).AddTicks(5113), 29, null },
                    { 21, 20, "Voluptatum nisi porro corporis ad. Dolores quia aspernatur veniam hic distinctio a ab repudiandae aliquam. Architecto nam aut magni. Et aut eos. Qui repudiandae necessitatibus est laboriosam culpa.", new DateTime(2024, 4, 11, 2, 52, 22, 317, DateTimeKind.Utc).AddTicks(175), 16, new DateTime(2024, 10, 8, 3, 0, 49, 755, DateTimeKind.Utc).AddTicks(6556) },
                    { 22, 5, "Voluptatem earum voluptates minus dicta ipsum. Voluptatem dicta tenetur asperiores. Dolor iste quas tenetur ex possimus fuga voluptatem. Molestias libero maxime nostrum perferendis et consequatur. Recusandae odio quam quos et qui quae atque nobis. Perspiciatis minus error vel sit porro deleniti.", new DateTime(2024, 7, 8, 17, 49, 55, 489, DateTimeKind.Utc).AddTicks(7251), 21, new DateTime(2024, 10, 7, 19, 48, 59, 786, DateTimeKind.Utc).AddTicks(3843) },
                    { 23, 22, "Enim rem ut voluptates veritatis autem recusandae molestiae eos in. Rerum vitae sint est esse ex qui sed sit. Molestiae soluta illo ut tempore voluptatum.", new DateTime(2024, 8, 22, 7, 40, 40, 888, DateTimeKind.Utc).AddTicks(5132), 12, new DateTime(2024, 10, 7, 12, 10, 56, 110, DateTimeKind.Utc).AddTicks(4780) },
                    { 24, 16, "Quia nam incidunt impedit et quo dolor nesciunt sint error. Nobis ipsam qui voluptas aut. Quis velit aut magni aut ut. Quo inventore animi reprehenderit quo. Officia consequuntur odit molestias quia fugit inventore eius qui.", new DateTime(2023, 11, 21, 17, 56, 1, 212, DateTimeKind.Utc).AddTicks(753), 24, new DateTime(2024, 10, 7, 8, 10, 37, 200, DateTimeKind.Utc).AddTicks(5842) },
                    { 25, 2, "Dignissimos alias enim voluptatibus. Facilis ratione ipsam unde iure ipsa animi ullam inventore. Minima iusto veniam necessitatibus aperiam dignissimos. Inventore beatae eligendi. Totam est maiores similique et totam.", new DateTime(2024, 6, 14, 2, 33, 7, 649, DateTimeKind.Utc).AddTicks(42), 9, null },
                    { 26, 11, "Voluptatem excepturi dolor repellendus consequatur aut voluptatem id. Tempora temporibus est assumenda minima. Et dolorum nisi nihil et quibusdam eius quisquam. Consequuntur maiores eius quia iusto. Voluptatem qui ullam dolores et eos ut aut.", new DateTime(2024, 8, 14, 9, 49, 57, 480, DateTimeKind.Utc).AddTicks(955), 20, null },
                    { 27, 4, "Voluptatem eum et et non. Sint impedit et illum possimus hic ut fugiat aut. Neque vel ratione sapiente aperiam aliquid odio aspernatur soluta est. Pariatur tempora voluptas voluptatibus ab tempore et earum nemo dolore. Ab quasi velit et ex dolorum.", new DateTime(2024, 6, 23, 16, 56, 29, 704, DateTimeKind.Utc).AddTicks(8826), 18, null },
                    { 28, 9, "Nobis molestias aliquam rerum officia ea eaque. Harum omnis atque et sit et. Maxime voluptas voluptas recusandae ipsam. Mollitia commodi perspiciatis voluptate porro.", new DateTime(2024, 5, 21, 2, 25, 36, 546, DateTimeKind.Utc).AddTicks(7665), 10, null },
                    { 29, 21, "Reiciendis tempore labore adipisci illo. Aspernatur iusto exercitationem voluptatem delectus et possimus. Sed nulla error.", new DateTime(2024, 8, 12, 11, 32, 59, 517, DateTimeKind.Utc).AddTicks(9633), 24, null },
                    { 30, 18, "Dicta autem fugit et eaque voluptatem est. Architecto fuga in aliquid corporis error aperiam laboriosam qui cum. Delectus iste incidunt atque est. Corporis ad architecto commodi necessitatibus alias atque harum dolores. Officia nihil deleniti ut molestiae debitis consequatur qui asperiores. Totam nihil nihil adipisci.", new DateTime(2024, 1, 3, 18, 1, 10, 355, DateTimeKind.Utc).AddTicks(710), 24, new DateTime(2024, 10, 7, 19, 6, 27, 848, DateTimeKind.Utc).AddTicks(9169) }
                });

            migrationBuilder.InsertData(
                table: "wall_comments",
                columns: new[] { "id", "author_user_id", "content", "created_at", "post_id", "updated_at" },
                values: new object[,]
                {
                    { 1, 30, "Nulla ut et perferendis.", new DateTime(2024, 9, 7, 18, 4, 25, 989, DateTimeKind.Utc).AddTicks(5432), 29, null },
                    { 2, 1, "Eos nulla quia voluptas.", new DateTime(2024, 1, 25, 10, 4, 4, 916, DateTimeKind.Utc).AddTicks(4806), 6, null },
                    { 3, 15, "Numquam rerum sint.", new DateTime(2024, 1, 27, 23, 1, 54, 459, DateTimeKind.Utc).AddTicks(7382), 30, null },
                    { 4, 21, "Et aut tenetur et.", new DateTime(2024, 9, 6, 1, 11, 56, 179, DateTimeKind.Utc).AddTicks(4385), 23, null },
                    { 5, 16, "Ea et distinctio in laboriosam alias eum maiores est nostrum.", new DateTime(2024, 3, 13, 4, 5, 57, 212, DateTimeKind.Utc).AddTicks(4458), 26, null },
                    { 6, 8, "Maxime accusamus molestias et aliquid est officiis dolorem nihil.", new DateTime(2024, 3, 20, 16, 23, 35, 620, DateTimeKind.Utc).AddTicks(6570), 7, null },
                    { 7, 8, "Nemo quos nobis consectetur repudiandae aut animi laudantium qui.", new DateTime(2024, 4, 27, 5, 47, 33, 668, DateTimeKind.Utc).AddTicks(91), 19, null },
                    { 8, 28, "Molestias quas rem sed.", new DateTime(2024, 5, 28, 5, 1, 9, 820, DateTimeKind.Utc).AddTicks(7641), 15, null },
                    { 9, 30, "Aut maxime quia nam numquam doloremque blanditiis.", new DateTime(2024, 9, 20, 11, 18, 20, 119, DateTimeKind.Utc).AddTicks(9876), 17, null },
                    { 10, 10, "Dolor aspernatur autem velit.", new DateTime(2024, 6, 18, 12, 41, 19, 365, DateTimeKind.Utc).AddTicks(758), 12, null },
                    { 11, 19, "Omnis iste cumque omnis voluptas aspernatur.", new DateTime(2024, 1, 11, 23, 58, 57, 66, DateTimeKind.Utc).AddTicks(78), 3, null },
                    { 12, 10, "Non corrupti accusantium vel dolor.", new DateTime(2024, 2, 13, 4, 16, 51, 193, DateTimeKind.Utc).AddTicks(960), 13, null },
                    { 13, 2, "Ullam sed rerum aperiam.", new DateTime(2024, 6, 4, 14, 6, 25, 395, DateTimeKind.Utc).AddTicks(2561), 14, null },
                    { 14, 14, "Et sit corrupti.", new DateTime(2024, 1, 4, 0, 39, 47, 87, DateTimeKind.Utc).AddTicks(8595), 25, null },
                    { 15, 16, "Molestiae quia id vel ut et.", new DateTime(2024, 4, 11, 16, 18, 55, 464, DateTimeKind.Utc).AddTicks(3653), 22, null },
                    { 16, 25, "Et dolores ipsam ullam non blanditiis molestias.", new DateTime(2024, 7, 23, 3, 18, 0, 745, DateTimeKind.Utc).AddTicks(9397), 3, null },
                    { 17, 13, "Cupiditate voluptatem cupiditate eos nobis quis.", new DateTime(2024, 1, 17, 12, 23, 50, 12, DateTimeKind.Utc).AddTicks(4890), 10, null },
                    { 18, 4, "Porro neque qui in repellendus deserunt veniam qui.", new DateTime(2023, 12, 29, 16, 4, 14, 356, DateTimeKind.Utc).AddTicks(5012), 2, null },
                    { 19, 2, "Blanditiis excepturi dolore et praesentium quasi atque sed.", new DateTime(2024, 3, 31, 23, 38, 38, 244, DateTimeKind.Utc).AddTicks(8562), 8, null },
                    { 20, 16, "Earum nulla aut.", new DateTime(2023, 12, 9, 2, 50, 3, 427, DateTimeKind.Utc).AddTicks(5001), 13, null },
                    { 21, 17, "Placeat ab sed voluptas ducimus vel.", new DateTime(2023, 12, 11, 17, 2, 9, 153, DateTimeKind.Utc).AddTicks(2854), 10, null },
                    { 22, 10, "Dolore quisquam quisquam doloribus.", new DateTime(2024, 5, 20, 17, 24, 57, 773, DateTimeKind.Utc).AddTicks(8726), 4, null },
                    { 23, 19, "Laborum repellendus quaerat ut non quo accusantium qui excepturi et.", new DateTime(2024, 5, 31, 16, 9, 25, 229, DateTimeKind.Utc).AddTicks(1865), 20, null },
                    { 24, 12, "Blanditiis doloremque molestiae sed molestias.", new DateTime(2024, 1, 12, 2, 52, 22, 933, DateTimeKind.Utc).AddTicks(6131), 6, null },
                    { 25, 3, "Facilis molestias consequatur alias hic.", new DateTime(2023, 11, 23, 21, 29, 33, 555, DateTimeKind.Utc).AddTicks(6663), 13, null },
                    { 26, 1, "Voluptatem et et rerum fugiat nobis.", new DateTime(2023, 11, 3, 3, 19, 52, 39, DateTimeKind.Utc).AddTicks(7683), 20, null },
                    { 27, 3, "Et at beatae ipsam non impedit.", new DateTime(2024, 1, 24, 9, 13, 59, 224, DateTimeKind.Utc).AddTicks(7852), 9, null },
                    { 28, 14, "Fuga assumenda consequatur earum.", new DateTime(2024, 3, 8, 12, 49, 0, 8, DateTimeKind.Utc).AddTicks(9010), 28, null },
                    { 29, 25, "Vero fugiat voluptatem unde.", new DateTime(2024, 7, 9, 13, 24, 14, 404, DateTimeKind.Utc).AddTicks(6008), 21, null },
                    { 30, 26, "Nam quia ut quasi.", new DateTime(2024, 6, 29, 17, 58, 36, 774, DateTimeKind.Utc).AddTicks(9545), 11, null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_wall_comments_author_user_id",
                table: "wall_comments",
                column: "author_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_wall_comments_post_id",
                table: "wall_comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "ix_wall_posts_author_user_id",
                table: "wall_posts",
                column: "author_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_wall_posts_profile_user_id",
                table: "wall_posts",
                column: "profile_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "wall_comments");

            migrationBuilder.DropTable(
                name: "wall_posts");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
