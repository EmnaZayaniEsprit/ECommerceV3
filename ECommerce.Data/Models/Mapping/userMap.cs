using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.idUser);

            // Properties
            this.Property(t => t.DTYPE)
                .IsRequired()
                .HasMaxLength(31);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.login)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.sexe)
                .IsRequired()
                .HasMaxLength(1);

            // Table & Column Mappings
            this.ToTable("user", "ecommerce");
            this.Property(t => t.DTYPE).HasColumnName("DTYPE");
            this.Property(t => t.idUser).HasColumnName("idUser");
            this.Property(t => t.blocked).HasColumnName("blocked");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.login).HasColumnName("login");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.sexe).HasColumnName("sexe");
            this.Property(t => t.idPicture).HasColumnName("idPicture");

            // Relationships
            this.HasOptional(t => t.picture)
                .WithMany(t => t.users)
                .HasForeignKey(d => d.idPicture);

        }
    }
}
