using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class commision
    {
        public int idCommision { get; set; }
        public double amount { get; set; }
        public Nullable<System.DateTime> dateCommision { get; set; }
        public double taux { get; set; }
        public Nullable<int> orders_idOrder { get; set; }
        public virtual order order { get; set; }
    }
}
