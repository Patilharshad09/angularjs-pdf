using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using RndApp.Models;
using System.Web.Security;
using System.Net.Http;
using System.Data;
using System.Net;
using System.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace RndApp.Controllers
{
    public class TeleSalesController : Controller
    {
        public ActionResult TeleSales()
        {
            return View();
        }
    }
}
namespace RndApp.Controllers.api
{
    public class TeleSalesController : ApiController
    {

        [System.Web.Http.HttpPost]
        public HttpResponseMessage Post(TeleSales value)
        {
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string sErrorTime = sYear + sMonth + sDay;
            //string strUserAgent = HttpContext.Current.Request.UserAgent.ToString().ToLower();
            //bool result = HttpContext.Current.Request.Browser.IsMobileDevice;
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/TeleSalesEvent_" + sErrorTime + ".log");
            LogEvents log = new LogEvents();
            //log.Logevent(headers, filePath);
            try
            {
                TeleSales objTele = new TeleSales();
                string result = objTele.ValidateData(value);
                if (result == "")
                {
                    if (Membership.ValidateUser(value.UserName, value.Password))
                    {

                        AcceesModel obj = new AcceesModel();
                        ;
                        obj.GetResult("SetTeleSalesStagingData " +
                                value.TeleSalesId + ",'" + value.MerchantName + "','" + value.FNAME + "','" + value.MNAME + "','" + value.LNAME + "','" + value.PhoneNo + "','" + value.CampaignCode + "','" + value.LeadPhoneNo + "','" + value.MissedCall + "','" +
                                value.DateandTime.ToString("MM-dd-yyyy hh:mm:ss") + "','" + value.Circle + "','" + value.Operator + "','" + value.YourName + "','" + value.Email + "','" + value.City + "'," + value.NoofYearinBusiness + ",'" + value.LoanAmount + "','" + value.Avgsalespermonth +
                               "','" + value.Source + "','" + value.DOB + "','" + value.ADDRESSOfResidence + "','" + value.ADDRESSOfShop + "','" + value.AddressPinCode + "','" + value.ShopPinCode + "','" + value.Industry + "'"
                           );
                        log.Logevent(value, filePath);
                        return Request.CreateResponse(HttpStatusCode.OK, "Data Saved Successfully");
                    }
                    else
                    {
                        log.Logevent("Authentication Failed", filePath);
                        return Request.CreateResponse(HttpStatusCode.BadRequest, "Authentication Failed");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.ExpectationFailed, result);
                }
            }
            catch (Exception ex)
            {
                log.Logevent(ex.Message, filePath);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }


        [System.Web.Http.HttpGet]
        public string TrackMissedCall(string clid, string calltime, string called)
        {
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            string sErrorTime = sYear + sMonth + sDay;
            string filePath = HttpContext.Current.Server.MapPath("~/App_Data/TrackMissedCall_" + sErrorTime + ".log");
            LogEvents log = new LogEvents();
            string TataBSSResponse = "";
            try
            {
                MissedCall objMissedCall = new MissedCall();
                objMissedCall.CallTo = called;
                objMissedCall.CallFrom = clid;
                objMissedCall.Provider = "NA";
                objMissedCall.Location = "NA";
                objMissedCall.Source = "MissedCall";
                TataBSSResponse=PostToTata(objMissedCall);
                log.Logevent("clid = " + clid + " calltime = " + calltime + " called= " + called+" TataBSSResponse = "+TataBSSResponse, filePath);
                return "success";
            }
            catch (Exception ex)
            {
                log.Logevent(ex.Message, filePath);
                return "fail";
            }
        }


        public string PostToTata(MissedCall objMissedCall)
        {
            try
            {
                // URL format for tata bss service 
                //URL :  http://14.141.40.188/NeoGrowthService/NGrowthService.svc/ImportDataFromDigitalImportDataFromDigital /
                //       {sCallFrom}/{sCallTo}/{sProvider}/{sLocation}/{sSource}

                var baseAddress = ConfigurationManager.AppSettings["MissedURL"];
                baseAddress = baseAddress + "/" + objMissedCall.CallFrom + "/" + objMissedCall.CallTo + "/" + objMissedCall.Provider + "/" + objMissedCall.Location + "/" + objMissedCall.Source;
                var http = (HttpWebRequest)WebRequest.Create(new Uri(baseAddress));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "GET";
                var response = http.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
                dynamic dynObj = JsonConvert.DeserializeObject(content);
                if (!string.IsNullOrEmpty(dynObj.ImportDataFromMissedCallResult._sStatus.Value))
                    return dynObj.ImportDataFromMissedCallResult._sStatus.Value;
                else
                    return "FAILURE";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

    }
}
