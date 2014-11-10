using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class orderitemMap : EntityTypeConfiguration<orderitem>
    {
        public orderitemMap()
        {
            // Primary Key
            this.HasKey(t => t.idOrderItem);

            // Properties
            // Table & Column Mappings
            this.ToTable("orderitem", "ecommerce");
            this.Property(t => t.idOrderItem).HasColumnName("idOrderItem");
            this.Property(t => t.quantity).HasColumnName("quantity");
            this.Property(t => t.order_idOrder).HasColumnName("order_idOrder");
            this.Property(t => t.product_idProduct).HasColumnName("product_idProduct");
            this.Property(t => t.productItemSupplier_date).HasColumnName("productItemSupplier_date");
            this.Property(t => t.productItemSupplier_idProduct).HasColumnName("productItemSupplier_idProduct");
            this.Property(t => t.productItemSupplier_idSupplier).HasColumnName("productItemSupplier_idSupplier");

            // Relationships
            this.HasOptional(t => t.productitemsupplier)
                .WithMany(t => t.orderitems)
                .HasForeignKey(d => new { d.productItemSupplier_date, d.productItemSupplier_idProduct, d.productItemSupplier_idSupplier });
            this.HasOptional(t => t.order)
                .WithMany(t => t.orderitems)
                .HasForeignKey(d => d.order_idOrder);
            this.HasOptional(t => t.product)
                .WithMany(t => t.orderitems)
                .HasForeignKey(d => d.product_idProduct);

        }
    }
}
