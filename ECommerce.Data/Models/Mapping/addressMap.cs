using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class addressMap : EntityTypeConfiguration<address>
    {
        public addressMap()
        {
            // Primary Key
            this.HasKey(t => t.idAddress);

            // Properties
            this.Property(t => t.city)
                .HasMaxLength(255);

            this.Property(t => t.country)
                .HasMaxLength(255);

            this.Property(t => t.street)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("address", "ecommerce");
            this.Property(t => t.idAddress).HasColumnName("idAddress");
            this.Property(t => t.city).HasColumnName("city");
            this.Property(t => t.country).HasColumnName("country");
            this.Property(t => t.number).HasColumnName("number");
            this.Property(t => t.postalCode).HasColumnName("postalCode");
            this.Property(t => t.street).HasColumnName("street");
            this.Property(t => t.gouvernorat_idGouvernorat).HasColumnName("gouvernorat_idGouvernorat");
            this.Property(t => t.user_idUser).HasColumnName("user_idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.addresses)
                .HasForeignKey(d => d.user_idUser);
            this.HasOptional(t => t.gouvernorat)
                .WithMany(t => t.addresses)
                .HasForeignKey(d => d.gouvernorat_idGouvernorat);

        }
    }
}
