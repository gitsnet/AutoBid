using Core.Misc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.CarSeller
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("Countries");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
            this.Property(t => t.DisplayName).HasColumnName("DisplayName");
            this.Property(t => t.FormalName).HasColumnName("FormalName");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.SubType).HasColumnName("SubType");
            this.Property(t => t.Sovereignty).HasColumnName("Sovereignty");
            this.Property(t => t.Capital).HasColumnName("Capital");
            this.Property(t => t.ISO_4217_Currency_Code).HasColumnName("ISO_4217_Currency_Code");
            this.Property(t => t.ISO_4217_Currency_Name).HasColumnName("ISO_4217_Currency_Name");
            this.Property(t => t.ITU_T_Telephone_Code).HasColumnName("ITU_T_Telephone_Code");
            this.Property(t => t.ISO_3166_1_2Letter_Code).HasColumnName("ISO_3166_1_2Letter_Code");
            this.Property(t => t.ISO_3166_1_3Letter_Code).HasColumnName("ISO_3166_1_3Letter_Code");
            this.Property(t => t.ISO_3166_1Number).HasColumnName("ISO_3166_1Number");
            this.Property(t => t.IANA_Country_Code_TLD).HasColumnName("IANA_Country_Code_TLD");
            this.Property(t => t.IsListed).HasColumnName("IsListed");
        }
    }
}
