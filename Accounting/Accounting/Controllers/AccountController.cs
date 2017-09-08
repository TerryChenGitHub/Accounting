using Accounting.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Accounting.Controllers
{
    public class AccountController : Controller
    {

        //首頁
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AccountViewModel pagedata)
        {
            pagedata.Type = pagedata.Type == Type.收入 ? "收入" : "支出";

            ViewData["PageData"] = pagedata;

            return View();
        }

        /// <summary>
        /// 列表資料
        /// </summary>
        /// <param name="AccountViewModel"></param>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult ListAccountData(AccountViewModel AccountViewModel)
        {
            var ShamData = TempData["ShamData"];

            List<AccountViewModel> listdata = new List<AccountViewModel>();

            //keep testdata
            if (ShamData != null)
            {
                listdata = (List<AccountViewModel>)ShamData;

                if (AccountViewModel.Type != "")
                    listdata.Add(AccountViewModel);
            }
            else
            {
                //use GUID HashCode random seed
                Random rnd = new Random(Guid.NewGuid().GetHashCode());

                //create test 1000 count data
                for (int i = 0; i < 1000; i++)
                {
                    string typevalue = rnd.Next(1, 3).ToString();

                    AccountViewModel objAccountData = new AccountViewModel
                    {
                        Type = typevalue == Type.收入 ? "收入" : "支出",
                        AccountDate = RandomAccountDate(rnd),
                        AmountMoney = rnd.Next(100, 500),
                        remark = RandomRemarks(rnd, typevalue)
                    };

                    listdata.Add(objAccountData);
                }

            }

            return View(listdata);
        }


        /// <summary>
        /// 記帳類別
        /// </summary>
        private struct Type
        {
            public const string 支出 = "1";
            public const string 收入 = "2";
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
        private string RandomRemarks(Random random, string typevalue)
        {
            var remarks = new List<string>();

            if (typevalue == Type.支出)
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
            else if (typevalue == Type.收入)
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

    }
}