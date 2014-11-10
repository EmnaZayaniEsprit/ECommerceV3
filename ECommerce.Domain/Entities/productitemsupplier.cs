using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class productitemsupplier
    {
        public productitemsupplier()
        {
            this.orderitems = new List<orderitem>();
        }

        public System.DateTime date { get; set; }
        public int idProduct { get; set; }
        public int idSupplier { get; set; }
        public int quantity { get; set; }
        public virtual ICollection<orderitem> orderitems { get; set; }
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
