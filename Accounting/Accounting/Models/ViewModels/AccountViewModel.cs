using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Accounting.Utilities;

namespace Accounting.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        [Display(Name = "類別")]
        [Range(0, 1)]
        public AccountType Type { get; set; }

        [Required]
        [Remote("CheckAccountDate", "Validate", ErrorMessage = "日期不得大於今天")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "日期")]
        public DateTime AccountDate { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "金額")]
        public int AmountMoney { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "備註")]
        public string remark { get; set; }
    }
}