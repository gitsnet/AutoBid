using Core.Seller;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Seller
{
    public class SellerCompanyLogoMap : EntityTypeConfiguration<SellerCompanyLogo>
    {
        public SellerCompanyLogoMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.OriginalFilename)
                .IsRequired();

            this.Property(t => t.Filename)
                .IsRequired();

            this.Property(t => t.FolderPath)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("SellerCompanyLogos");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CompanyID).HasColumnName("CompanyID");
            this.Property(t => t.ImageSizeID).HasColumnName("ImageSizeID");
            this.Property(t => t.OriginalFilename).HasColumnName("OriginalFilename");
            this.Property(t => t.Filename).HasColumnName("Filename");
            this.Property(t => t.FolderPath).HasColumnName("FolderPath");
            this.Property(t => t.TempID).HasColumnName("TempID");
            this.Property(t => t.UploadedOn).HasColumnName("UploadedOn");
        }
    }
}
