using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class shoppingcart
    {
        public int idShoppingCart { get; set; }
        public string currency { get; set; }
        public bool stateShoppingCart { get; set; }
        public double totalShoppingCart { get; set; }
    }
}
