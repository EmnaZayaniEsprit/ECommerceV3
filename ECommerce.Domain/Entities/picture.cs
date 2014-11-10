using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class picture
    {
        public picture()
        {
            this.users = new List<user>();
        }

        public int idPicture { get; set; }
        public string description { get; set; }
        public byte[] picture1 { get; set; }
        public Nullable<int> product_idProduct { get; set; }
        public virtual ICollection<user> users { get; set; }
        public virtual product product { get; set; }
    }
}
