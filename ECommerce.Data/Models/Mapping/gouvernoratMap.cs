using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class gouvernoratMap : EntityTypeConfiguration<gouvernorat>
    {
        public gouvernoratMap()
        {
            // Primary Key
            this.HasKey(t => t.idGouvernorat);

            // Properties
            this.Property(t => t.gouvernoratName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("gouvernorat", "ecommerce");
            this.Property(t => t.idGouvernorat).HasColumnName("idGouvernorat");
            this.Property(t => t.gouvernoratName).HasColumnName("gouvernoratName");
        }
    }
}
