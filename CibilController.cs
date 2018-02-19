using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using RndApp.Models;
using System.IO;
using RndApp.Filters;
using System.Collections.Specialized;
using System.Text;
using System.Configuration;
using System.Net;
using Newtonsoft.Json.Linq;

//Order of execution
//IAuthorizationFilter.OnAuthorization
//IActionFilter.OnActionExecuting
//IActionFilter.OnActionExecuted
//IResultFilter.OnResultExecuting
//IResultFilter.OnResultExecuted

public class CibilAuthorizationAttribute : FilterAttribute, IAuthorizationFilter
{
    void IAuthorizationFilter.OnAuthorization(AuthorizationContext filterContext)
    {
        filterContext.Controller.ViewBag.OnAuthorization = "IAuthorizationFilter.OnAuthorization filter called";
        NameValueCollection headers = HttpContext.Current.Request.Headers;
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;
        //string strUserAgent = HttpContext.Current.Request.UserAgent.ToString().ToLower();
        //bool result = HttpContext.Current.Request.Browser.IsMobileDevice;
        string filePath = filterContext.HttpContext.Server.MapPath("~/App_Data/Event_" + sErrorTime + ".log");
        LogEvents log = new LogEvents();
        log.Logevent(headers, filePath);
    }
}

public class CibilActionAttribute : FilterAttribute, IActionFilter
{
    void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
    {
        filterContext.Controller.ViewBag.OnActionExecuted = "IActionFilter.OnActionExecuted filter called";
        NameValueCollection headers = HttpContext.Current.Request.Headers;
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;
        string filePath = filterContext.HttpContext.Server.MapPath("~/App_Data/Event_" + sErrorTime + ".log");
        LogEvents log = new LogEvents();
        log.Logevent(headers, filePath);
    }

    void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.Controller.ViewBag.OnActionExecuting = "IActionFilter.OnActionExecuting filter called";
        NameValueCollection headers = HttpContext.Current.Request.Headers;
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;
        string filePath = filterContext.HttpContext.Server.MapPath("~/App_Data/Event_" + sErrorTime + ".log");
        LogEvents log = new LogEvents();
        log.Logevent(headers, filePath);
    }
}

public class CibilExceptionAttribute : FilterAttribute, IExceptionFilter
{
    void IExceptionFilter.OnException(ExceptionContext filterContext)
    {
        filterContext.Controller.ViewBag.OnException = "IExceptionFilter.OnException filter called";
        NameValueCollection headers = HttpContext.Current.Request.Headers;
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;
        string filePath = filterContext.HttpContext.Server.MapPath("~/App_Data/Event_" + sErrorTime + ".log");
        LogEvents log = new LogEvents();
        log.Logevent(headers, filePath);
    }
}

public class CibilResultAttribute : FilterAttribute, IResultFilter
{
    void IResultFilter.OnResultExecuted(ResultExecutedContext filterContext)
    {
        filterContext.Controller.ViewBag.OnResultExecuted = "IResultFilter.OnResultExecuted filter called";
        NameValueCollection headers = HttpContext.Current.Request.Headers;
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;
        string filePath = filterContext.HttpContext.Server.MapPath("~/App_Data/Event_" + sErrorTime + ".log");
        LogEvents log = new LogEvents();
        log.Logevent(headers, filePath);
    }

    void IResultFilter.OnResultExecuting(ResultExecutingContext filterContext)
    {
        filterContext.Controller.ViewBag.OnResultExecuting = "IResultFilter.OnResultExecuting filter called";
        NameValueCollection headers = HttpContext.Current.Request.Headers;
        string sYear = DateTime.Now.Year.ToString();
        string sMonth = DateTime.Now.Month.ToString();
        string sDay = DateTime.Now.Day.ToString();
        string sErrorTime = sYear + sMonth + sDay;
        string filePath = filterContext.HttpContext.Server.MapPath("~/App_Data/Event_" + sErrorTime + ".log");
        LogEvents log = new LogEvents();
        log.Logevent(headers, filePath);
    }
}

namespace RndApp.Controllers
{
    public class CibilController : Controller
    {
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult Verification()
        {
            return View();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult SalesCibil()
        {
            return View();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult SalesHistory()
        {
            return PartialView();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult Welcome()
        {
            return View();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult DashBoard()
        {
            return View();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult CreditCibil()
        {
            return View();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult TeleSales()
        {
            return View();
        }

        [System.Web.Http.HttpPost]
        public string TeleSalesPost(TelesalesPost val)
        {
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string sErrorTime = sYear + sMonth + sDay;
            string filePath = HttpContext.Server.MapPath("~/App_Data/Event_" + sErrorTime + ".log");
            LogEvents objLog = new LogEvents();
            try
            {
                objLog.Logevent("Started Post",filePath);
                AcceesModel obj = new AcceesModel();
                obj.GetResult("SetTeleSalesData " +
                        +val._TelesalesId + ","
                        + val._UniqueId + ","
                        + val._Industry + ","
                        + val._ProductFamily + ","
                        + val._ProductCode + ","
                        + "'" + val._PurposeOfLoan + "',"
                        + val._LeadSource + ","
                        + val._Branch + ","
                        + val._LOAN_AMOUNT + ","
                        + "'" + val._MerchantName + "',"
                        + "'" + val._Title + "',"
                        + "'" + val._FNAME + "',"
                        + "'" + val._MNAME + "',"
                        + "'" + val._LNAME + "',"
                        + "'" + val._DOB + "',"
                        + "'" + val._SEX + "',"
                        + "'" + val._ADDRESS1 + "',"
                        + val._Country + ","
                        + "'" + val._STATE + "',"
                        + val._City + ","
                        + "'" + val._ZIPCODE + "',"
                        + "'" + val._PAN_NO + "',"
                        + "'" + val._PHONENO + "',"
                        + "'" + val._AddedBy + "',"
                        + "'" + val._EmailId + "',"
                        + val._BusinessPremises + ","
                        + val._BusinessStability + ","
                        + val._ResidencePremises + ","
                        + "'" + val._Acquirerbank + "',"
                        + val._Anyexistingbusinessloanongoing + ","
                        + val._cardsales + ","
                        + val._EMI + ","
                        + val._Noofbranches + ","
                        + val._Noofcurrentaccounts + ","
                        + val._Noofemployees + ","
                        + val._Noofsalestransactionspermonth + ","
                        + val._Noofterminals + ","
                        + "'" + val._Relationshipwithentity + "',"
                        + val._Totalamountoftransactionspermonth + ","
                        + "''"
                    );
                 objLog.Logevent("Post Complete", filePath);
                 return "Complete";
            }
            catch (Exception ex)
            {
                objLog.Logevent("Error Occured on TeleSalesPost at " + DateTime.Now.ToString() + " : " + ex.Message, filePath);
                return "Error";
            }
        }

        [System.Web.Http.HttpPost]
        public string SendMessage(SMSCommunication val)
        {
            SMSCommunication objSms = new SMSCommunication();
            if (val.Template.Contains(","))
            {
                objSms.SendSMS(val, val.Template);
            }
            else
            {
                objSms.SendSMS(val);
            }
            return "";
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult FOS()
        {
            return View();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Mvc.Authorize]
        public ActionResult ConvertToLead()
        {
            return View();
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public ActionResult FinalizeDeal(int DealId, string UserId, int UniqueId, string Remarks)
        {
            AcceesModel obj = new AcceesModel();
            obj.GetResult("FinalizeDeal " + DealId + "," + UniqueId + ",'" + Remarks + "','" + UserId + "'");
            return Content("");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public ActionResult ReferCase(int UniqueId, string UserId, string Remarks)
        {
            AcceesModel obj = new AcceesModel();
            obj.GetResult("ReferCase " + UniqueId + ",'" + UserId + "','" + Remarks + "'");
            return Content("");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, string data, String docType)
        {
            try
            {

                string fileName = Path.GetFileName(file.FileName);
                string folderpath = Server.MapPath("~/Images") + "/" + data + "/" + docType;
                string path = Path.Combine(folderpath, fileName);
                bool folderExists = Directory.Exists(folderpath);
                if (!folderExists)
                    Directory.CreateDirectory(folderpath);

                if (Directory.GetFiles(folderpath).Length > 0)
                {
                    DirectoryInfo directory = new DirectoryInfo(folderpath);
                    foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                }


                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                file.SaveAs(path);

                ModelState.Clear();
                AcceesModel obj = new AcceesModel();
                string result = obj.GetResult("setCibilUpload '" + data + "','" + docType + "','" + path + "'");

                return Content(result);
            }
            catch (Exception ex)
            {
                return Content("Error : " + ex.Message);
            }
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public ActionResult TeleSalesUpload(HttpPostedFileBase file, string data, String docType, string UserId)
        {
            try
            {

                string fileName = Path.GetFileName(file.FileName);
                string folderpath = Server.MapPath("~/Images") + "/" + data + "/" + docType;
                string path = Path.Combine(folderpath, fileName);
                bool folderExists = Directory.Exists(folderpath);
                if (!folderExists)
                    Directory.CreateDirectory(folderpath);

                if (Directory.GetFiles(folderpath).Length > 0)
                {
                    DirectoryInfo directory = new DirectoryInfo(folderpath);
                    foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
                }


                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
                file.SaveAs(path);

                ModelState.Clear();
                AcceesModel obj = new AcceesModel();
                string result = obj.GetResult("setTeleSalesUpload '" + data + "','" + docType + "','" + path + "','" + UserId + "'");

                return Content(result);
            }
            catch (Exception ex)
            {
                return Content("Error : " + ex.Message);
            }
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public ActionResult postRemarks(List<string> val)
        {
            AcceesModel obj = new AcceesModel();
            obj.GetResult("setCibilRemarks  '" + val[2] + "','A','" + val[1] + "','" + val[0] + "'");
            return Content("");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public string post(List<String> val)
        {
            AcceesModel obj = new AcceesModel();
            obj.GetResult("Tab_SAVESALESCIBILPROSPECTS " +
                    "'" + val[0] + "'," + "'" + val[1] + "'," + "'" + val[2] + "'," + "'" + val[3] + "'," +
                    "'" + val[4] + "'," + "'" + val[5] + "'," + "'" + val[6] + "'," + "'" + val[7] + "'," +
                    "'" + val[8] + "'," + "'" + val[9] + "'," + "'" + val[10] + "'," + "'" + val[11] + "'," +
                    "'" + val[12] + "'," + "'" + val[13] + "'," + "'" + val[14] + "'," + "'" + val[15] + "'," +
                    "'" + val[16] + "'," + "'" + val[17] + "'," + "'" + val[18] + "'," + "'" + val[19] + "'," +
                    "'" + val[20] + "'," + "'" + val[21] + "'," + "'" + val[22] + "'," + "'" + val[23] + "'," +
                    "'" + val[24] + "'," + "'" + val[25] + "'," + "'" + val[26] + "'," + "'" + val[27] + "'," +
                    "'" + val[28] + "'," + "'" + val[29] + "'," + "'" + val[30] + "'," + "'" + val[31] + "'," +
                    "'" + val[32] + "'," + "'" + val[33] + "'," + "'" + val[34] + "'," + "'" + val[35] + "'," +
                    "'" + val[36] + "'," + val[46] + "," + val[47] + "," + val[48] + "," + val[49]
                );

            return "";

        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public string postcibil(PropCibil val)
        {
            PropCibil propCibil = new PropCibil();
            propCibil.UniqueId = val.UniqueId;
            propCibil.ProductName = val.ProductName;
            propCibil.LOAN_AMOUNT = Convert.ToDouble(val.LOAN_AMOUNT);
            propCibil.FNAME = val.FNAME;
            propCibil.MNAME = val.MNAME;
            propCibil.LNAME = val.LNAME;
            propCibil.DOB = val.DOB;
            propCibil.SEX = val.SEX;
            propCibil.ResidentialAddress = val.ResidentialAddress;
            propCibil.StateName = val.StateName;
            propCibil.Zipcode = val.Zipcode;
            propCibil.PAN_NO = val.PAN_NO;
            propCibil.Phoneno = val.Phoneno;
            PullCibil objCibil = new PullCibil();
            objCibil.pullCibil(propCibil);
            return "";

        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public string postAssessment(PropSelfAssessment val)
        {
            PropSelfAssessment propCibil = new PropSelfAssessment();
            propCibil.UniqueId = val.UniqueId;
            propCibil.Declaration = val.Declaration;
            propCibil.selectedStockSeen = val.selectedStockSeen;
            propCibil.StockSeenComment = val.StockSeenComment;
            propCibil.StockWorth = val.StockWorth;
            propCibil.Metperson = val.Metperson;
            propCibil.selectedRelationship = val.selectedRelationship;
            propCibil.RelationshipComment = val.RelationshipComment;
            propCibil.Stabilityofthepremises = val.Stabilityofthepremises;
            propCibil.Noofemployees = val.Noofemployees;
            propCibil.TotalTopermonth = val.TotalTopermonth;
            propCibil.Averageticketsizeofthesale = val.Averageticketsizeofthesale;
            propCibil.selectedWeeklyOff = val.selectedWeeklyOff;
            propCibil.yesday = val.yesday;
            propCibil.Numberofbranches = val.Numberofbranches;
            propCibil.OtherBusiness = val.OtherBusiness;
            propCibil.HighSeason = val.HighSeason;
            propCibil.LowSeason = val.LowSeason;
            propCibil.Currentaccounts = val.Currentaccounts;
            propCibil.BankName = val.BankName;
            propCibil.Numberofterminals = val.Numberofterminals;
            propCibil.AcquirerBank = val.AcquirerBank;
            propCibil.AddedBy = val.AddedBy;
            AcceesModel obj = new AcceesModel();
            obj.GetResult("SetSelfAssessment '"
                 + val.UniqueId + "','"
                 + val.Declaration + "','"
                 + val.selectedStockSeen + "','"
                 + val.StockSeenComment + "','"
                 + val.StockWorth + "','"
                 + val.Metperson + "','"
                 + val.selectedRelationship + "','"
                 + val.RelationshipComment + "','"
                 + val.Stabilityofthepremises + "','"
                 + val.Noofemployees + "','"
                 + val.TotalTopermonth + "','"
                 + val.Averageticketsizeofthesale + "','"
                 + val.selectedWeeklyOff + "','"
                 + val.yesday + "','"
                 + val.Numberofbranches + "','"
                 + val.OtherBusiness + "','"
                 + val.HighSeason + "','"
                 + val.LowSeason + "','"
                 + val.Currentaccounts + "','"
                 + val.BankName + "','"
                 + val.Numberofterminals + "','"
                 + val.AcquirerBank + "','"
                 + val.AddedBy + "'"
            );
            return "";

        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public string postcardsales(PropCardSales[] val)
        {
            AcceesModel obj = new AcceesModel();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = obj.ToDataTable<PropCardSales>(val);
            obj.GetResult("Tab_postCardSales " + val[0].UniqueId);
            obj.BulkUpload(dt, "Tab_CardSales");
            return "";
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpPost]
        public ActionResult postCreditDecision(int UniqueId, string Decision, string Reason, string UserId)
        {
            AcceesModel obj = new AcceesModel();
            obj.GetResult("SetCreditDecision  '" + UniqueId + "','" + Decision + "','" + Reason + "','" + UserId + "'");
            return Content("");
        }

        [System.Web.Http.HttpPost]
        public ActionResult postVerification(Verification[] val)
        {
            AcceesModel obj = new AcceesModel();
            //GetResult(string Qry,string paramName,string paramValue,string typeName)           
            obj.GetResult("usp_SendVerificationData", "@dataVerificationAddress", val, "dbo.VerificationAddress");
            return Content("");
        }
    }
}

namespace RndApp.Controllers.api
{
    public class CibilController : ApiController
    {
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        public string Get(String userid)
        {
            bool val = (System.Web.HttpContext.Current.User != null) && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
            if (val)
            {
                AcceesModel obj = new AcceesModel();
                return obj.GetResult("SearchCibil_ConvertToLead '','" + userid + "'");
            }
            else
            {
                return "";
            }
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string set(String unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("CONVERTTOLEAD '" + unique + "','" + userid + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string checkPAN(String unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("CheckDuplicateCibilPanData '" + unique + "','" + userid + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetData(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_DataSalesCibil '" + userid + "'");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetTeleSalesDataFos(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_TeleSalesDataFos '" + userid + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetSummary(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_GetSummary '" + userid + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetDashboard(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_Dashboard '" + userid + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetCreditDashboard(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_CreditDashboard '" + userid + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetuniqueData(String unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_DataSalesCibil  '" + userid + "','" + unique + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetClientData(String unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetClientData  '" + userid + "','" + unique + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string SendMail(String unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            System.Data.DataTable dt = obj.GetDataTable("GetCibilMailBody " + unique + ",'" + userid + "'");

            String MailFrom = System.Configuration.ConfigurationManager.AppSettings["MailFrom"];
            String mailServer = System.Configuration.ConfigurationManager.AppSettings["mailserver"];
            String usernm = System.Configuration.ConfigurationManager.AppSettings["UserName"];
            String Password = System.Configuration.ConfigurationManager.AppSettings["Password"];
            Int32 Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["Port"]);
            String strRecipients = dt.Rows[0]["Recipients"].ToString();
            String Body = dt.Rows[0]["Body"].ToString();
            String Subject = dt.Rows[0]["Subject"].ToString();
            SendMailModel objMail = new SendMailModel();
            objMail.SendCibilMail(MailFrom, "", "", strRecipients, Subject, Body, mailServer, Port, usernm, Password, true);
            return "";
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Authorize]
        public string GetReport(int userid)
        {
            PullCibil obj = new PullCibil();
            return obj.GetReport(userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetCibilRemarks(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetCibilRemarks " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetCibilUpload(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetCibilUpload " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetCibilScore(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("getCibilScore " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetCibilEnquiry(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("getCibilEnquiry " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetCibilAccount(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("getCibilAccount " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetRisk(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetRisk " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetDealTerms(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetDealTerms " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetDeals(int unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetDeals " + unique + ",'" + userid + "'");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetTeleSalesData(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetTelesalesData '" + userid + "'");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetReferanceNumber()
        {
            AcceesModel obj = new AcceesModel();
            return obj.getExcuteScalar("GETSEQUENCE");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetTeleSalesDeals(int unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.getExcuteScalar("GetdealsForTeleSales " + unique + ",'" + userid + "'");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetMasters(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetMasters " + userid);
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetDocFolder(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_getDocFolder '" + userid + "'");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string CalculateDealTerms(double CardSales, double BankVolume, double ROI, int Tenure, String Industry)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("CalculateDealTerms " + CardSales + "," + BankVolume + "," + ROI + "," + Tenure + ",'" + Industry + "'");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetCardSales(int unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetCardSales " + unique + ",'" + userid + "'");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string RemoveImage(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Tab_RemoveImage " + userid);
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetFastTrackStages()
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetFastTrackStages");
        }
        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetSelfAssessment(int userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetSelfAssessment " + userid);
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetVerification(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("usp_getversentlog '" + userid + "'");
        }

        [CibilAuthorization]
        [CibilAction]
        [CibilResultAttribute]
        [CibilExceptionAttribute]
        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string SaveFOSUpload(int unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("SaveFOSUpload " + unique + ",'" + userid + "'");
        }



    }
}
