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
                    Type = item.Categoryyy == (int)(AccountType.支出) ? AccountType.支出 : AccountType.收入,
                    AccountDate = item.Dateee,
                    AmountMoney = item.Amounttt,
                    remark = item.Remarkkk
                };

                listdata.Add(objAccountData);
            }

            return listdata;
        }

        /// <summary>
        /// 新增記帳本資料
        /// </summary>
        /// <param name="objAccount"></param>
        public string AddData(AccountBook objAccount)
        {
            string strMsg = "";

            try
            {
                db.AccountBook.Add(objAccount);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                strMsg = ex.Message;
            }

            return strMsg;
        }
    }
}