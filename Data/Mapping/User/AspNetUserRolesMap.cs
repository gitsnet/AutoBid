using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.User;
using System.Data.Entity.ModelConfiguration;

namespace Data.Mapping.User
{
    class AspNetUserRolesMap:EntityTypeConfiguration<AspNetUserRoles>
    {
        public AspNetUserRolesMap()
        {

            // table & column mapping
            //this.ToTable("AspNetUserRoles");
            //////this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
        }
            
    }
}
