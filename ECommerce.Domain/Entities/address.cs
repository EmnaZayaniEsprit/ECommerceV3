using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Data.Models
{
    public partial class address
    {
        public int idAddress { get; set; }

        [Required(ErrorMessage = "The city is required")]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage = "The country is required")]
        [Display(Name = "Country")]
        public string country { get; set; }

        [Required(ErrorMessage = "The number is required")]
        [Display(Name = "Number")]
        [Range(0, int.MaxValue)]
        public int number { get; set; }

        [Required(ErrorMessage = "The postal code is required")]
        [Display(Name = "Postal code")]
        [DataType(DataType.PostalCode)]
        public int postalCode { get; set; }

        [Required(ErrorMessage = "The street is required")]
        [Display(Name = "Street")]
        public string street { get; set; }
        public Nullable<int> gouvernorat_idGouvernorat { get; set; }
        public Nullable<int> user_idUser { get; set; }
        public virtual user user { get; set; }

        
        public virtual gouvernorat gouvernorat { get; set; }
    }
}
