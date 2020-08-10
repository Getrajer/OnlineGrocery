using OnlineGrocery.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGrocery.ViewModels
{
    public class CheckoutViewModel
    {
        public double FullPrice { get; set; }
        public int FullAmmount { get; set; }

        public string CartId { get; set; }

        public List<ShoppingCartItemModel> OrderItems { get; set; }

        [Display(Name = "Extra Information")]
        public string AdditionalInformation { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [RegularExpression(@"^4[0-9]{12}(?:[0-9]{3})?$", ErrorMessage = "This is not valid credit card!")]
        public string CardNumber { get; set; }

        [Display(Name = "MM")]
        public string MonthExpired { get; set; }

        [Display(Name = "YY")]
        public string YearExpired { get; set; }

        [Required]
        [Display(Name = "Security Code")]
        public int SecurityCode { get; set; }
    }
}
