using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Data.Models
{
    public partial class user
    {
        public user()
        {
            //this.addresses = new List<address>();
            this.address = new address();
            this.creditcards = new List<creditcard>();
            this.orders = new List<order>();
            this.products = new List<product>();
            this.productitems = new List<productitem>();
            this.productitemsuppliers = new List<productitemsupplier>();
            this.reclamations = new List<reclamation>();
            this.recommendations = new List<recommendation>();
            this.reviews = new List<review>();
        }

       // [Required(ErrorMessage = "Please select an account type")]
        [Display(Name = "You are a ")]
        public string DTYPE { get; set; }
        public int idUser { get; set; }
        public bool blocked { get; set; }
        [Required(ErrorMessage = "The e-mail address is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please provide a valide e-mail address")]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Required(ErrorMessage = "The first name is required")]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "The last name is required")]
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "The login is required")]
        [Display(Name = "Login")]
        public string login { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 6 characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [MinLength(6)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string confirmPassword { get; set; }


        [Required(ErrorMessage = "Please select your gender")]
        [Display(Name = "Sexe")]
        public string sexe { get; set; }

        
        public Nullable<int> idPicture { get; set; }

        [Display(Name = "Address")]
        //public virtual ICollection<address> addresses { get; set; }
       public address address { get; set; }
        public virtual ICollection<creditcard> creditcards { get; set; }
        public virtual ICollection<order> orders { get; set; }

       
       // [Required(ErrorMessage="Please select a picture")]
        [Display(Name = "Picture")]
        [DataType(DataType.ImageUrl)]
        public virtual picture picture { get; set; }
        public virtual ICollection<product> products { get; set; }
        public virtual ICollection<productitem> productitems { get; set; }
        public virtual ICollection<productitemsupplier> productitemsuppliers { get; set; }
        public virtual ICollection<reclamation> reclamations { get; set; }
        public virtual ICollection<recommendation> recommendations { get; set; }
        public virtual ICollection<review> reviews { get; set; }
    }
}
