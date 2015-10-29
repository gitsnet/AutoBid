using Core.Seller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Seller
{
    public class SellerCompanyInfoMap : EntityTypeConfiguration<SellerCompanyInfo>
    {
        public SellerCompanyInfoMap()
        {
            
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CompanyName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Address001)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Address002)
                .HasMaxLength(250);

            this.Property(t => t.Address003)
                .HasMaxLength(250);

            this.Property(t => t.PostalCode)
                .HasMaxLength(250);

            this.Property(t => t.ContactNumbers)
                .IsRequired();

            this.Property(t => t.CompanyNumber)
                .HasMaxLength(250);

            this.Property(t => t.VatNumber)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("SellerCompanyInfo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserID).HasColumnName("UserID");
            this.Property(t => t.CompanyTypeID).HasColumnName("CompanyTypeID");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.Address001).HasColumnName("Address001");
            this.Property(t => t.Address002).HasColumnName("Address002");
            this.Property(t => t.Address003).HasColumnName("Address003");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.CountryID).HasColumnName("CountryID");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.ContactNumbers).HasColumnName("ContactNumbers");
            this.Property(t => t.CompanyNumber).HasColumnName("CompanyNumber");
            this.Property(t => t.VatNumber).HasColumnName("VatNumber");
            this.Property(t => t.YearOfFoundation).HasColumnName("YearOfFoundation");
            this.Property(t => t.NoOfEmployees).HasColumnName("NoOfEmployees");
            this.Property(t => t.TurnOver).HasColumnName("TurnOver");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");

            // Relationships
            this.HasRequired(t => t.AspNetUsersAdditionalInfo)
                .WithMany(t => t.SellerCompanyInfoes)
                .HasForeignKey(d => d.UserID);

        }
    }
}
