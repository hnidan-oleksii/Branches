using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PostsDAL_EF.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "branches",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Collins - Runolfsson" },
                    { 2, "Kemmer, Torphy and Lockman" },
                    { 3, "Terry, Jerde and Luettgen" },
                    { 4, "Heller - VonRueden" },
                    { 5, "Stokes - Reilly" },
                    { 6, "Gutkowski Group" },
                    { 7, "Berge, Crist and Huel" },
                    { 8, "Pfeffer, Davis and Ratke" },
                    { 9, "Dicki - Stroman" },
                    { 10, "Bode - Heidenreich" },
                    { 11, "Morar - Braun" },
                    { 12, "Lehner - Batz" },
                    { 13, "Wuckert LLC" },
                    { 14, "Kiehn Group" },
                    { 15, "Koss and Sons" },
                    { 16, "Hickle - Dietrich" },
                    { 17, "Steuber, Zulauf and Schmitt" },
                    { 18, "Stoltenberg - Kutch" },
                    { 19, "Feest - Kovacek" },
                    { 20, "Gulgowski, Hand and Dickinson" },
                    { 21, "Pfannerstill and Sons" },
                    { 22, "Mitchell and Sons" },
                    { 23, "Nolan, Bernier and Ernser" },
                    { 24, "Feil, Walter and Bartoletti" },
                    { 25, "Romaguera - Hagenes" },
                    { 26, "Labadie - Skiles" },
                    { 27, "Robel - Bogan" },
                    { 28, "Sporer LLC" },
                    { 29, "Senger, Ryan and Macejkovic" },
                    { 30, "Gorczany - Wehner" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Margarete Kunze" },
                    { 2, "Glen Shields" },
                    { 3, "Chloe Breitenberg" },
                    { 4, "Ellie Conn" },
                    { 5, "Lambert Runte" },
                    { 6, "Ken Bogisich" },
                    { 7, "Emmet Feeney" },
                    { 8, "Margie Zieme" },
                    { 9, "Lindsey Koelpin" },
                    { 10, "Camron Sawayn" },
                    { 11, "Verla Considine" },
                    { 12, "Arlene Reilly" },
                    { 13, "Rachael Champlin" },
                    { 14, "Jaylon Hand" },
                    { 15, "Nat Sawayn" },
                    { 16, "Cary Kris" },
                    { 17, "Kayla Fahey" },
                    { 18, "Fletcher Bergstrom" },
                    { 19, "Freeman Ondricka" },
                    { 20, "Jason Hayes" },
                    { 21, "Cayla Tromp" },
                    { 22, "Tabitha Smith" },
                    { 23, "Ramon Dietrich" },
                    { 24, "Mauricio Rohan" },
                    { 25, "Ned Schulist" },
                    { 26, "Alexie Stanton" },
                    { 27, "Adrien Kutch" },
                    { 28, "Elroy Paucek" },
                    { 29, "Lenora Klocko" },
                    { 30, "Niko Kunde" }
                });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "branchid", "content", "createdat", "title", "userid" },
                values: new object[,]
                {
                    { 1, 13, "Tempora ut ipsa sed. Similique sit consequatur. Amet sint libero exercitationem adipisci.", new DateTime(2024, 5, 1, 1, 14, 8, 23, DateTimeKind.Utc).AddTicks(5719), "Velit reprehenderit velit.", 23 },
                    { 2, 6, "Veniam aliquid cumque aut aperiam non veniam. Et eum tempore ea sunt iste. Sunt consectetur nesciunt in et. Maxime quia eligendi velit. Qui et qui debitis blanditiis alias aut provident voluptatem. Iusto deserunt officia eligendi.", new DateTime(2024, 3, 1, 15, 8, 48, 886, DateTimeKind.Utc).AddTicks(6127), "Et dolores animi et ad deleniti autem sit corrupti.", 11 },
                    { 3, 25, "At cumque et vel aspernatur vitae soluta repudiandae illo. Accusamus enim vel ut aliquam. Occaecati tenetur et. Quod enim consequatur deleniti id. Consequatur omnis quo magnam. Et hic molestias architecto id doloribus dolores recusandae sit.", new DateTime(2024, 8, 18, 20, 43, 9, 456, DateTimeKind.Utc).AddTicks(1884), "Rerum at culpa eius.", 13 },
                    { 4, 23, "Consequatur hic quia dolor consequatur corrupti. Ut aliquam ut ipsa. Tenetur repudiandae accusantium vitae. Sint quibusdam incidunt repellat.", new DateTime(2024, 6, 11, 22, 5, 28, 742, DateTimeKind.Utc).AddTicks(7981), "Numquam asperiores deserunt occaecati cumque.", 27 },
                    { 5, 5, "Velit fugiat consequatur magni aut nam. Ut culpa sunt. Blanditiis iusto non dicta animi reprehenderit perspiciatis assumenda repudiandae.", new DateTime(2024, 7, 10, 5, 5, 5, 202, DateTimeKind.Utc).AddTicks(308), "Ut odit sed totam.", 13 },
                    { 6, 21, "Cum nobis fugiat. Inventore dolorum delectus et iusto eum maiores cupiditate. Magni veritatis laborum. Natus qui possimus deserunt perferendis est deserunt. Eos corrupti sed et.", new DateTime(2024, 8, 28, 12, 13, 40, 271, DateTimeKind.Utc).AddTicks(8378), "Magni doloribus libero et necessitatibus aut nisi quis qui et.", 24 },
                    { 7, 12, "Dolore velit laudantium corrupti qui repellat at aut cupiditate. Earum qui suscipit et harum. Deleniti saepe quasi ut quo et maxime id et.", new DateTime(2023, 10, 25, 15, 40, 55, 276, DateTimeKind.Utc).AddTicks(5138), "Fugiat tenetur fugiat saepe ea perspiciatis et mollitia neque.", 11 },
                    { 8, 28, "Qui assumenda omnis. Quas ut porro. Debitis quidem excepturi molestiae incidunt quod natus odio modi aut. Eaque aut harum quia excepturi fugit suscipit unde.", new DateTime(2024, 2, 7, 22, 35, 2, 955, DateTimeKind.Utc).AddTicks(1592), "Voluptas laudantium odio ea.", 11 },
                    { 9, 7, "Nemo laboriosam eos eveniet labore sapiente quam. Rerum dolorum cupiditate. Fugiat aut at.", new DateTime(2024, 6, 29, 2, 36, 50, 162, DateTimeKind.Utc).AddTicks(8098), "Facilis accusamus consequatur consequuntur.", 27 },
                    { 10, 6, "Sed illo iusto enim quidem sit soluta facere quis adipisci. Ratione qui quos quia consequatur quibusdam rerum dolorem. Harum sed voluptatem sed ipsum quibusdam recusandae dolorum molestiae sapiente. Molestias ipsa in quasi repellendus voluptatem. Consectetur dolorum eaque minus doloribus. Nobis eius eos et.", new DateTime(2024, 6, 11, 0, 6, 34, 213, DateTimeKind.Utc).AddTicks(5277), "Deserunt nisi omnis velit voluptatem dolores.", 25 },
                    { 11, 11, "Molestiae doloribus sed architecto eaque deleniti totam. Repudiandae placeat sint molestiae in doloremque labore et laudantium consequatur. Quidem maxime dolor error. Reprehenderit voluptas occaecati quia neque maiores autem. Esse et dicta officia. Rem aut delectus culpa cum doloribus ea accusamus sit.", new DateTime(2024, 2, 25, 2, 55, 0, 898, DateTimeKind.Utc).AddTicks(5681), "Voluptates ullam ut enim tempora doloribus totam earum aspernatur.", 28 },
                    { 12, 10, "Facilis ex sed ab quos. Delectus rerum quasi. Impedit rerum molestiae. Unde quam aut ad vitae saepe doloremque.", new DateTime(2024, 5, 6, 14, 36, 33, 348, DateTimeKind.Utc).AddTicks(5091), "Corporis qui ipsa accusamus assumenda id soluta.", 5 },
                    { 13, 2, "Temporibus modi nemo molestias quaerat nesciunt natus voluptas enim. Sed doloremque aliquid. Et ab provident. Magnam magni odit aperiam magni laborum.", new DateTime(2024, 5, 17, 21, 22, 31, 918, DateTimeKind.Utc).AddTicks(3480), "Minus tempore inventore eos nihil.", 23 },
                    { 14, 3, "Eius deserunt ad ipsam rerum. Et omnis inventore sunt ullam exercitationem in commodi. Nam odio veritatis. Illum eligendi corrupti consectetur aliquid est voluptatem voluptatem.", new DateTime(2024, 2, 13, 17, 35, 46, 357, DateTimeKind.Utc).AddTicks(6477), "Incidunt sunt laudantium consequatur.", 19 },
                    { 15, 23, "Eum porro assumenda pariatur vel exercitationem id. Et quisquam quos dolores provident repellat. Aspernatur aliquid dolore quas minima perferendis et tenetur cupiditate atque. Fuga minus placeat dolor soluta est officia consequatur cupiditate. Dolores voluptatem nesciunt praesentium neque consequatur aut eum.", new DateTime(2023, 11, 3, 15, 1, 6, 481, DateTimeKind.Utc).AddTicks(1038), "Atque et aperiam fugiat reiciendis.", 25 },
                    { 16, 27, "Minus et esse. Qui quisquam nesciunt sit qui saepe expedita quis a. Quia voluptatem dolore vitae est tempore.", new DateTime(2024, 4, 6, 1, 47, 55, 170, DateTimeKind.Utc).AddTicks(7113), "Et dignissimos eligendi et dicta blanditiis minus mollitia nostrum.", 1 },
                    { 17, 25, "Illum nihil numquam esse sed nihil. Eos quia voluptatem est officia alias ex esse aspernatur. Quo nihil soluta atque velit cum qui ut. Ea qui cupiditate non ea magni commodi rerum sint.", new DateTime(2024, 9, 1, 18, 56, 58, 619, DateTimeKind.Utc).AddTicks(481), "Sed sint quis deserunt qui earum id.", 29 },
                    { 18, 7, "Aut error voluptates impedit nulla enim aperiam minus nihil magni. Est sunt corporis. In ipsam impedit ipsum. Esse quo quo dolores mollitia nam assumenda sed.", new DateTime(2024, 6, 6, 7, 31, 46, 916, DateTimeKind.Utc).AddTicks(9910), "Consequatur inventore quasi dignissimos ut ullam placeat consectetur quisquam.", 30 },
                    { 19, 7, "Occaecati natus consequuntur nihil eius. Fugiat odio et architecto quis quia atque enim quaerat. Et ut ullam cupiditate iure quia nihil dicta. Rerum esse et accusantium qui sit. Cupiditate dicta asperiores beatae dolorem incidunt qui dolores. Officiis voluptas eveniet ut facilis eveniet.", new DateTime(2024, 3, 4, 11, 33, 48, 301, DateTimeKind.Utc).AddTicks(8402), "Autem eum voluptate sunt doloribus.", 9 },
                    { 20, 18, "Neque dolorum illo nihil molestias aperiam provident. Sint eaque est dicta. Nulla eum repellendus mollitia maiores rerum facilis occaecati. Laboriosam itaque soluta sapiente.", new DateTime(2024, 2, 9, 5, 58, 46, 544, DateTimeKind.Utc).AddTicks(3050), "Voluptas ut velit consectetur expedita omnis tenetur incidunt illo eum.", 20 },
                    { 21, 1, "Odit voluptate quod molestiae hic sit est. Autem occaecati voluptas. Vitae adipisci natus pariatur et odio. Maiores officia eaque laborum magnam fuga. Nulla labore qui recusandae adipisci assumenda placeat voluptate.", new DateTime(2024, 10, 17, 17, 35, 33, 397, DateTimeKind.Utc).AddTicks(1205), "Praesentium adipisci deserunt.", 1 },
                    { 22, 14, "At hic maiores alias. Nihil expedita dolorem delectus ipsam eum accusamus quibusdam omnis voluptas. Quae officiis perferendis tenetur velit quos occaecati.", new DateTime(2024, 7, 13, 1, 58, 19, 568, DateTimeKind.Utc).AddTicks(6402), "Reprehenderit est quia voluptatem.", 3 },
                    { 23, 30, "Illum consequuntur tempora. Saepe veniam aliquid quod consectetur at voluptate illum. Dignissimos dolores dicta velit fugiat.", new DateTime(2024, 1, 7, 8, 48, 17, 665, DateTimeKind.Utc).AddTicks(4900), "Expedita enim est dolor doloremque ut.", 25 },
                    { 24, 1, "Eos velit deserunt rerum ut itaque qui natus saepe qui. Sed id ullam et nam consequuntur. Maiores quia dolores nemo pariatur ducimus. Animi est dolor ut et dolorum incidunt magni.", new DateTime(2024, 8, 7, 23, 14, 9, 345, DateTimeKind.Utc).AddTicks(6142), "Aut repudiandae qui ut voluptatem aut animi saepe magni.", 25 },
                    { 25, 28, "Eligendi dolores quo perferendis dolor ipsa. Voluptatibus eos provident aspernatur. Non nesciunt veniam voluptatem sed. Quia alias architecto. Dolores dolor labore doloribus nulla et omnis fuga.", new DateTime(2024, 10, 6, 0, 53, 56, 317, DateTimeKind.Utc).AddTicks(4705), "Similique voluptas quidem.", 25 },
                    { 26, 13, "Ullam voluptas adipisci quaerat et possimus quos et. Nesciunt at est eum qui quisquam consequuntur. Id quam sequi. Architecto autem iure tempora vitae doloribus illum veniam sapiente.", new DateTime(2023, 11, 13, 7, 41, 7, 675, DateTimeKind.Utc).AddTicks(941), "Quasi assumenda deserunt magnam laudantium ipsa soluta.", 29 },
                    { 27, 27, "Aut consequatur omnis soluta. Esse aspernatur quidem voluptate deleniti accusamus. Aut est omnis. Modi qui et quo. Laboriosam assumenda iure excepturi vel laboriosam vel unde sit.", new DateTime(2024, 4, 21, 22, 32, 7, 485, DateTimeKind.Utc).AddTicks(7607), "Veritatis molestias deserunt ipsa.", 4 },
                    { 28, 6, "A nesciunt vitae. Et harum consectetur veniam rerum qui nihil temporibus beatae fuga. Atque repudiandae a nostrum facere. Soluta cumque vel ullam itaque. Architecto aliquam unde dolore est doloremque. Harum a nobis at quis consequatur.", new DateTime(2024, 9, 14, 11, 9, 39, 676, DateTimeKind.Utc).AddTicks(3116), "Qui vitae sed.", 19 },
                    { 29, 28, "Reprehenderit voluptatem omnis pariatur. Qui non aliquam et sunt. Praesentium ut labore omnis molestias ea.", new DateTime(2024, 6, 24, 1, 4, 51, 926, DateTimeKind.Utc).AddTicks(3964), "Libero blanditiis dolorem ut.", 3 },
                    { 30, 23, "Doloremque hic soluta enim rerum consequuntur ad. Dignissimos qui expedita debitis ut natus. Cumque provident facere in commodi odit aperiam.", new DateTime(2023, 12, 22, 21, 0, 29, 861, DateTimeKind.Utc).AddTicks(9312), "Voluptatem at omnis facere nisi blanditiis sed magni repellat.", 14 }
                });

            migrationBuilder.InsertData(
                table: "postvotes",
                columns: new[] { "id", "postid", "userid", "votetype", "votedat" },
                values: new object[,]
                {
                    { 1, 26, 26, (short)-1, new DateTime(2024, 10, 20, 21, 17, 24, 993, DateTimeKind.Utc).AddTicks(3527) },
                    { 2, 10, 13, (short)-1, new DateTime(2024, 10, 21, 2, 10, 10, 984, DateTimeKind.Utc).AddTicks(2323) },
                    { 3, 25, 17, (short)1, new DateTime(2024, 10, 21, 3, 39, 14, 828, DateTimeKind.Utc).AddTicks(341) },
                    { 4, 10, 19, (short)1, new DateTime(2024, 10, 20, 11, 41, 4, 693, DateTimeKind.Utc).AddTicks(2929) },
                    { 5, 22, 22, (short)1, new DateTime(2024, 10, 20, 9, 47, 58, 379, DateTimeKind.Utc).AddTicks(9831) },
                    { 6, 7, 20, (short)1, new DateTime(2024, 10, 20, 13, 17, 3, 943, DateTimeKind.Utc).AddTicks(1354) },
                    { 7, 12, 11, (short)-1, new DateTime(2024, 10, 20, 16, 43, 6, 479, DateTimeKind.Utc).AddTicks(2585) },
                    { 8, 24, 9, (short)1, new DateTime(2024, 10, 21, 1, 19, 58, 341, DateTimeKind.Utc).AddTicks(3133) },
                    { 9, 30, 22, (short)-1, new DateTime(2024, 10, 20, 23, 7, 25, 471, DateTimeKind.Utc).AddTicks(6166) },
                    { 10, 4, 7, (short)-1, new DateTime(2024, 10, 20, 21, 4, 2, 839, DateTimeKind.Utc).AddTicks(5610) },
                    { 11, 14, 20, (short)-1, new DateTime(2024, 10, 20, 23, 19, 44, 896, DateTimeKind.Utc).AddTicks(4621) },
                    { 12, 14, 1, (short)1, new DateTime(2024, 10, 20, 12, 23, 54, 574, DateTimeKind.Utc).AddTicks(38) },
                    { 13, 23, 18, (short)-1, new DateTime(2024, 10, 20, 11, 45, 36, 276, DateTimeKind.Utc).AddTicks(7125) },
                    { 14, 6, 12, (short)1, new DateTime(2024, 10, 21, 2, 52, 40, 608, DateTimeKind.Utc).AddTicks(4817) },
                    { 15, 10, 26, (short)1, new DateTime(2024, 10, 20, 19, 20, 22, 190, DateTimeKind.Utc).AddTicks(1452) },
                    { 16, 27, 21, (short)1, new DateTime(2024, 10, 20, 10, 25, 50, 736, DateTimeKind.Utc).AddTicks(4591) },
                    { 17, 26, 17, (short)1, new DateTime(2024, 10, 20, 11, 27, 57, 680, DateTimeKind.Utc).AddTicks(5744) },
                    { 18, 20, 1, (short)-1, new DateTime(2024, 10, 21, 7, 3, 5, 817, DateTimeKind.Utc).AddTicks(2249) },
                    { 19, 28, 23, (short)1, new DateTime(2024, 10, 20, 16, 14, 19, 867, DateTimeKind.Utc).AddTicks(9456) },
                    { 20, 13, 30, (short)-1, new DateTime(2024, 10, 20, 22, 54, 29, 607, DateTimeKind.Utc).AddTicks(5723) },
                    { 21, 8, 12, (short)-1, new DateTime(2024, 10, 20, 18, 5, 39, 262, DateTimeKind.Utc).AddTicks(9628) },
                    { 22, 22, 7, (short)-1, new DateTime(2024, 10, 20, 12, 25, 42, 924, DateTimeKind.Utc).AddTicks(9049) },
                    { 23, 6, 27, (short)-1, new DateTime(2024, 10, 20, 22, 14, 33, 306, DateTimeKind.Utc).AddTicks(9453) },
                    { 24, 21, 29, (short)1, new DateTime(2024, 10, 21, 6, 21, 16, 858, DateTimeKind.Utc).AddTicks(3050) },
                    { 25, 5, 6, (short)-1, new DateTime(2024, 10, 20, 12, 27, 33, 82, DateTimeKind.Utc).AddTicks(1538) },
                    { 26, 8, 15, (short)1, new DateTime(2024, 10, 20, 20, 32, 59, 746, DateTimeKind.Utc).AddTicks(9701) },
                    { 27, 29, 19, (short)1, new DateTime(2024, 10, 20, 23, 33, 53, 763, DateTimeKind.Utc).AddTicks(9316) },
                    { 28, 20, 21, (short)-1, new DateTime(2024, 10, 20, 16, 45, 52, 99, DateTimeKind.Utc).AddTicks(3211) },
                    { 29, 14, 15, (short)-1, new DateTime(2024, 10, 20, 11, 35, 6, 787, DateTimeKind.Utc).AddTicks(2567) },
                    { 30, 24, 28, (short)-1, new DateTime(2024, 10, 20, 12, 44, 46, 442, DateTimeKind.Utc).AddTicks(4255) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "postvotes",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "posts",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "branches",
                keyColumn: "id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: 29);
        }
    }
}
