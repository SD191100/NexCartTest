using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NexCart.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MaxLength(100)]
        public string LastName { get; set; }

        [Required, MaxLength(100)]
        public string CompanyName { get; set; }

        [Required]
        public int GSTNumber { get; set; }

        [Required, MaxLength(100)]
        public string BussinessPhone { get; set; }

        [Required, MaxLength(100)]
        public string BankAccountNumber { get; set; }

        [Required, MaxLength(100)]
        public string IFSCCode { get; set; }

        // Navigations
        public ICollection<Product> Products { get; set; }
        public Address Address { get; set; }
    }
}

