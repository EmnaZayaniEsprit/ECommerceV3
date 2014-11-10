using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class creditcard
    {
        public int idCreditCard { get; set; }
        public string code { get; set; }
        public string type { get; set; }
        public Nullable<System.DateTime> validity { get; set; }
        public Nullable<int> customer_idUser { get; set; }
        public virtual user user { get; set; }
    }
}
