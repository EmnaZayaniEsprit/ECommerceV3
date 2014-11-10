using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class productitemMap : EntityTypeConfiguration<productitem>
    {
        public productitemMap()
        {
            // Primary Key
            this.HasKey(t => new { t.dateSupplied, t.idParticularVendor, t.idProduct });

            // Properties
            this.Property(t => t.idParticularVendor)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("productitem", "ecommerce");
            this.Property(t => t.dateSupplied).HasColumnName("dateSupplied");
            this.Property(t => t.idParticularVendor).HasColumnName("idParticularVendor");
            this.Property(t => t.idProduct).HasColumnName("idProduct");
            this.Property(t => t.quantity).HasColumnName("quantity");

            // Relationships
            this.HasRequired(t => t.product)
                .WithMany(t => t.productitems)
                .HasForeignKey(d => d.idProduct);
            this.HasRequired(t => t.user)
                .WithMany(t => t.productitems)
                .HasForeignKey(d => d.idParticularVendor);

        }
    }
}
