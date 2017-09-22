using Accounting.Models;
using Accounting.Models.Service;
using Accounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;


namespace Accounting.Controllers
{
    public class AccountController : Controller
    {

        private AccountBookService AccountBookService = new AccountBookService();

        //首頁
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        //新增
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountViewModel pageData)
        {
            //Thread.Sleep(3000);

            if (ModelState.IsValid)
            {
                AccountBook objAccountBook = new AccountBook
                {
                   Id = Guid.NewGuid(),
                   Categoryyy = (int)(pageData.Type),
                   Amounttt = pageData.AmountMoney,
                   Dateee = pageData.AccountDate,
                   Remarkkk = pageData.remark
                };

               var AddService = AccountBookService.AddData(objAccountBook);
            }

            return View("Index");
           // return RedirectToAction("ListAccountData");
        }


        /// <summary>
        /// 列表資料
        /// </summary>
        /// <param name="AccountViewModel"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ListAccountData()
        {
            #region 第一天測試資料綁定
            //List<AccountViewModel> listdata = new List<AccountViewModel>();

            ////use GUID HashCode random seed
            //Random rnd = new Random(Guid.NewGuid().GetHashCode());

            ////create test 1000 count data
            //for (int i = 0; i < 1000; i++)
            //{
            //    int typevalue = rnd.Next(1, 3);

            //    AccountViewModel objAccountData = new AccountViewModel
            //    {
            //        Type = typevalue == ((int)Type.收入) ? "收入" : "支出",
            //        AccountDate = RandomAccountDate(rnd),
            //        AmountMoney = rnd.Next(100, 500),
            //        remark = RandomRemarks(rnd, typevalue)
            //    };

            //    listdata.Add(objAccountData);
            //}
            #endregion

            var listdata = AccountBookService.GetAllAccountBook().Take(5);

            return View(listdata);
        }

        #region 第一天作業測試資料

        /// <summary>
        /// 記帳類別
        /// </summary>
        private enum Type : int
        {
            支出 = 1,
            收入 = 2
        }

        /// <summary>
        /// 亂數日期(2017/01/01~今日)
        /// </summary>
        /// <returns></returns>
        private DateTime RandomAccountDate(Random random)
        {
            DateTime start = new DateTime(2017, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(random.Next(range));
        }


        /// <summary>
        /// 亂數備註
        /// </summary>
        /// <param name="random"></param>
        /// <param name="typevalue"></param>
        /// <returns></returns>
        private string RandomRemarks(Random random, int typevalue)
        {
            var remarks = new List<string>();

            if (typevalue == ((int)Type.支出))
            {
                remarks = new List<string>{
                            "衣服",
                            "褲子",
                            "飲料",
                            "香菸",
                            "啤酒",
                            "加油",
                            "唱歌"
                            };

            }
            else if (typevalue == ((int)Type.收入))
            {
                remarks = new List<string>{
                            "打工",
                            "加班",
                            "網拍",
                            "婚禮攝影",
                            "其他收入",
                            };
            }

            string remark = remarks[random.Next(remarks.Count)];
            return remark;
        }

        #endregion
    }
}