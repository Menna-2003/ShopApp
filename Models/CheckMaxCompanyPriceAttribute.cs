using System.ComponentModel.DataAnnotations;

namespace ShopApp.Models {
    public class CheckMaxCompanyPriceAttribute :ValidationAttribute {
        private readonly int _maxCompanyPrice;
        public CheckMaxCompanyPriceAttribute ( int price ) {
            _maxCompanyPrice = price;
        }
        protected override ValidationResult? IsValid ( object? value, ValidationContext validationContext ) {
            Product product = ( Product ) validationContext.ObjectInstance;
            int price;
            if(!int.TryParse(value.ToString(), out price)) {
                return new ValidationResult( "invalid price value" );
            }
            if(product.companyId == 1 && price > _maxCompanyPrice) {
                return new ValidationResult("Price for Nike must be less than" + _maxCompanyPrice.ToString() );
            }
            return ValidationResult.Success;
        }
    }
}
