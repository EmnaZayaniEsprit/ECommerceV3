using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class review
    {
        public System.DateTime dateReview { get; set; }
        public int idCustomer { get; set; }
        public int idProduct { get; set; }
        public string comment { get; set; }
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
