using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class recommendationMap : EntityTypeConfiguration<recommendation>
    {
        public recommendationMap()
        {
            // Primary Key
            this.HasKey(t => new { t.dateRecommendation, t.idCustomer, t.idProduct });

            // Properties
            this.Property(t => t.idCustomer)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.idProduct)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.sujet)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("recommendation", "ecommerce");
            this.Property(t => t.dateRecommendation).HasColumnName("dateRecommendation");
            this.Property(t => t.idCustomer).HasColumnName("idCustomer");
            this.Property(t => t.idProduct).HasColumnName("idProduct");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.sujet).HasColumnName("sujet");

            // Relationships
            this.HasRequired(t => t.product)
                .WithMany(t => t.recommendations)
                .HasForeignKey(d => d.idProduct);
            this.HasRequired(t => t.user)
                .WithMany(t => t.recommendations)
                .HasForeignKey(d => d.idCustomer);

        }
    }
}
