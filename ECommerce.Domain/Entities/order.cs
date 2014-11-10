using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class order
    {
        public order()
        {
            this.commisions = new List<commision>();
            this.orderitems = new List<orderitem>();
        }

        public int idOrder { get; set; }
        public byte[] commision { get; set; }
        public byte[] deleveryAddress { get; set; }
        public Nullable<System.DateTime> orderDate { get; set; }
        public string paymentMethod { get; set; }
        public bool stateOrder { get; set; }
        public float totalAmount { get; set; }
        public Nullable<int> customer_idUser { get; set; }
        public virtual ICollection<commision> commisions { get; set; }
        public virtual ICollection<orderitem> orderitems { get; set; }
        public virtual user user { get; set; }
    }
}
