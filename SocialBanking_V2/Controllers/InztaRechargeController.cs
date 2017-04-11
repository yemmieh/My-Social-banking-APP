using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MainSocialClass;

namespace SocialBanking_V2.Controllers
{
    public class InztaRechargeController : Controller
    {
        // GET: InztaRecharge
        public ActionResult Index()
        {
            Recharge NewRecharge = new Recharge();
            if (TempData["model"] != null)
            {
                NewRecharge = (Recharge)TempData["model"];
                //NewRecharge.Type = "0";
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            }
            else {
                NewRecharge.Type = "0";
                //NewRecharge.RechargeAmount = 0;
            }
           
            return View(NewRecharge);
        }

        public ActionResult rechargeCard(Recharge RechargeInfo)
        {

            Recharge newRecharge = new Recharge();
            try
            {

                //bool GSMNumberIsNAN = Utility.numberchecker(RechargeInfo.GSMNumber);
                //if (RechargeInfo.GSMNumber == null)
                //{
                //    newRecharge.statusCode = "0";
                //    TempData["model"] = newRecharge;
                //    TempData["ErrorMessage"] = "GSM Number should not be empty";
                //    return RedirectToAction("Index");

                //}

             if (RechargeInfo.Operator == 0 || RechargeInfo.Operator.Equals(null)) {
                //kvp = new KeyValuePair<string, string>("01", "Please ensure you have selected the operator type. ");
                    newRecharge.statusCode = "0";
                    TempData["model"] = newRecharge;
                    TempData["ErrorMessage"] = "Please ensure you have selected the operator type.";
                    return RedirectToAction("Index");
            }

            if (RechargeInfo.RechargeAmount <= 0 || RechargeInfo.RechargeAmount.Equals(null)) {
                //kvp = new KeyValuePair<string, string>("01", "Please ensure you have provided a valid recharge amount greater than 0. ");
                    newRecharge.statusCode = "0";
                    TempData["model"] = newRecharge;
                    TempData["ErrorMessage"] = "Please ensure you have provided a valid recharge amount greater than 0. ";
                    return RedirectToAction("Index");
            }
            if ( RechargeInfo.RechargeAmount > 3000 ) {
                //kvp = new KeyValuePair<string, string>("01", "Maximum daily airtime recharge amount is Three thousand (3000) naira. ");
                    newRecharge.statusCode = "0";
                    TempData["model"] = newRecharge;
                    TempData["ErrorMessage"] = "Maximum daily airtime recharge amount is Three thousand (3000) naira. ";
                    return RedirectToAction("Index");
            }

            if ( !RechargeInfo.Type.Equals(1) ) {

                if ( String.IsNullOrEmpty(RechargeInfo.GSMNumber) || !RechargeInfo.GSMNumber.Length.Equals(11) ) {
                    //kvp = new KeyValuePair<string, string>("02", "Please ensure you have provided a correct phone number. ");
                    newRecharge.statusCode = "0";
                    TempData["model"] = newRecharge;
                    TempData["ErrorMessage"] = "Please ensure you have provided a correct phone number. ";
                    return RedirectToAction("Index");
                }



            }
            else if (RechargeInfo.Type.Equals(1))
            {
                
             

                if (String.IsNullOrEmpty(RechargeInfo.GSMNumber) || !RechargeInfo.GSMNumber.Length.Equals(11)) {
                    //kvp = new KeyValuePair<string, string>("02", "Please ensure you have provided a correct phone number. ");
                    newRecharge.statusCode = "0";
                    TempData["model"] = newRecharge;
                    TempData["ErrorMessage"] = "Please ensure you have provided a correct phone number.  ";
                    return RedirectToAction("Index");
                }

                if (String.IsNullOrEmpty(RechargeInfo.AccountNumber) || !RechargeInfo.AccountNumber.Length.Equals(10)) {
                    //kvp = new KeyValuePair<string, string>("03", "Please ensure you have provided a valid account number. ");
                    newRecharge.statusCode = "0";
                    TempData["model"] = newRecharge;
                    TempData["ErrorMessage"] = "Please ensure you have provided a valid account number.";
                    return RedirectToAction("Index");
                }

                //int result = Convert.ToInt32(PIN);
                if (String.IsNullOrEmpty(RechargeInfo.PinToken) ) {
                    //kvp = new KeyValuePair<string, string>("04", "Please provide your PIN+TOKEN. ");
                     newRecharge.statusCode = "0";
                    TempData["model"] = newRecharge;
                    TempData["ErrorMessage"] = "Please provide your PIN+TOKEN.";
                    return RedirectToAction("Index");
                }

            }
                //else
                //{
                    if (RechargeInfo.Type != "1")
                    {
                        newRecharge = new SocialActionClass().purchaseQuickAirtime(RechargeInfo);

                    }else{
                        newRecharge = new SocialActionClass().purchaseOtherAirtime(RechargeInfo);
                    }
                    if (newRecharge.statusCode == "00")
                    {
                       // newRecharge.statusCode = "1";
                        TempData["ErrorMessage"] = "Transaction Successful";
                        TempData["model"] = newRecharge;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        newRecharge.statusCode = "0";
                        TempData["model"] = newRecharge;
                        TempData["ErrorMessage"] = newRecharge.statusMessage;
                        return RedirectToAction("Index");
                    }

               
            }
            catch (Exception ex)
            {
                newRecharge.statusCode = "0";
                TempData["ErrorMessage"] = ex.Message;
            }


            return View();
        }
    }
}