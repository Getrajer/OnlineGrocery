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
        [RegularExpression(@"^5[1-5]\d{14}$", ErrorMessage = "This is not valid credit card!")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "MM")]
        [RegularExpression(@"[1-9]|1[0-2]$", ErrorMessage = "Not valid month!")]
        public string MonthExpired { get; set; }

        [Required]
        [Display(Name = "YY")]
        public string YearExpired { get; set; }

        [Required]
        [Display(Name = "Security Code")]
        public int SecurityCode { get; set; }
    }
}
