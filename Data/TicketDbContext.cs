using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projet_6_Modelisez_et_créez_une_base_de_données.Models.Entities;
using Projet_6_Modelisez_et_créez_une_base_de_données.Data.Seed.Constants;

namespace Projet_6_Modelisez_et_créez_une_base_de_données.Data
{
    public class TicketDbContext : IdentityDbContext
    {
        public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppVersion> AppVersions { get; set; }
        public DbSet<OpeSys> OpeSys { get; set; }
        public DbSet<Configuration> Configurations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TicketDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //Relationships and constraints 
            
            
            modelBuilder.Entity<Ticket>()
                .HasOne(c => c.Configuration)
                .WithMany(t => t.Tickets);

            modelBuilder.Entity<Configuration>()
                .HasIndex(c => new
                {
                    c.AppVersionId,
                    c.OpeSysId,
                    c.ProductId
                })
                .IsUnique();

            modelBuilder.Entity<Configuration>()
                .HasOne(a => a.AppVersion)
                .WithMany(c => c.Configurations);

            modelBuilder.Entity<Configuration>()
                .HasOne(o => o.OpeSys)
                .WithMany(c => c.Configurations);

            modelBuilder.Entity<Configuration>()
               .HasOne(a => a.Product)
               .WithMany(c => c.Configurations);

            modelBuilder.Entity<OpeSys>()
                .HasData(
                new OpeSys { Id = OpeSysSeedIds.OS_Linux, Name = "Linux" },
                new OpeSys { Id = OpeSysSeedIds.OS_MacOS, Name = "MacOS" },
                new OpeSys { Id = OpeSysSeedIds.OS_Windows, Name = "Windows" },
                new OpeSys { Id = OpeSysSeedIds.OS_Android, Name = "Android" },
                new OpeSys { Id = OpeSysSeedIds.OS_iOS, Name = "iOS" },
                new OpeSys { Id = OpeSysSeedIds.OS_WindowsMobile, Name = "Windows Mobiles" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { Id = ProductSeedIds.Pdct_TraderEnHerbe, Name = "Trader en Herbe" },
                new Product { Id = ProductSeedIds.Pdct_MaitreDesInvestissements, Name = "Maître des Investissements" },
                new Product { Id = ProductSeedIds.Pdct_PlanificateurDEntrainement, Name = "Planificateur d'entraînement" },
                new Product { Id = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, Name = "Planificateur d'Anxiété sociale" }
                );

            modelBuilder.Entity<AppVersion>()
                .HasData(
                //Seeding AppVersion
                new AppVersion { Id = AppVersionSeedIds.V1_0, Name = "1.0"},
                new AppVersion { Id = AppVersionSeedIds.V1_1, Name = "1.1"},
                new AppVersion { Id = AppVersionSeedIds.V1_2, Name = "1.2"},
                new AppVersion { Id = AppVersionSeedIds.V1_3, Name = "1.3"},
                new AppVersion { Id = AppVersionSeedIds.V2_0, Name = "1.0"},
                new AppVersion { Id = AppVersionSeedIds.V2_1, Name = "2.0"}
               

                );

            modelBuilder.Entity<Configuration>()
                .HasData(
                //Seeding couple "AppVersion, OpeSys" according to the product and version board given
                new Configuration { Id = ConfigurationSeedIds.TEH_V10_Linux,ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_Linux },
                new Configuration { Id = ConfigurationSeedIds.TEH_V10_Win,ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.TEH_V11_Linux,ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_Linux },
                new Configuration { Id = ConfigurationSeedIds.TEH_V11_MacOS,ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.TEH_V11_Win,ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.TEH_V12_Linux,ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_2, OpeSysId = OpeSysSeedIds.OS_Linux },
                new Configuration { Id = ConfigurationSeedIds.TEH_V12_MacOS, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_2, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.TEH_V12_Win, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_2, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.TEH_V12_Android, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_2, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.TEH_V12_iOS, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_2, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.TEH_V12_WM, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_2, OpeSysId = OpeSysSeedIds.OS_WindowsMobile },
                new Configuration { Id = ConfigurationSeedIds.TEH_V13_MacOS, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_3, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.TEH_V13_Win, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_3, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.TEH_V13_Android, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_3, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.TEH_V13_iOS, ProductId = ProductSeedIds.Pdct_TraderEnHerbe, AppVersionId = AppVersionSeedIds.V1_3, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.MDI_V10_MacOS, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.MDI_V10_iOS, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.MDI_V20_MacOS, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V2_0, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.MDI_V20_Android, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V2_0, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.MDI_V20_iOS, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V2_0, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.MDI_V21_MacOS, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V2_1, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.MDI_V21_Win, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V2_1, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.MDI_V21_Android, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V2_1, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.MDI_V21_iOS, ProductId = ProductSeedIds.Pdct_MaitreDesInvestissements, AppVersionId = AppVersionSeedIds.V2_1, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.PDE_V10_Linux, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_Linux },
                new Configuration { Id = ConfigurationSeedIds.PDE_V10_MacOS, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.PDE_V11_Linux, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_Linux },
                new Configuration { Id = ConfigurationSeedIds.PDE_V11_MacOS, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.PDE_V11_Win, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.PDE_V11_Android, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.PDE_V11_iOS, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.PDE_V11_WM, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_WindowsMobile },
                new Configuration { Id = ConfigurationSeedIds.PDE_V20_MacOS, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V2_0, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.PDE_V20_Win, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V2_0, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.PDE_V20_Android, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V2_0, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.PDE_V20_iOS, ProductId = ProductSeedIds.Pdct_PlanificateurDEntrainement, AppVersionId = AppVersionSeedIds.V2_0, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V10_MacOS, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V10_Win, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V10_Android, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V10_iOS, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_0, OpeSysId = OpeSysSeedIds.OS_iOS },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V11_MacOS, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_MacOS },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V11_Win, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_Windows },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V11_Android, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_Android },
                new Configuration { Id = ConfigurationSeedIds.PDAS_V11_iOS, ProductId = ProductSeedIds.Pdct_PlanificateurDAnxieteSociale, AppVersionId = AppVersionSeedIds.V1_1, OpeSysId = OpeSysSeedIds.OS_iOS }
                             
                );

            modelBuilder.Entity<Ticket>()
                .HasData(
                
                 new Ticket
                 {
                     Id = 1,
                     ConfigurationId = ConfigurationSeedIds.TEH_V10_Linux,
                     CreationDate = new DateOnly(2026, 07, 31),
                     IsResolved = IsResolvedSeedIds.InProgress,
                     ProblemDescription = "Lorsque l’on sélectionne une courbe de valeur individuelle, les boutons vente et achat n’apparaissent pas sur le côté."
                 },
                 new Ticket
                 {
                     Id = 2,
                     ConfigurationId = ConfigurationSeedIds.TEH_V10_Win,
                     CreationDate = new DateOnly(2026, 07, 31),
                     IsResolved = IsResolvedSeedIds.InProgress,
                     ProblemDescription = "Lorsque l’on sélectionne une courbe de valeur individuelle, les boutons vente et achat n’apparaissent pas sur le côté."
                 },
                  new Ticket
                  {
                      Id = 3,
                      ConfigurationId = ConfigurationSeedIds.TEH_V13_MacOS,
                      CreationDate = new DateOnly(2026, 08,16),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "L’affichage de l’ À propos n’affiche rien.",
                      ResolutionDate = new DateOnly(2026, 08, 18),
                      ResolutionDescription= "L’encart À propos n’était pas renseigné."

                  },
                  new Ticket
                  {
                      Id = 4,
                      ConfigurationId = ConfigurationSeedIds.MDI_V10_iOS,
                      CreationDate = new DateOnly(2026, 08, 17),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Lors de la validation d’une transaction, son résumé ne s’affiche pas.",
                      ResolutionDate = new DateOnly(2026, 08, 21),
                      ResolutionDescription = "La méthode GetTransactionSummary(lastTransaction) n’était pas appelée."
                  },
                  new Ticket
                  {
                      Id = 5,
                      ConfigurationId = ConfigurationSeedIds.MDI_V21_Win,
                      CreationDate = new DateOnly(2026, 08, 19),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Lors de l'exportation du portefeuille d'investissement au format Excel, les montants des dividendes perçus ne sont pas inclus dans le fichier généré.",
                      ResolutionDate = new DateOnly(2026, 08, 23),
                      ResolutionDescription = "Une erreur dans la sélection des données à exporter a été corrigée. Les dividendes sont désormais correctement intégrés au fichier Excel."
                  },
                  new Ticket
                  {
                      Id = 6,
                      ConfigurationId = ConfigurationSeedIds.MDI_V21_Android,
                      CreationDate = new DateOnly(2026, 08, 25),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Le graphique présentant l’évolution de la valeur du portefeuille reste vide lorsqu’on sélectionne une période de plus de six mois. ",
                      ResolutionDate = new DateOnly(2026, 08, 25),
                      ResolutionDescription = "La limite de récupération des données historiques a été corrigée afin de permettre l’affichage du graphique sur des périodes supérieures à six mois."
                  },
                  new Ticket
                  {
                      Id = 7,
                      ConfigurationId = ConfigurationSeedIds.PDE_V11_MacOS,
                      CreationDate = new DateOnly(2026, 08, 31),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les séances d'entraînement enregistrées disparaissent après la fermeture du logiciel. ",
                      ResolutionDate = new DateOnly(2026, 09, 03),
                      ResolutionDescription = "Le mécanisme de sauvegarde a été corrigé afin de conserver les séances après la fermeture et le redémarrage de l'application. "
                  },
                  new Ticket
                  {
                      Id = 8,
                      ConfigurationId = ConfigurationSeedIds.PDE_V20_Android,
                      CreationDate = new DateOnly(2026, 08, 31),
                      IsResolved = IsResolvedSeedIds.InProgress,
                      ProblemDescription = "Le calcul du temps total d'entraînement ne prend pas en compte les périodes de récupération entre les exercices."
                  },
                  new Ticket
                  {
                      Id = 9,
                      ConfigurationId = ConfigurationSeedIds.PDE_V20_Win,
                      CreationDate = new DateOnly(2026, 09, 01),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Le calendrier affiche les séances d'entraînement avec un jour de décalage après leur synchronisation avec un calendrier externe.",
                      ResolutionDate = new DateOnly(2026, 09, 02),
                      ResolutionDescription = "La gestion des fuseaux horaires a été corrigée afin de conserver la date prévue lors de la synchronisation."
                  },
                  new Ticket
                  {
                      Id = 10,
                      ConfigurationId = ConfigurationSeedIds.PDE_V10_Linux,
                      CreationDate = new DateOnly(2026, 09, 01),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "La modification d'un exercice dans une séance entraîne la suppression des répétitions précédemment renseignées.",
                      ResolutionDate = new DateOnly(2026, 09, 15),
                      ResolutionDescription = "La mise à jour des exercices a été corrigée pour préserver les répétitions, les séries et les charges déjà enregistrées."
                  },
                  new Ticket
                  {
                      Id = 11,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V11_Win,
                      CreationDate = new DateOnly(2026, 09, 02),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Le logiciel autorise la programmation de deux séances à des horaires qui se chevauchent.",
                      ResolutionDate = new DateOnly(2026, 09, 07),
                      ResolutionDescription = "Un contrôle des conflits horaires a été ajouté afin de signaler les chevauchements avant l'enregistrement d'une séance."
                  },
                  new Ticket
                  {
                      Id = 12,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V11_iOS,
                      CreationDate = new DateOnly(2026, 09, 08),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les statistiques mensuelles affichent un nombre de séances inférieur au nombre réellement effectué.",
                      ResolutionDate = new DateOnly(2026, 10, 01),
                      ResolutionDescription = "La requête de calcul des statistiques a été corrigée pour inclure toutes les séances terminées durant le mois sélectionné. "
                  },
                  new Ticket
                  {
                      Id = 13,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V11_Win,
                      CreationDate = new DateOnly(2026, 09, 03),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les activités planifiées pour une situation sociale ne s'affichent pas dans le calendrier après leur enregistrement.",
                      ResolutionDate = new DateOnly(2026, 09, 05),
                      ResolutionDescription = "Le mécanisme de sauvegarde et de chargement du calendrier a été corrigé afin d'afficher correctement toutes les activités planifiées."
                  },
                  new Ticket
                  {
                      Id = 14,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V11_MacOS,
                      CreationDate = new DateOnly(2026, 09, 03),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les activités planifiées pour une situation sociale ne s'affichent pas dans le calendrier après leur enregistrement.",
                      ResolutionDate = new DateOnly(2026, 09, 05),
                      ResolutionDescription = "Le mécanisme de sauvegarde et de chargement du calendrier a été corrigé afin d'afficher correctement toutes les activités planifiées."
                  },
                  new Ticket
                  {
                      Id = 15,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V11_Win,
                      CreationDate = new DateOnly(2026, 09, 18),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les rappels programmés pour préparer un événement social sont envoyés plusieurs fois.",
                      ResolutionDate = new DateOnly(2026, 10, 01),
                      ResolutionDescription = "La gestion des notifications a été corrigée afin qu'un seul rappel soit envoyé pour chaque événement programmé."
                  },
                  new Ticket
                  {
                      Id = 16,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V10_MacOS,
                      CreationDate = new DateOnly(2026, 09, 21),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "a modification de la date d'une activité ne met pas à jour le rappel associé.",
                      ResolutionDate = new DateOnly(2026, 09, 22),
                      ResolutionDescription = "Le système de planification des rappels a été adapté pour prendre en compte automatiquement la nouvelle date de l'activité."
                  },
                  new Ticket
                  {
                      Id = 17,
                      ConfigurationId = ConfigurationSeedIds.TEH_V10_Linux,
                      CreationDate = new DateOnly(2026, 06, 17),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Le logiciel refuse d'enregistrer une activité lorsque le champ de description est laissé vide, même si son titre est renseigné.",
                      ResolutionDate = new DateOnly(2026, 06, 18),
                      ResolutionDescription = "Les règles de validation ont été corrigées afin que seul le titre soit obligatoire pour enregistrer une activité."
                  },
                  new Ticket
                  {
                      Id = 18,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V10_Android,
                      CreationDate = new DateOnly(2026, 08, 18),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les activités terminées restent affichées comme étant à venir dans le tableau de bord.",
                      ResolutionDate = new DateOnly(2026, 08, 18),
                      ResolutionDescription = "Le calcul du statut des activités a été corrigé afin de distinguer les activités passées des activités à venir."
                  },
                  new Ticket
                  {
                      Id = 19,
                      ConfigurationId = ConfigurationSeedIds.TEH_V12_Linux,
                      CreationDate = new DateOnly(2026, 09, 21),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les cours des actions affichés dans le portefeuille ne se mettent pas à jour après l'actualisation des données du marché.",
                      ResolutionDate = new DateOnly(2026, 09, 23),
                      ResolutionDescription = "Le mécanisme de récupération des cotations a été corrigé afin d'actualiser correctement les cours des actions."
                  },
                  new Ticket
                  {
                      Id = 20,
                      ConfigurationId = ConfigurationSeedIds.TEH_V13_Win,
                      CreationDate = new DateOnly(2026, 10, 01),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "L'application affiche une erreur lors de l'enregistrement d'un ordre d'achat lorsque le montant disponible sur le compte est suffisant.",
                      ResolutionDate = new DateOnly(2026, 10, 10),
                      ResolutionDescription = "Le calcul du solde disponible a été corrigé afin de prendre correctement en compte les opérations déjà enregistrées."
                  },
                  new Ticket
                  {
                      Id = 21,
                      ConfigurationId = ConfigurationSeedIds.MDI_V21_Win,
                      CreationDate = new DateOnly(2026, 10, 21),
                      IsResolved = IsResolvedSeedIds.InProgress,
                      ProblemDescription = "Le logiciel affiche une valeur incorrecte du rendement annuel lorsqu'un portefeuille contient des investissements réalisés à des dates différentes."
                  },
                  new Ticket
                  {
                      Id = 22,
                      ConfigurationId = ConfigurationSeedIds.PDE_V11_Android,
                      CreationDate = new DateOnly(2026, 07, 18),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Le logiciel ne prend pas en compte les modifications apportées au nombre de séries d'un exercice dans le récapitulatif de la séance.",
                      ResolutionDate = new DateOnly(2026, 08, 19),
                      ResolutionDescription = "Le calcul du récapitulatif a été corrigé afin de refléter immédiatement le nombre de séries après chaque modification."
                  },
                  new Ticket
                  {
                      Id = 23,
                      ConfigurationId = ConfigurationSeedIds.PDE_V10_MacOS,
                      CreationDate = new DateOnly(2026, 10, 10),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "L'exportation du programme d'entraînement au format PDF coupe les descriptions des exercices lorsque celles-ci sont trop longues.",
                      ResolutionDate = new DateOnly(2026, 10, 11),
                      ResolutionDescription = "La mise en page de l'export PDF a été adaptée pour permettre le retour à la ligne automatique et conserver l'intégralité des descriptions."
                  },
                  new Ticket
                  {
                      Id = 24,
                      ConfigurationId = ConfigurationSeedIds.PDE_V11_WM,
                      CreationDate = new DateOnly(2026, 06, 14),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Le calendrier affiche les activités dans le mauvais créneau horaire après un changement de fuseau horaire.",
                      ResolutionDate = new DateOnly(2026, 06, 20),
                      ResolutionDescription = "La conversion des dates et heures a été corrigée pour conserver les horaires prévus lors d'un changement de fuseau horaire."
                  },
                  new Ticket
                  {
                      Id = 25,
                      ConfigurationId = ConfigurationSeedIds.PDAS_V11_iOS,
                      CreationDate = new DateOnly(2026, 10, 17),
                      IsResolved = IsResolvedSeedIds.Solved,
                      ProblemDescription = "Les notes personnelles associées à une activité disparaissent lorsqu'on modifie son niveau de difficulté.",
                      ResolutionDate = new DateOnly(2026, 10, 19),
                      ResolutionDescription = "La mise à jour des activités a été corrigée afin de conserver les notes personnelles lors de la modification du niveau de difficulté. "
                  }


                );

        }

        }
}
