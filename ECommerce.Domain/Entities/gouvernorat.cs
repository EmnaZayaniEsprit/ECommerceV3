using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class gouvernorat
    {
        public gouvernorat()
        {
            this.addresses = new List<address>();
        }

        public int idGouvernorat { get; set; }
        public string gouvernoratName { get; set; }
        public virtual ICollection<address> addresses { get; set; }
    }
}
