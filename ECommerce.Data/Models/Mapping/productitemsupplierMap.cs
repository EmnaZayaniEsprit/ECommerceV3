using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class productitemsupplierMap : EntityTypeConfiguration<productitemsupplier>
    {
        public productitemsupplierMap()
        {
            // Primary Key
            this.HasKey(t => new { t.date, t.idProduct, t.idSupplier });

            // Properties
            this.Property(t => t.idProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idSupplier)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("productitemsupplier", "ecommerce");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.idProduct).HasColumnName("idProduct");
            this.Property(t => t.idSupplier).HasColumnName("idSupplier");
            this.Property(t => t.quantity).HasColumnName("quantity");

            // Relationships
            this.HasRequired(t => t.product)
                .WithMany(t => t.productitemsuppliers)
                .HasForeignKey(d => d.idProduct);
            this.HasRequired(t => t.user)
                .WithMany(t => t.productitemsuppliers)
                .HasForeignKey(d => d.idSupplier);

        }
    }
}
