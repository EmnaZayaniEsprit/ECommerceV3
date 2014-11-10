using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class orderMap : EntityTypeConfiguration<order>
    {
        public orderMap()
        {
            // Primary Key
            this.HasKey(t => t.idOrder);

            // Properties
            this.Property(t => t.paymentMethod)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("orders", "ecommerce");
            this.Property(t => t.idOrder).HasColumnName("idOrder");
            this.Property(t => t.commision).HasColumnName("commision");
            this.Property(t => t.deleveryAddress).HasColumnName("deleveryAddress");
            this.Property(t => t.orderDate).HasColumnName("orderDate");
            this.Property(t => t.paymentMethod).HasColumnName("paymentMethod");
            this.Property(t => t.stateOrder).HasColumnName("stateOrder");
            this.Property(t => t.totalAmount).HasColumnName("totalAmount");
            this.Property(t => t.customer_idUser).HasColumnName("customer_idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.orders)
                .HasForeignKey(d => d.customer_idUser);

        }
    }
}
