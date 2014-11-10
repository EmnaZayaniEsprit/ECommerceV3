using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class productMap : EntityTypeConfiguration<product>
    {
        public productMap()
        {
            // Primary Key
            this.HasKey(t => t.idProduct);

            // Properties
            this.Property(t => t.currency)
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("product", "ecommerce");
            this.Property(t => t.idProduct).HasColumnName("idProduct");
            this.Property(t => t.currency).HasColumnName("currency");
            this.Property(t => t.date).HasColumnName("date");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.price).HasColumnName("price");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.taxe).HasColumnName("taxe");
            this.Property(t => t.category_idCategory).HasColumnName("category_idCategory");
            this.Property(t => t.promotion_idPromotion).HasColumnName("promotion_idPromotion");
            this.Property(t => t.supplier_idUser).HasColumnName("supplier_idUser");

            // Relationships
            this.HasOptional(t => t.category)
                .WithMany(t => t.products)
                .HasForeignKey(d => d.category_idCategory);
            this.HasOptional(t => t.user)
                .WithMany(t => t.products)
                .HasForeignKey(d => d.supplier_idUser);
            this.HasOptional(t => t.promotion)
                .WithMany(t => t.products)
                .HasForeignKey(d => d.promotion_idPromotion);

        }
    }
}
