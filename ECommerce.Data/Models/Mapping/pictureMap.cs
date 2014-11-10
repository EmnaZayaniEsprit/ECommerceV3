using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class pictureMap : EntityTypeConfiguration<picture>
    {
        public pictureMap()
        {
            // Primary Key
            this.HasKey(t => t.idPicture);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("picture", "ecommerce");
            this.Property(t => t.idPicture).HasColumnName("idPicture");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.picture1).HasColumnName("picture");
            this.Property(t => t.product_idProduct).HasColumnName("product_idProduct");

            // Relationships
            this.HasOptional(t => t.product)
                .WithMany(t => t.pictures)
                .HasForeignKey(d => d.product_idProduct);

        }
    }
}
