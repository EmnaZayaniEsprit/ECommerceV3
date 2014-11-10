using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ECommerce.Data.Models.Mapping;

namespace ECommerce.Data.Models
{
    public partial class ecommerceContext : DbContext
    {
        static ecommerceContext()
        {
            Database.SetInitializer<ecommerceContext>(null);
        }

        public ecommerceContext()
            : base("Name=ecommerceContext")
        {
        }

        public DbSet<address> addresses { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<commision> commisions { get; set; }
        public DbSet<creditcard> creditcards { get; set; }
        public DbSet<gouvernorat> gouvernorats { get; set; }
        public DbSet<orderitem> orderitems { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<picture> pictures { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<productitem> productitems { get; set; }
        public DbSet<productitemsupplier> productitemsuppliers { get; set; }
        public DbSet<promotion> promotions { get; set; }
        public DbSet<reclamation> reclamations { get; set; }
        public DbSet<recommendation> recommendations { get; set; }
        public DbSet<review> reviews { get; set; }
        public DbSet<shoppingcart> shoppingcarts { get; set; }
        public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new addressMap());
            modelBuilder.Configurations.Add(new categoryMap());
            modelBuilder.Configurations.Add(new commisionMap());
            modelBuilder.Configurations.Add(new creditcardMap());
            modelBuilder.Configurations.Add(new gouvernoratMap());
            modelBuilder.Configurations.Add(new orderitemMap());
            modelBuilder.Configurations.Add(new orderMap());
            modelBuilder.Configurations.Add(new pictureMap());
            modelBuilder.Configurations.Add(new productMap());
            modelBuilder.Configurations.Add(new productitemMap());
            modelBuilder.Configurations.Add(new productitemsupplierMap());
            modelBuilder.Configurations.Add(new promotionMap());
            modelBuilder.Configurations.Add(new reclamationMap());
            modelBuilder.Configurations.Add(new recommendationMap());
            modelBuilder.Configurations.Add(new reviewMap());
            modelBuilder.Configurations.Add(new shoppingcartMap());
            modelBuilder.Configurations.Add(new userMap());
        }
    }
}
