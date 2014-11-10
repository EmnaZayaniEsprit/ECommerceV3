using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class reviewMap : EntityTypeConfiguration<review>
    {
        public reviewMap()
        {
            // Primary Key
            this.HasKey(t => new { t.dateReview, t.idCustomer, t.idProduct });

            // Properties
            this.Property(t => t.idCustomer)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.comment)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("review", "ecommerce");
            this.Property(t => t.dateReview).HasColumnName("dateReview");
            this.Property(t => t.idCustomer).HasColumnName("idCustomer");
            this.Property(t => t.idProduct).HasColumnName("idProduct");
            this.Property(t => t.comment).HasColumnName("comment");

            // Relationships
            this.HasRequired(t => t.product)
                .WithMany(t => t.reviews)
                .HasForeignKey(d => d.idProduct);
            this.HasRequired(t => t.user)
                .WithMany(t => t.reviews)
                .HasForeignKey(d => d.idCustomer);

        }
    }
}
