using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models {
    public class Product {
        [Key]
        public int Id {
            get; set;
        }
        [Required]
        [DeniedValues("ABC", "abc")]
        [RegularExpression(@"^[a-zA-Z' ''-'\s]{,40}$",
            ErrorMessage = "Invalid Name, Some characters are not allowed")]
        public string Name {
            get; set;
        }
        [Required(ErrorMessage = "Description is required")]
        [Length(5,20)]
        [RegularExpression( @"^[a-zA-Z' ''-'\s]{,40}$",
            ErrorMessage = "Invalid Description, Some characters are not allowed" )]
        public string Description {
            get; set;
        }
        [Required]
        [Range(5,5000,ErrorMessage = "Price Range is between 5 and 5000")]
        [CheckMaxCompanyPrice(2000)]
        public float Price {
            get; set;
        }
        [Required]
        public int Quantity {
            get; set;
        }
        public bool EnableSize {
            get; set;
        }
        public int companyId {
            get; set; 
        }
        [ForeignKey( "companyId" )]
        public Company? company {
            get; set;
        }
    }
}
