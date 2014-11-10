using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class shoppingcartMap : EntityTypeConfiguration<shoppingcart>
    {
        public shoppingcartMap()
        {
            // Primary Key
            this.HasKey(t => t.idShoppingCart);

            // Properties
            this.Property(t => t.currency)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("shoppingcart", "ecommerce");
            this.Property(t => t.idShoppingCart).HasColumnName("idShoppingCart");
            this.Property(t => t.currency).HasColumnName("currency");
            this.Property(t => t.stateShoppingCart).HasColumnName("stateShoppingCart");
            this.Property(t => t.totalShoppingCart).HasColumnName("totalShoppingCart");
        }
    }
}
