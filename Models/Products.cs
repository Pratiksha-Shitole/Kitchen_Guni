


using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitchen_Guni.Models
{
    [Table("Products")]

    public class Product
    {

        
        [Display(Name = "Product ID")]
        [Key]
        [ForeignKey(nameof(Product.User))]
        public Guid UserId { get; set; }


        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [StringLength(10, ErrorMessage = "{0} should contain {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} should contain {1} characters.")]
        public string ProductName { get; set; }


        [Display(Name = "Prodcut Description")]
        [MinLength(2, ErrorMessage = "{0} should have at least {1} characters.")]
        [StringLength(60, ErrorMessage = "{0} should not contain more than {1} characters.")]
        public string ProductDescription { get; set; }

        [Display(Name = "Price")]
        public int Price { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }





        #region Navigational Properties to the MyIdentityUser model (1:1 mapping)

        public MyIdentityUser User { get; set; }

        #endregion

    }
}