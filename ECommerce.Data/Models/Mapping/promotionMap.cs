using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.Data.Models.Mapping
{
    public class promotionMap : EntityTypeConfiguration<promotion>
    {
        public promotionMap()
        {
            // Primary Key
            this.HasKey(t => t.idPromotion);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.nomPromotion)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("promotion", "ecommerce");
            this.Property(t => t.idPromotion).HasColumnName("idPromotion");
            this.Property(t => t.dateDebut).HasColumnName("dateDebut");
            this.Property(t => t.dateFin).HasColumnName("dateFin");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.nomPromotion).HasColumnName("nomPromotion");
            this.Property(t => t.taux).HasColumnName("taux");
            this.Property(t => t.idUser).HasColumnName("Iduser");

        }
    }
}
