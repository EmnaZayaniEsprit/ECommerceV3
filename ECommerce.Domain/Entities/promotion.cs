using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Models
{
    public partial class promotion
    {
        public promotion()
        {
            this.products = new List<product>();
            this.user = new user();
        }


        [Key]
        public int idPromotion { get; set; }
        public int idUser { get; set; }
        public user user { get; set; }
        public Nullable<System.DateTime> dateDebut { get; set; }
        public Nullable<System.DateTime> dateFin { get; set; }
        public string description { get; set; }
        public string nomPromotion { get; set; }
        public int taux { get; set; }
        public virtual ICollection<product> products { get; set; }
    }
}
