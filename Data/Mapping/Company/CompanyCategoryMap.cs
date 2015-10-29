using Core.Company;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Company
{
    public class CompanyCategoryMap : EntityTypeConfiguration<CompanyCategory>
    {
        public CompanyCategoryMap()
        {
            
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("CompanyCategories");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.IsRemoved).HasColumnName("IsRemoved");
        }
    }
}
