using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class user
    {
        public user()
        {
            this.addresses = new List<address>();
            this.creditcards = new List<creditcard>();
            this.orders = new List<order>();
            this.products = new List<product>();
            this.productitems = new List<productitem>();
            this.productitemsuppliers = new List<productitemsupplier>();
            this.reclamations = new List<reclamation>();
            this.recommendations = new List<recommendation>();
            this.reviews = new List<review>();
        }

        public string DTYPE { get; set; }
        public int idUser { get; set; }
        public bool blocked { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string sexe { get; set; }
        public Nullable<int> idPicture { get; set; }
        public virtual ICollection<address> addresses { get; set; }
        public virtual ICollection<creditcard> creditcards { get; set; }
        public virtual ICollection<order> orders { get; set; }
        public virtual picture picture { get; set; }
        public virtual ICollection<product> products { get; set; }
        public virtual ICollection<productitem> productitems { get; set; }
        public virtual ICollection<productitemsupplier> productitemsuppliers { get; set; }
        public virtual ICollection<reclamation> reclamations { get; set; }
        public virtual ICollection<recommendation> recommendations { get; set; }
        public virtual ICollection<review> reviews { get; set; }
    }
}
