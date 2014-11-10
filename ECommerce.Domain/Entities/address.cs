using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class address
    {
        public int idAddress { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public int number { get; set; }
        public int postalCode { get; set; }
        public string street { get; set; }
        public Nullable<int> gouvernorat_idGouvernorat { get; set; }
        public Nullable<int> user_idUser { get; set; }
        public virtual user user { get; set; }
        public virtual gouvernorat gouvernorat { get; set; }
    }
}
