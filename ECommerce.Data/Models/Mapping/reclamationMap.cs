using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class reclamationMap : EntityTypeConfiguration<reclamation>
    {
        public reclamationMap()
        {
            // Primary Key
            this.HasKey(t => t.idReclamation);

            // Properties
            this.Property(t => t.message)
                .HasMaxLength(255);

            this.Property(t => t.subject)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("reclamation", "ecommerce");
            this.Property(t => t.idReclamation).HasColumnName("idReclamation");
            this.Property(t => t.message).HasColumnName("message");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.subject).HasColumnName("subject");
            this.Property(t => t.user_idUser).HasColumnName("user_idUser");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.reclamations)
                .HasForeignKey(d => d.user_idUser);

        }
    }
}
