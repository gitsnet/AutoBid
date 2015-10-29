using Core.Company;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.Company
{
    public class CompanyTypeMap : EntityTypeConfiguration<CompanyType>
    {
        public CompanyTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.CompanyType1)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("CompanyTypes");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CompanyType1).HasColumnName("CompanyType");
            this.Property(t => t.IsRemoved).HasColumnName("IsRemoved");
        }
    }
}
