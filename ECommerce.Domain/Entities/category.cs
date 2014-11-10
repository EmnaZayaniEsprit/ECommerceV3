using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class category
    {
        public category()
        {
            this.products = new List<product>();
        }

        public int idCategory { get; set; }
        public string name { get; set; }
        public virtual ICollection<product> products { get; set; }
    }
}
