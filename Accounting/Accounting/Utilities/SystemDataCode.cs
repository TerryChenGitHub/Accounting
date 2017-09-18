using System;
using System.Collections.Generic;
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
    public enum AccountType : int
    {
        支出 = 0,
        收入 = 1
    }
}