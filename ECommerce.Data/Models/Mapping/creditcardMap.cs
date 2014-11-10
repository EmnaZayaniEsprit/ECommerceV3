using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class creditcardMap : EntityTypeConfiguration<creditcard>
    {
        public creditcardMap()
        {
            // Primary Key
            this.HasKey(t => t.idCreditCard);

            // Properties
            this.Property(t => t.code)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("creditcard", "ecommerce");
            this.Property(t => t.idCreditCard).HasColumnName("idCreditCard");
            this.Property(t => t.code).HasColumnName("code");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.validity).HasColumnName("validity");
            this.Property(t => t.customer_idUser).HasColumnName("customer_idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.creditcards)
                .HasForeignKey(d => d.customer_idUser);

        }
    }
}
