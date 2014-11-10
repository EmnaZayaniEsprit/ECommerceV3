using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class commisionMap : EntityTypeConfiguration<commision>
    {
        public commisionMap()
        {
            // Primary Key
            this.HasKey(t => t.idCommision);

            // Properties
            // Table & Column Mappings
            this.ToTable("commision", "ecommerce");
            this.Property(t => t.idCommision).HasColumnName("idCommision");
            this.Property(t => t.amount).HasColumnName("amount");
            this.Property(t => t.dateCommision).HasColumnName("dateCommision");
            this.Property(t => t.taux).HasColumnName("taux");
            this.Property(t => t.orders_idOrder).HasColumnName("orders_idOrder");

            // Relationships
            this.HasOptional(t => t.order)
                .WithMany(t => t.commisions)
                .HasForeignKey(d => d.orders_idOrder);

        }
    }
}
