using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainSocialClass;

namespace SocialBanking_V2.Controllers
{
    public class AccountQueryController : Controller
    {
        // GET: AccountQuery
        public ActionResult Index()
        {
            AccountBalance NewQuery = new AccountBalance();
            NewQuery = (AccountBalance)TempData["model"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            return View(NewQuery);
        }
        public ActionResult GetAcctQuery(AccountBalance AccountInfo)
        {

            AccountBalance newBalance = new AccountBalance();
            try
            {
                if (String.IsNullOrEmpty(AccountInfo.AccountNumber) || String.IsNullOrEmpty(AccountInfo.MobileNumber) || !AccountInfo.AccountNumber.Length.Equals(10))
                {
                   // kvp = new KeyValuePair<string, string>("01", "Please ensure you have provided a correct account number and mobile number.");
                    AccountInfo.statusCode = "0";
                    TempData["model"] = AccountInfo;
                    TempData["ErrorMessage"] = "Please ensure you have provided a correct account number and mobile number.";
                    return RedirectToAction("Index");
                }
                else
                {
                    newBalance = new SocialActionClass().getAccountBalance(AccountInfo);
                    if (newBalance.statusCode == "00")
                    {
                      
                        TempData["ErrorMessage"] = "Balance Has been sent to ur phone number supplied";
                        TempData["model"] = newBalance;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        newBalance.statusCode = "0";
                        TempData["model"] = newBalance;
                        TempData["ErrorMessage"] = newBalance.statusMessage;
                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {
                newBalance.statusCode = "0";
                TempData["ErrorMessage"] = ex.Message;
            }

            
            return View();
        }
    }
}