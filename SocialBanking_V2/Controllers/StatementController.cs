using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainSocialClass;
namespace SocialBanking_V2.Controllers
{
    public class StatementController : Controller
    {
        // GET: Statement
        public ActionResult Index()
        {
            Statement NewStatement = new Statement();
            NewStatement = (Statement)TempData["model"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            return View(NewStatement);
        }


        public ActionResult sendStatement(Statement StatementInfo)
        {

            Statement newStatement = new Statement();
            try
            {

                //bool GSMNumberIsNAN = Utility.numberchecker(StatementInfo.AccountNumber);
              
                if (String.IsNullOrEmpty(StatementInfo.AccountNumber) || !StatementInfo.AccountNumber.Length.Equals(10))
                {                  
                    newStatement.statusCode = "0";
                    TempData["model"] = newStatement;
                    TempData["ErrorMessage"] = "Please input a valid Account no. ";
                    return RedirectToAction("Index");
                }

                if (String.IsNullOrEmpty(StatementInfo.Email))
                {
                    newStatement.statusCode = "0";
                    TempData["model"] = newStatement;
                    TempData["ErrorMessage"] = "Please enter a valid Pin & Token Email.";
                    return RedirectToAction("Index");
                }
                if (StatementInfo.Period.Equals(null))
                {
                    newStatement.statusCode = "0";
                    TempData["model"] = newStatement;
                    TempData["ErrorMessage"] = "Please select a transaction period.";
                    return RedirectToAction("Index");
                }
                if (String.IsNullOrEmpty(StatementInfo.PinToken))
                {                  
                    newStatement.statusCode = "0";
                    TempData["model"] = newStatement;
                    TempData["ErrorMessage"] = "Please enter a valid Pin & Token.";
                    return RedirectToAction("Index");
                }
               
                
                else
                {
                   
                    StatementInfo.EndDate = DateTime.Today.ToString("dd/MM/yyyy");
                    StatementInfo.BeginDate = DateTime.Today.AddDays(StatementInfo.Period).ToString("dd/MM/yyyy");
                    newStatement = new SocialActionClass().getAccountStatement(StatementInfo);

                   
                    if (newStatement.statusCode == "00")
                    {
                       
                        TempData["ErrorMessage"] = "Transaction Successful";
                        TempData["model"] = newStatement;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        newStatement.statusCode = "0";
                        TempData["model"] = newStatement;
                        TempData["ErrorMessage"] = newStatement.statusMessage;
                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception ex)
            {
                newStatement.statusCode = "0";
                TempData["ErrorMessage"] = ex.Message;
            }


            return View();
        }
    }
}