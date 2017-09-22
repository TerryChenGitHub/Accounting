using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Accounting.Utilities
{
    public class SystemDataCode
    {

    }

    /// <summary>
    /// 記帳類別
    /// </summary>
    public enum AccountType 
    {
        [Display(Name = "支出")]
        支出 = 0,
        [Display(Name = "收入")]
        收入 = 1
    }
}