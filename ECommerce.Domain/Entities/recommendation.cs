using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class recommendation
    {
        public System.DateTime dateRecommendation { get; set; }
        public int idCustomer { get; set; }
        public int idProduct { get; set; }
        public string email { get; set; }
        public string sujet { get; set; }
        public virtual product product { get; set; }
        public virtual user user { get; set; }
    }
}
