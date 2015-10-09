using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ACM.Entity.Models.Mapping;
using ACM.Model;
namespace ACM.Entity.Models
{
    public partial class ACM_Redesign2014Context : DbContext
    {
       static ACM_Redesign2014Context()
        {
            Database.SetInitializer<ACM_Redesign2014Context>(null);
        }

       public ACM_Redesign2014Context()
           : base("Name=ACM_Redesign2014Context")
        {
        }

       public DbSet<Ad> Ads { get; set; }
       public DbSet<AdCategory> AdCategories { get; set; }
       public DbSet<AdDeploymentPeriod> AdDeploymentPeriods { get; set; }
       public DbSet<AdLocation> AdLocations { get; set; }
       public DbSet<AdLocationMedia> AdLocationMedias { get; set; }
       public DbSet<AdOutStandingTask> AdOutStandingTasks { get; set; }
       public DbSet<AdProductType> AdProductTypes { get; set; }
       public DbSet<AdRestriction> AdRestrictions { get; set; }
       public DbSet<AdRestrictionAd> AdRestrictionAds { get; set; }
       public DbSet<AdRestrictionCategory> AdRestrictionCategories { get; set; }
       public DbSet<ATMType> ATMTypes { get; set; }
       public DbSet<Campaign> Campaigns { get; set; }
       public DbSet<CampaignFollowUp> CampaignFollowUps { get; set; }
       public DbSet<CampaignLocation> CampaignLocations { get; set; }
       public DbSet<CampaignMainFrame> CampaignMainFrames { get; set; }
       public DbSet<CampaignTableStatu> CampaignTableStatus { get; set; }
       public DbSet<CampaignTargetFileProvider> CampaignTargetFileProviders { get; set; }
       public DbSet<CampaignType> CampaignTypes { get; set; }
       public DbSet<CardType> CardTypes { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<CustomerType> CustomerTypes { get; set; }
       public DbSet<DeploymentPeriod> DeploymentPeriods { get; set; }
       public DbSet<ETMConfiguration> ETMConfigurations { get; set; }
       public DbSet<EventTrigger> EventTriggers { get; set; }
       public DbSet<FollowUp> FollowUps { get; set; }
       public DbSet<Language> Languages { get; set; }
       public DbSet<LOB> LOBs { get; set; }
       public DbSet<MediaFileType> MediaFileTypes { get; set; }
       public DbSet<ProductPlacement> ProductPlacements { get; set; }
       public DbSet<PromoButton> PromoButtons { get; set; }
       public DbSet<RegFileCategory> RegFileCategories { get; set; }
       public DbSet<Region> Regions { get; set; }
       public DbSet<Role> Roles { get; set; }
       public DbSet<SpecialProcessType> SpecialProcessTypes { get; set; }
       public DbSet<SpecificProductCode> SpecificProductCodes { get; set; }
       public DbSet<State> States { get; set; }
       public DbSet<SubCategory> SubCategories { get; set; }
       public DbSet<SuperCategory> SuperCategories { get; set; }
       public DbSet<SuperRegion> SuperRegions { get; set; }
       public DbSet<sysdiagram> sysdiagrams { get; set; }
       public DbSet<TargetCampaignType> TargetCampaignTypes { get; set; }
       public DbSet<TargetListType> TargetListTypes { get; set; }
       public DbSet<User> Users { get; set; }
       public DbSet<View_CampaignDetials> View_CampaignDetials { get; set; }
       public DbSet<VW_Campaign> VW_Campaign { get; set; }

       protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Configurations.Add(new AdMap());
           modelBuilder.Configurations.Add(new AdCategoryMap());
           modelBuilder.Configurations.Add(new AdDeploymentPeriodMap());
           modelBuilder.Configurations.Add(new AdLocationMap());
           modelBuilder.Configurations.Add(new AdLocationMediaMap());
           modelBuilder.Configurations.Add(new AdOutStandingTaskMap());
           modelBuilder.Configurations.Add(new AdProductTypeMap());
           modelBuilder.Configurations.Add(new AdRestrictionMap());
           modelBuilder.Configurations.Add(new AdRestrictionAdMap());
           modelBuilder.Configurations.Add(new AdRestrictionCategoryMap());
           modelBuilder.Configurations.Add(new ATMTypeMap());
           modelBuilder.Configurations.Add(new CampaignMap());
           modelBuilder.Configurations.Add(new CampaignFollowUpMap());
           modelBuilder.Configurations.Add(new CampaignLocationMap());
           modelBuilder.Configurations.Add(new CampaignMainFrameMap());
           modelBuilder.Configurations.Add(new CampaignTableStatuMap());
           modelBuilder.Configurations.Add(new CampaignTargetFileProviderMap());
           modelBuilder.Configurations.Add(new CampaignTypeMap());
           modelBuilder.Configurations.Add(new CardTypeMap());
           modelBuilder.Configurations.Add(new CategoryMap());
           modelBuilder.Configurations.Add(new CustomerTypeMap());
           modelBuilder.Configurations.Add(new DeploymentPeriodMap());
           modelBuilder.Configurations.Add(new ETMConfigurationMap());
           modelBuilder.Configurations.Add(new EventTriggerMap());
           modelBuilder.Configurations.Add(new FollowUpMap());
           modelBuilder.Configurations.Add(new LanguageMap());
           modelBuilder.Configurations.Add(new LOBMap());
           modelBuilder.Configurations.Add(new MediaFileTypeMap());
           modelBuilder.Configurations.Add(new ProductPlacementMap());
           modelBuilder.Configurations.Add(new PromoButtonMap());
           modelBuilder.Configurations.Add(new RegFileCategoryMap());
           modelBuilder.Configurations.Add(new RegionMap());
           modelBuilder.Configurations.Add(new RoleMap());
           modelBuilder.Configurations.Add(new SpecialProcessTypeMap());
           modelBuilder.Configurations.Add(new SpecificProductCodeMap());
           modelBuilder.Configurations.Add(new StateMap());
           modelBuilder.Configurations.Add(new SubCategoryMap());
           modelBuilder.Configurations.Add(new SuperCategoryMap());
           modelBuilder.Configurations.Add(new SuperRegionMap());
           modelBuilder.Configurations.Add(new sysdiagramMap());
           modelBuilder.Configurations.Add(new TargetCampaignTypeMap());
           modelBuilder.Configurations.Add(new TargetListTypeMap());
           modelBuilder.Configurations.Add(new UserMap());
           modelBuilder.Configurations.Add(new View_CampaignDetialsMap());
           modelBuilder.Configurations.Add(new VW_CampaignMap());
       }
    }
}
