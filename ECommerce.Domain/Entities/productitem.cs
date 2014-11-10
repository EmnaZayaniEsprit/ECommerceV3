using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class productitem
    {
        public System.DateTime dateSupplied { get; set; }
        public int idParticularVendor { get; set; }
        public int idProduct { get; set; }
        public int quantity { get; set; }
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
