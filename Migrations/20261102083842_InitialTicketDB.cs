using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Projet_6_Modelisez_et_créez_une_base_de_données.Migrations
{
    /// <inheritdoc />
    public partial class InitialTicketDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpeSys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpeSys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppVersionId = table.Column<int>(type: "int", nullable: false),
                    OpeSysId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configurations_AppVersions_AppVersionId",
                        column: x => x.AppVersionId,
                        principalTable: "AppVersions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Configurations_OpeSys_OpeSysId",
                        column: x => x.OpeSysId,
                        principalTable: "OpeSys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Configurations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ResolutionDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsResolved = table.Column<bool>(type: "bit", nullable: false),
                    ProblemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResolutionDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigurationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppVersions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "1.0" },
                    { 2, "1.1" },
                    { 3, "1.2" },
                    { 4, "1.3" },
                    { 5, "1.0" },
                    { 6, "2.0" }
                });

            migrationBuilder.InsertData(
                table: "OpeSys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Linux" },
                    { 2, "MacOS" },
                    { 3, "Windows" },
                    { 4, "Android" },
                    { 5, "iOS" },
                    { 6, "Windows Mobiles" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Trader en Herbe" },
                    { 2, "Maître des Investissements" },
                    { 3, "Planificateur d'entraînement" },
                    { 4, "Planificateur d'Anxiété sociale" }
                });

            migrationBuilder.InsertData(
                table: "Configurations",
                columns: new[] { "Id", "AppVersionId", "OpeSysId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 1, 3, 1 },
                    { 3, 2, 1, 1 },
                    { 4, 2, 2, 1 },
                    { 5, 2, 3, 1 },
                    { 6, 3, 1, 1 },
                    { 7, 3, 2, 1 },
                    { 8, 3, 3, 1 },
                    { 9, 3, 4, 1 },
                    { 10, 3, 5, 1 },
                    { 11, 3, 6, 1 },
                    { 12, 4, 2, 1 },
                    { 13, 4, 3, 1 },
                    { 14, 4, 4, 1 },
                    { 15, 4, 5, 1 },
                    { 16, 1, 2, 2 },
                    { 17, 1, 5, 2 },
                    { 18, 5, 2, 2 },
                    { 19, 5, 4, 2 },
                    { 20, 5, 5, 2 },
                    { 21, 6, 2, 2 },
                    { 22, 6, 3, 2 },
                    { 23, 6, 4, 2 },
                    { 24, 6, 5, 2 },
                    { 25, 1, 1, 3 },
                    { 26, 1, 2, 3 },
                    { 27, 2, 1, 3 },
                    { 28, 2, 2, 3 },
                    { 29, 2, 3, 3 },
                    { 30, 2, 4, 3 },
                    { 31, 2, 5, 3 },
                    { 32, 2, 6, 3 },
                    { 33, 5, 2, 3 },
                    { 34, 5, 3, 3 },
                    { 35, 5, 4, 3 },
                    { 36, 5, 5, 3 },
                    { 37, 1, 2, 4 },
                    { 38, 1, 3, 4 },
                    { 39, 1, 4, 4 },
                    { 40, 1, 5, 4 },
                    { 41, 2, 2, 4 },
                    { 42, 2, 3, 4 },
                    { 43, 2, 4, 4 },
                    { 44, 2, 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "ConfigurationId", "CreationDate", "IsResolved", "ProblemDescription", "ResolutionDate", "ResolutionDescription" },
                values: new object[,]
                {
                    { 1, 1, new DateOnly(2026, 7, 31), false, "Lorsque l’on sélectionne une courbe de valeur individuelle, les boutons vente et achat n’apparaissent pas sur le côté.", null, null },
                    { 2, 2, new DateOnly(2026, 7, 31), false, "Lorsque l’on sélectionne une courbe de valeur individuelle, les boutons vente et achat n’apparaissent pas sur le côté.", null, null },
                    { 3, 12, new DateOnly(2026, 8, 16), true, "L’affichage de l’ À propos n’affiche rien.", new DateOnly(2026, 8, 18), "L’encart À propos n’était pas renseigné." },
                    { 4, 17, new DateOnly(2026, 8, 17), true, "Lors de la validation d’une transaction, son résumé ne s’affiche pas.", new DateOnly(2026, 8, 21), "La méthode GetTransactionSummary(lastTransaction) n’était pas appelée." },
                    { 5, 22, new DateOnly(2026, 8, 19), true, "Lors de l'exportation du portefeuille d'investissement au format Excel, les montants des dividendes perçus ne sont pas inclus dans le fichier généré.", new DateOnly(2026, 8, 23), "Une erreur dans la sélection des données à exporter a été corrigée. Les dividendes sont désormais correctement intégrés au fichier Excel." },
                    { 6, 23, new DateOnly(2026, 8, 25), true, "Le graphique présentant l’évolution de la valeur du portefeuille reste vide lorsqu’on sélectionne une période de plus de six mois. ", new DateOnly(2026, 8, 25), "La limite de récupération des données historiques a été corrigée afin de permettre l’affichage du graphique sur des périodes supérieures à six mois." },
                    { 7, 28, new DateOnly(2026, 8, 31), true, "Les séances d'entraînement enregistrées disparaissent après la fermeture du logiciel. ", new DateOnly(2026, 9, 3), "Le mécanisme de sauvegarde a été corrigé afin de conserver les séances après la fermeture et le redémarrage de l'application. " },
                    { 8, 35, new DateOnly(2026, 8, 31), false, "Le calcul du temps total d'entraînement ne prend pas en compte les périodes de récupération entre les exercices.", null, null },
                    { 9, 34, new DateOnly(2026, 9, 1), true, "Le calendrier affiche les séances d'entraînement avec un jour de décalage après leur synchronisation avec un calendrier externe.", new DateOnly(2026, 9, 2), "La gestion des fuseaux horaires a été corrigée afin de conserver la date prévue lors de la synchronisation." },
                    { 10, 25, new DateOnly(2026, 9, 1), true, "La modification d'un exercice dans une séance entraîne la suppression des répétitions précédemment renseignées.", new DateOnly(2026, 9, 15), "La mise à jour des exercices a été corrigée pour préserver les répétitions, les séries et les charges déjà enregistrées." },
                    { 11, 42, new DateOnly(2026, 9, 2), true, "Le logiciel autorise la programmation de deux séances à des horaires qui se chevauchent.", new DateOnly(2026, 9, 7), "Un contrôle des conflits horaires a été ajouté afin de signaler les chevauchements avant l'enregistrement d'une séance." },
                    { 12, 44, new DateOnly(2026, 9, 8), true, "Les statistiques mensuelles affichent un nombre de séances inférieur au nombre réellement effectué.", new DateOnly(2026, 10, 1), "La requête de calcul des statistiques a été corrigée pour inclure toutes les séances terminées durant le mois sélectionné. " },
                    { 13, 42, new DateOnly(2026, 9, 3), true, "Les activités planifiées pour une situation sociale ne s'affichent pas dans le calendrier après leur enregistrement.", new DateOnly(2026, 9, 5), "Le mécanisme de sauvegarde et de chargement du calendrier a été corrigé afin d'afficher correctement toutes les activités planifiées." },
                    { 14, 41, new DateOnly(2026, 9, 3), true, "Les activités planifiées pour une situation sociale ne s'affichent pas dans le calendrier après leur enregistrement.", new DateOnly(2026, 9, 5), "Le mécanisme de sauvegarde et de chargement du calendrier a été corrigé afin d'afficher correctement toutes les activités planifiées." },
                    { 15, 42, new DateOnly(2026, 9, 18), true, "Les rappels programmés pour préparer un événement social sont envoyés plusieurs fois.", new DateOnly(2026, 10, 1), "La gestion des notifications a été corrigée afin qu'un seul rappel soit envoyé pour chaque événement programmé." },
                    { 16, 37, new DateOnly(2026, 9, 21), true, "a modification de la date d'une activité ne met pas à jour le rappel associé.", new DateOnly(2026, 9, 22), "Le système de planification des rappels a été adapté pour prendre en compte automatiquement la nouvelle date de l'activité." },
                    { 17, 1, new DateOnly(2026, 6, 17), true, "Le logiciel refuse d'enregistrer une activité lorsque le champ de description est laissé vide, même si son titre est renseigné.", new DateOnly(2026, 6, 18), "Les règles de validation ont été corrigées afin que seul le titre soit obligatoire pour enregistrer une activité." },
                    { 18, 39, new DateOnly(2026, 8, 18), true, "Les activités terminées restent affichées comme étant à venir dans le tableau de bord.", new DateOnly(2026, 8, 18), "Le calcul du statut des activités a été corrigé afin de distinguer les activités passées des activités à venir." },
                    { 19, 6, new DateOnly(2026, 9, 21), true, "Les cours des actions affichés dans le portefeuille ne se mettent pas à jour après l'actualisation des données du marché.", new DateOnly(2026, 9, 23), "Le mécanisme de récupération des cotations a été corrigé afin d'actualiser correctement les cours des actions." },
                    { 20, 13, new DateOnly(2026, 10, 1), true, "L'application affiche une erreur lors de l'enregistrement d'un ordre d'achat lorsque le montant disponible sur le compte est suffisant.", new DateOnly(2026, 10, 10), "Le calcul du solde disponible a été corrigé afin de prendre correctement en compte les opérations déjà enregistrées." },
                    { 21, 22, new DateOnly(2026, 10, 21), false, "Le logiciel affiche une valeur incorrecte du rendement annuel lorsqu'un portefeuille contient des investissements réalisés à des dates différentes.", null, null },
                    { 22, 30, new DateOnly(2026, 7, 18), true, "Le logiciel ne prend pas en compte les modifications apportées au nombre de séries d'un exercice dans le récapitulatif de la séance.", new DateOnly(2026, 8, 19), "Le calcul du récapitulatif a été corrigé afin de refléter immédiatement le nombre de séries après chaque modification." },
                    { 23, 26, new DateOnly(2026, 10, 10), true, "L'exportation du programme d'entraînement au format PDF coupe les descriptions des exercices lorsque celles-ci sont trop longues.", new DateOnly(2026, 10, 11), "La mise en page de l'export PDF a été adaptée pour permettre le retour à la ligne automatique et conserver l'intégralité des descriptions." },
                    { 24, 32, new DateOnly(2026, 6, 14), true, "Le calendrier affiche les activités dans le mauvais créneau horaire après un changement de fuseau horaire.", new DateOnly(2026, 6, 20), "La conversion des dates et heures a été corrigée pour conserver les horaires prévus lors d'un changement de fuseau horaire." },
                    { 25, 44, new DateOnly(2026, 10, 17), true, "Les notes personnelles associées à une activité disparaissent lorsqu'on modifie son niveau de difficulté.", new DateOnly(2026, 10, 19), "La mise à jour des activités a été corrigée afin de conserver les notes personnelles lors de la modification du niveau de difficulté. " }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_AppVersionId_OpeSysId_ProductId",
                table: "Configurations",
                columns: new[] { "AppVersionId", "OpeSysId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_OpeSysId",
                table: "Configurations",
                column: "OpeSysId");

            migrationBuilder.CreateIndex(
                name: "IX_Configurations_ProductId",
                table: "Configurations",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConfigurationId",
                table: "Tickets",
                column: "ConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Configurations");

            migrationBuilder.DropTable(
                name: "AppVersions");

            migrationBuilder.DropTable(
                name: "OpeSys");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
