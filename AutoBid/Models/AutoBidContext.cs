using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using AutoBid.Models.Mapping;

namespace AutoBid.Models
{
    public partial class AutoBidContext : DbContext
    {
        static AutoBidContext()
        {
            Database.SetInitializer<AutoBidContext>(null);
        }

        public AutoBidContext()
            : base("Name=AutoBidContext")
        {
        }

        public DbSet<AspNetRole> AspNetRoles { get; set; }
        public DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUsersAdditionalInfo> AspNetUsersAdditionalInfoes { get; set; }
        public DbSet<AspNetUsersANDUserTypesMapping> AspNetUsersANDUserTypesMappings { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<CarSellerDocument> CarSellerDocuments { get; set; }
        public DbSet<CarSellerInfo> CarSellerInfoes { get; set; }
        public DbSet<CarSellerMoreDetail> CarSellerMoreDetails { get; set; }
        public DbSet<CarSellerPackage> CarSellerPackages { get; set; }
        public DbSet<CarSellerType> CarSellerTypes { get; set; }
        public DbSet<CarSellerVehicleFuelType> CarSellerVehicleFuelTypes { get; set; }
        public DbSet<CarSellerVehicleImage> CarSellerVehicleImages { get; set; }
        public DbSet<CarSellerVehicleInfo> CarSellerVehicleInfoes { get; set; }
        public DbSet<CarSellingOn> CarSellingOns { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CompanyCategory> CompanyCategories { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<ImageSize> ImageSizes { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<MIMEType> MIMETypes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<SaleDate> SaleDates { get; set; }
        public DbSet<SellerCardDetail> SellerCardDetails { get; set; }
        public DbSet<SellerCompanyInfo> SellerCompanyInfoes { get; set; }
        public DbSet<SellerCompanyLogo> SellerCompanyLogos { get; set; }
        public DbSet<SellerPersonalInfo> SellerPersonalInfoes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<SellerInfo> SellerInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AspNetRoleMap());
            modelBuilder.Configurations.Add(new AspNetUserClaimMap());
            modelBuilder.Configurations.Add(new AspNetUserLoginMap());
            modelBuilder.Configurations.Add(new AspNetUserMap());
            modelBuilder.Configurations.Add(new AspNetUsersAdditionalInfoMap());
            modelBuilder.Configurations.Add(new AspNetUsersANDUserTypesMappingMap());
            modelBuilder.Configurations.Add(new BodyTypeMap());
            modelBuilder.Configurations.Add(new CarSellerDocumentMap());
            modelBuilder.Configurations.Add(new CarSellerInfoMap());
            modelBuilder.Configurations.Add(new CarSellerMoreDetailMap());
            modelBuilder.Configurations.Add(new CarSellerPackageMap());
            modelBuilder.Configurations.Add(new CarSellerTypeMap());
            modelBuilder.Configurations.Add(new CarSellerVehicleFuelTypeMap());
            modelBuilder.Configurations.Add(new CarSellerVehicleImageMap());
            modelBuilder.Configurations.Add(new CarSellerVehicleInfoMap());
            modelBuilder.Configurations.Add(new CarSellingOnMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new CompanyCategoryMap());
            modelBuilder.Configurations.Add(new CompanyTypeMap());
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new FuelTypeMap());
            modelBuilder.Configurations.Add(new ImageSizeMap());
            modelBuilder.Configurations.Add(new MakeMap());
            modelBuilder.Configurations.Add(new MIMETypeMap());
            modelBuilder.Configurations.Add(new ModelMap());
            modelBuilder.Configurations.Add(new SaleDateMap());
            modelBuilder.Configurations.Add(new SellerCardDetailMap());
            modelBuilder.Configurations.Add(new SellerCompanyInfoMap());
            modelBuilder.Configurations.Add(new SellerCompanyLogoMap());
            modelBuilder.Configurations.Add(new SellerPersonalInfoMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TransmissionTypeMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new UserTypeMap());
            modelBuilder.Configurations.Add(new SellerInfoMap());
        }
    }
}
