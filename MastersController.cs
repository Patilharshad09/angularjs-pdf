using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RndApp.Models;

namespace RndApp.Controllers
{
    public class MastersController : ApiController
    {

       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string Getindustrymultiplier()
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("Getindustrymultiplier");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetBusinessYearMulitiplier()
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetBusinessYearMulitiplier");
        }
        [System.Web.Http.HttpPost]
        public string postData(List<string> val)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetApplicationScore " + val[0] + "," + val[1] + "," + val[2] + ",'" + val[3] + "','" + val[4] + "'");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetIndustries(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GETINDUSTRIES '" + userid + "'");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetTitles(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetTitles '" + userid + "'");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetLeadsource(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GETLEADSOURCE '" + userid + "'");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetProductfamily(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GETPRODUCTFAMILY '" + userid + "'");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetProducts(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GETPRODUCTS '" + userid + "'");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetBranches(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GETBRANCHES '" + userid + "'");
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetPincodeData(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetPincodeData " + userid);
        }
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetPurposeofLoan(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("getLoanPurpose '" + userid + "'");
        }
        //[System.Web.Http.HttpGet]
        //public string GetPurposeofLoan(string userid)
        //{
        //    AcceesModel obj = new AcceesModel();
        //    return obj.GetResult("getLoanPurpose '" + userid + "'");
        //}
       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetRefenceNumber()
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GETSEQUENCE");
        }

       [System.Web.Http.Authorize]  [System.Web.Http.HttpGet]
        public string GetMasters(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetMasters");
        }

       [System.Web.Http.Authorize]
       [System.Web.Http.HttpGet]
       public string GetDailyMasters()
       {
           AcceesModel obj = new AcceesModel();
           return obj.GetResult("GetDailyMasters");
       }

    }
}
