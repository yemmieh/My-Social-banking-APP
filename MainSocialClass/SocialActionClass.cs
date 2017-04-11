using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainSocialClass;

namespace MainSocialClass
{
    public class SocialActionClass
    {
        public AccountBalance getAccountBalance(AccountBalance accontinfo)
        {

            AccountBalance newbalance = new AccountBalance();
            try
            {
            ZenithCore.QuickAccountBalance zenQuickBalance = new ZenithCore.QuickAccountBalance();

            ZenithCore.ZenithRequestClient zenClient = new ZenithCore.ZenithRequestClient();

            zenQuickBalance.ClientAuth = new ZenithCore.Client();

            zenQuickBalance.ClientAuth.CallerID = ConfigurationManager.AppSettings["CallerID"].ToString();

            zenQuickBalance.ClientAuth.CallerReference = Guid.NewGuid().ToString();

            zenQuickBalance.ClientAuth.ClientName = ConfigurationManager.AppSettings["ClientName"].ToString();

            zenQuickBalance.ClientAuth.Password = ConfigurationManager.AppSettings["ClientPassword"].ToString();

            zenQuickBalance.AccountNumber = accontinfo.AccountNumber;

            zenQuickBalance.MobileNumber = accontinfo.MobileNumber;

            ZenithCore.Response resp = null;


           
                resp = zenClient.SendAccountBalance(zenQuickBalance);

                newbalance.statusCode = resp.ResponseCode;
                newbalance.statusMessage = resp.Description;
                //newbalance.AccountNumber = accontinfo.AccountNumber;
                //newbalance.MobileNumber = accontinfo.MobileNumber;
                LogWriter.WriteErrorLog("Account Balance : Account Number : " + accontinfo.AccountNumber);
                LogWriter.WriteErrorLog("Account Balance : Mobile Number : " + accontinfo.MobileNumber);
                LogWriter.WriteErrorLog("Account Balance : Status : " + resp.Description);
                LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
     
            }
            catch (Exception ex)
            {
                newbalance.statusCode = "100";
                newbalance.statusMessage = ex.Message;
                LogWriter.WriteErrorLog("Account Balance : Errooooooooooooooooor");
                LogWriter.WriteErrorLog("Account Balance : Account Number : " + accontinfo.AccountNumber);
                LogWriter.WriteErrorLog("Account Balance : Mobile Number : " + accontinfo.MobileNumber);
                LogWriter.WriteErrorLog("Account Balance  : Status : " + ex.Message);
                LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
            }
           

            return newbalance;
        }


        public Recharge purchaseQuickAirtime(Recharge recharge)
        {
           
                Recharge newRecharge = new Recharge();
                try
                {
                ZenithCore.QuickAirtimePurchase zenAirtimePurchase
                                                                = new ZenithCore.QuickAirtimePurchase();
                ZenithCore.ZenithRequestClient zenClient = new ZenithCore.ZenithRequestClient();

                zenAirtimePurchase.ClientAuth = new ZenithCore.Client();

                zenAirtimePurchase.ClientAuth.CallerID = ConfigurationManager.AppSettings["CallerID"].ToString();
                zenAirtimePurchase.ClientAuth.CallerReference = Guid.NewGuid().ToString();
                zenAirtimePurchase.ClientAuth.ClientName = ConfigurationManager.AppSettings["ClientName"].ToString();
                zenAirtimePurchase.ClientAuth.Password = ConfigurationManager.AppSettings["ClientPassword"].ToString();

                zenAirtimePurchase.MobileNumber = recharge.GSMNumber;
                zenAirtimePurchase.Amount = recharge.RechargeAmount;
                zenAirtimePurchase.MobileOperator = recharge.Operator;

                ZenithCore.Response resp = zenClient.BuyQuickAirtime(zenAirtimePurchase);


                newRecharge.statusCode = resp.ResponseCode;
                newRecharge.statusMessage = resp.Description;
                LogWriter.WriteErrorLog("Purchase Quick Airtime : GSM Number : " + recharge.GSMNumber);
                LogWriter.WriteErrorLog("Purchase Quick Airtime : Recharge Ammount : " + recharge.RechargeAmount);
                LogWriter.WriteErrorLog("Purchase Quick Airtime : Status : " + resp.Description);
                LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
     

            }
            catch (Exception ex)
            {
                newRecharge.statusCode = "100";
                newRecharge.statusMessage = ex.Message;
                LogWriter.WriteErrorLog("Purchase Quick Airtime : Errooooooooooooooooor");
                LogWriter.WriteErrorLog("Purchase Quick Airtime : GSM Number : " + recharge.GSMNumber);
                LogWriter.WriteErrorLog("Purchase Quick Airtime : Recharge Ammount : " + recharge.RechargeAmount);
                LogWriter.WriteErrorLog("Purchase Quick Airtime  : Status : " + ex.Message);
                LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
            }
            return newRecharge;
        }

        public Recharge purchaseOtherAirtime(Recharge recharge)
        {
            Recharge newRecharge = new Recharge();

            try
            {
                ZenithCore.AirtimePurchase zenAirtimePurchase
                                                                = new ZenithCore.AirtimePurchase();
                ZenithCore.ZenithRequestClient zenClient = new ZenithCore.ZenithRequestClient();

                zenAirtimePurchase.ClientAuth = new ZenithCore.Client();

                zenAirtimePurchase.ClientAuth.CallerID = ConfigurationManager.AppSettings["CallerID"].ToString();
                zenAirtimePurchase.ClientAuth.CallerReference = Guid.NewGuid().ToString();
                zenAirtimePurchase.ClientAuth.ClientName = ConfigurationManager.AppSettings["ClientName"].ToString();
                zenAirtimePurchase.ClientAuth.Password = ConfigurationManager.AppSettings["ClientPassword"].ToString();

                zenAirtimePurchase.AccountNumber = recharge.AccountNumber;

                zenAirtimePurchase.CustomerAuth = new ZenithCore.CustomerAuth();
                zenAirtimePurchase.CustomerAuth.AuthenticationMode = 1;
                zenAirtimePurchase.CustomerAuth.AccountNumber = recharge.AccountNumber;
                zenAirtimePurchase.CustomerAuth.PassCode = recharge.PinToken;

                zenAirtimePurchase.Amount = recharge.RechargeAmount;
                zenAirtimePurchase.CustomerRef = recharge.GSMNumber;
                zenAirtimePurchase.MobileOperator = recharge.Operator;

                ZenithCore.Response resp = zenClient.AirtimePurchase(zenAirtimePurchase);

                newRecharge.statusCode = resp.ResponseCode;
                newRecharge.statusMessage = resp.Description;

                LogWriter.WriteErrorLog("Purchase Other Airtime : Account Number : " + recharge.AccountNumber);
                LogWriter.WriteErrorLog("Purchase Other Airtime : GSM Number : " + recharge.GSMNumber);
                LogWriter.WriteErrorLog("Purchase Other Airtime : Recharge Ammount : " + recharge.RechargeAmount);
                LogWriter.WriteErrorLog("Purchase Other Airtime : Status : " + resp.Description);
                LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
     
            }
            catch (Exception ex)
            {
                newRecharge.statusCode = "100";
                newRecharge.statusMessage = ex.Message;
                LogWriter.WriteErrorLog("Purchase Other Airtime : Errooooooooooooooooor");
                LogWriter.WriteErrorLog("Purchase Other Airtime : Account Number : " + recharge.AccountNumber);
                LogWriter.WriteErrorLog("Purchase Other Airtime : GSM Number : " + recharge.GSMNumber);
                LogWriter.WriteErrorLog("Purchase Other Airtime : Recharge Ammount : " + recharge.RechargeAmount);
                LogWriter.WriteErrorLog("Purchase Other Airtime  : Status : " + ex.Message);
                LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
            }
            return newRecharge;
        }



        public Statement getAccountStatement(Statement statement)
        {
            Statement newStatement = new Statement();
            try
            {
                using (ZenithCore.ZenithRequestClient zenClient = new ZenithCore.ZenithRequestClient())
                {
                    ZenithCore.StatementByMailReq zenGetStatementReq
                                                            = new ZenithCore.StatementByMailReq();

                    zenGetStatementReq.ClientAuth = new ZenithCore.Client();
                    zenGetStatementReq.ClientAuth.CallerID = ConfigurationManager.AppSettings["CallerID"].ToString();
                    zenGetStatementReq.ClientAuth.CallerReference = Guid.NewGuid().ToString();
                    zenGetStatementReq.ClientAuth.ClientName = ConfigurationManager.AppSettings["ClientName"].ToString();
                    zenGetStatementReq.ClientAuth.Password = ConfigurationManager.AppSettings["ClientPassword"].ToString();


                    zenGetStatementReq.CustomerAuth = new ZenithCore.CustomerAuth();

                    zenGetStatementReq.CustomerAuth.AuthenticationMode = 1;
                    zenGetStatementReq.CustomerAuth.AccountNumber = statement.AccountNumber;
                    zenGetStatementReq.CustomerAuth.PassCode = statement.PinToken;

                    zenGetStatementReq.AccountNumber = statement.AccountNumber;
                    zenGetStatementReq.Email = statement.Email;
                    zenGetStatementReq.BeginDate = statement.BeginDate;
                    zenGetStatementReq.EndDate = statement.EndDate;

                    ZenithCore.Response resp = zenClient.SendStatementByEmail(zenGetStatementReq);

                   
                    newStatement.statusCode = resp.ResponseCode;
                    newStatement.statusMessage = resp.Description;
                    LogWriter.WriteErrorLog("Account Statement : Account Number : " + statement.AccountNumber);
                    LogWriter.WriteErrorLog("Account Statement  : Email : " + statement.Email);
                    LogWriter.WriteErrorLog("Account Statement  : BeginDate : " + statement.BeginDate);
                    LogWriter.WriteErrorLog("Account Statement  : EndDate : " + statement.EndDate);
                    LogWriter.WriteErrorLog("Account Statement  : Status : " + resp.Description);
                    LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
     
                }

            }
            catch (Exception ex)
            {
                newStatement.statusCode = "100";
                newStatement.statusMessage = ex.Message;
                LogWriter.WriteErrorLog("Account Statement : Error");      
                LogWriter.WriteErrorLog("Account Statement : Account Number : " + statement.AccountNumber);               
                LogWriter.WriteErrorLog("Account Statement  : Status : " + ex.Message);
                LogWriter.WriteErrorLog("--------------------------------------------------------------------------------------------------");
            }
                return newStatement;
         
        }

    }
}
