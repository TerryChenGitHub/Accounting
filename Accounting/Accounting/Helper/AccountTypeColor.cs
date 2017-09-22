using Accounting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Accounting.Helper
{
    public static class AccountTypeColor
    {
        /// <summary>
        /// 支出與收入套用html的Class
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pAccountType"></param>
        /// <returns></returns>
        public static MvcHtmlString FormateAccountTypeColor(this HtmlHelper helper, int pAccountType)
        {
            string HtmlColor = "";

            HtmlColor = string.Format("<td class=\"{0}\">{1}</td>"
                , pAccountType == (int)(AccountType.支出)? "text-danger": "text-primary"
                , Enum.GetName(typeof(AccountType), pAccountType));

            return new MvcHtmlString(HtmlColor);
        }
    }
}