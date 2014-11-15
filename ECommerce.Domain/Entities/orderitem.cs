using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class orderitem
    {
        public int idOrderItem { get; set; }
        public int quantity { get; set; }
        public Nullable<int> order_idOrder { get; set; }
        public Nullable<int> product_idProduct { get; set; }
        public Nullable<System.DateTime> productItemSupplier_date { get; set; }
        public Nullable<int> productItemSupplier_idProduct { get; set; }
        public Nullable<int> productItemSupplier_idSupplier { get; set; }
        public virtual productitemsupplier productitemsupplier { get; set; }
        public virtual order order { get; set; }
        public virtual product product { get; set; }


        //*****************************************************************

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
            orderitem other = (orderitem)obj;
            if (product_idProduct != other.product_idProduct)
            {
                return false;
            }
            return true;
        }


        //******************************************************


    }
}
