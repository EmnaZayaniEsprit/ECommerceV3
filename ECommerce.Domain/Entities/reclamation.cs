using System;
using System.Collections.Generic;

namespace ECommerce.Data.Models
{
    public partial class reclamation
    {
        public int idReclamation { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
        public string subject { get; set; }
        public Nullable<int> user_idUser { get; set; }
        public virtual user user { get; set; }
    }
}
