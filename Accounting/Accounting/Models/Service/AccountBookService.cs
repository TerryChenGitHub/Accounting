using Accounting.Models.ViewModels;
using Accounting.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Accounting.Models.Service
{
    public class AccountBookService
    {
        private AccountBookModel db = new AccountBookModel();

        /// <summary>
        /// 取得所有記帳資料
        /// </summary>
        /// <returns></returns>
        public List<AccountViewModel> GetAllAccountBook()
        {
            List<AccountViewModel> listdata = new List<AccountViewModel>();

            var AccountBooks = db.AccountBook.OrderByDescending(q => q.Dateee).ToList();

            foreach (var item in AccountBooks)
            {
                AccountViewModel objAccountData = new AccountViewModel
                {
                    Type = item.Categoryyy == ((int)AccountType.收入)
                                      ? Enum.GetName(typeof(AccountType), AccountType.收入)
                                      : Enum.GetName(typeof(AccountType), AccountType.支出),

                    AccountDate = item.Dateee,
                    AmountMoney = item.Amounttt,
                    remark = item.Remarkkk
                };

                listdata.Add(objAccountData);
            }

            return listdata;
        }

    }
}