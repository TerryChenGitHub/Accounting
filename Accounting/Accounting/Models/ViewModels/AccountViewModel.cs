using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Models.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        [Display(Name = "類別")]
        public string Type { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "日期")]
        public DateTime AccountDate { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        [Display(Name = "金額")]
        public int AmountMoney { get; set; }

        [Display(Name = "備註")]
        public string remark { get; set; }
    }
}