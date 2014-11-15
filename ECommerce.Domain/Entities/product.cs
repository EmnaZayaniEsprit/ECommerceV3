using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class product
    {
        public product()
        {
           // this.promotion = new promotion();
            this.orderitems = new List<orderitem>();
            this.pictures = new List<picture>();
            this.productitemsuppliers = new List<productitemsupplier>();
            this.recommendations = new List<recommendation>();
            this.reviews = new List<review>();
            this.productitems = new List<productitem>();
        }

        public int idProduct { get; set; }
        public string currency { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }
        public double taxe { get; set; }
        public Nullable<int> category_idCategory { get; set; }
        public Nullable<int> promotion_idPromotion { get; set; }
        public Nullable<int> supplier_idUser { get; set; }
        public virtual category category { get; set; }
        public virtual ICollection<orderitem> orderitems { get; set; }
        public virtual ICollection<picture> pictures { get; set; }
        public virtual ICollection<productitemsupplier> productitemsuppliers { get; set; }
        public virtual user user { get; set; }
        public virtual promotion promotion { get; set; }
        public virtual ICollection<recommendation> recommendations { get; set; }
        public virtual ICollection<review> reviews { get; set; }
        public virtual ICollection<productitem> productitems { get; set; }


// methode to override Equals : Saaaaf 

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (this.GetType() != obj.GetType())
            {
                return false;
            }
            product other = (product)obj;
            if (idProduct != other.idProduct)
            {
                return false;
            }
            return true;
        }



        //***********




    }
}
