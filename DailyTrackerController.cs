using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using RndApp.Models;
using System.Net.Http;
using System.Web.Security;
using System.Net;
using System.Data;
using System.IO;

namespace RndApp.Controllers
{
    public class DailyTrackerController : Controller
    {
        //
        // GET: /DailyTracker/
        [System.Web.Mvc.Authorize]
        public ActionResult Tracker()
        {
            return View();
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        public string DailyTrackerPost(DailyTrackerUpload objDailyTrackerUpload)
        {

            try
            {
                DailyTrackerUpload[] arrDailyTrackerUpload = { objDailyTrackerUpload };
                AcceesModel obj = new AcceesModel();
                DataTable tbCategories = validateTable(obj.ToDataTable<DailyTrackerUpload>(arrDailyTrackerUpload));

                DataSet ds = obj.getDataSet("CollectionManualmport", tbCategories, "0", Convert.ToString(Session["userID"]), false);

                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    return "Error!";
                else
                    return ds.Tables[0].Rows[0][0].ToString();

            }
            catch (Exception ex)
            {

                return "Error";
            }
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        public string DailyTrackerUpdatePost(DailyTrackerUpload objDailyTrackerUpload)
        {

            try
            {
                DailyTrackerUpload[] arrDailyTrackerUpload = { objDailyTrackerUpload };
                AcceesModel obj = new AcceesModel();
                DataTable tbCategories = validateTable(obj.ToDataTable<DailyTrackerUpload>(arrDailyTrackerUpload));
                DataSet ds = obj.getDataSet("CollectionManualUpdate", tbCategories, objDailyTrackerUpload.DailyTrackerId.ToString(), Convert.ToString(Session["userID"]), false);
                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                    return "Error!";
                else
                    return objDailyTrackerUpload.DailyTrackerId.ToString();

            }
            catch (Exception ex)
            {

                return "Error";
            }
        }

        public DataTable validateTable(DataTable tbCategories)
        {
            DataTable tbvalidateTable = new DataTable("dtDailyTracker");
            tbvalidateTable.Columns.Add("ApplicationID", typeof(long));
            tbvalidateTable.Columns.Add("Branch", typeof(String));
            tbvalidateTable.Columns.Add("MerchantName", typeof(String));
            tbvalidateTable.Columns.Add("Department", typeof(String));
            tbvalidateTable.Columns.Add("ActivityType", typeof(String));
            tbvalidateTable.Columns.Add("ActivitySource", typeof(String));
            tbvalidateTable.Columns.Add("SubSource", typeof(String));
            tbvalidateTable.Columns.Add("ActivityBy", typeof(String));
            tbvalidateTable.Columns.Add("ActivityDate", typeof(String));
            tbvalidateTable.Columns.Add("ActivityTime", typeof(String));
            tbvalidateTable.Columns.Add("TimeSpent", typeof(String));
            tbvalidateTable.Columns.Add("FeedbackCode", typeof(String));
            tbvalidateTable.Columns.Add("SubFeedbackCode", typeof(String));
            tbvalidateTable.Columns.Add("Proofs", typeof(String));
            tbvalidateTable.Columns.Add("ForwardedTo", typeof(String));
            tbvalidateTable.Columns.Add("ForwardedDate", typeof(String));
            tbvalidateTable.Columns.Add("NextActionDate", typeof(String));
            tbvalidateTable.Columns.Add("NextActionBy", typeof(String));
            tbvalidateTable.Columns.Add("PartnerBank", typeof(String));
            tbvalidateTable.Columns.Add("DateOfInstallation", typeof(String));
            tbvalidateTable.Columns.Add("No_Of_EDC", typeof(String));
            tbvalidateTable.Columns.Add("Type_Of_EDC", typeof(String));
            tbvalidateTable.Columns.Add("MID", typeof(String));
            tbvalidateTable.Columns.Add("TID", typeof(String));
            tbvalidateTable.Columns.Add("Remarks", typeof(String));
            tbvalidateTable.Columns.Add("AddedBy", typeof(String));


            DataRow toInsert = tbvalidateTable.NewRow();
            foreach (DataRow dtRow in tbCategories.Rows)
            {
                if (dtRow["ApplicationID"].ToString() != "0")
                    toInsert["ApplicationID"] = dtRow["ApplicationID"].ToString();

                if (dtRow["Branch"].ToString() != "0")
                    toInsert["Branch"] = dtRow["Branch"].ToString();
                else
                    toInsert["Branch"] = "";

                if (!string.IsNullOrEmpty(dtRow["MerchantName"].ToString()))
                    toInsert["MerchantName"] = dtRow["MerchantName"].ToString();
                else
                    toInsert["MerchantName"] = "";

                if (dtRow["Department"].ToString() != "0")
                    toInsert["Department"] = dtRow["Department"].ToString();
                else
                    toInsert["Department"] = "";

                if (dtRow["ActivityType"].ToString() != "0")
                    toInsert["ActivityType"] = dtRow["ActivityType"].ToString();
                else
                    toInsert["ActivityType"] = "";

                if (dtRow["ActivitySource"].ToString() != "0")
                    toInsert["ActivitySource"] = dtRow["ActivitySource"].ToString();
                else
                    toInsert["ActivitySource"] = "";

                if (dtRow["SubSource"].ToString() != "0")
                    toInsert["SubSource"] = dtRow["SubSource"].ToString();
                else
                    toInsert["SubSource"] = "";

                if (!string.IsNullOrEmpty(dtRow["ActivityBy"].ToString()))
                    toInsert["ActivityBy"] = dtRow["ActivityBy"].ToString();
                else
                    toInsert["ActivityBy"] = "";

                if (dtRow["ActivityDate"].ToString() != "0")
                    toInsert["ActivityDate"] = dtRow["ActivityDate"].ToString();
                else
                    toInsert["ActivityDate"] = "";

                if (dtRow["ActivityTime"].ToString() != "0")
                    toInsert["ActivityTime"] = dtRow["ActivityTime"].ToString();
                else
                    toInsert["ActivityTime"] = "";

                if (!string.IsNullOrEmpty(dtRow["TimeSpent"].ToString()))
                    toInsert["TimeSpent"] = dtRow["TimeSpent"].ToString();
                else
                    toInsert["TimeSpent"] = "";

                if (!string.IsNullOrEmpty(dtRow["Proofs"].ToString()))
                    toInsert["Proofs"] = dtRow["Proofs"].ToString();
                else
                    toInsert["Proofs"] = "";

                if (dtRow["FeedbackCode"].ToString() != "0")
                    toInsert["FeedbackCode"] = dtRow["FeedbackCode"].ToString();
                else
                    toInsert["FeedbackCode"] = "";

                if (dtRow["SubFeedbackCode"].ToString() != "0")
                    toInsert["SubFeedbackCode"] = dtRow["SubFeedbackCode"].ToString();
                else
                    toInsert["SubFeedbackCode"] = "";

                if (dtRow["ForwardedTo"].ToString() != "0")
                    toInsert["ForwardedTo"] = dtRow["ForwardedTo"].ToString();
                else
                    toInsert["ForwardedTo"] = "";

                if (dtRow["ForwardedDate"].ToString() != "0")
                    toInsert["ForwardedDate"] = dtRow["ForwardedDate"].ToString();
                else
                    toInsert["ForwardedDate"] = "";

                if (dtRow["NextActionDate"].ToString() != "0")
                    toInsert["NextActionDate"] = dtRow["NextActionDate"].ToString();
                else
                    toInsert["NextActionDate"] = "";

                if (dtRow["NextActionBy"].ToString() != "0")
                    toInsert["NextActionBy"] = dtRow["NextActionBy"].ToString();
                else
                    toInsert["NextActionBy"] = "";


                if (dtRow["PartnerBank"].ToString() != "0")
                    toInsert["PartnerBank"] = dtRow["PartnerBank"].ToString();
                else
                    toInsert["PartnerBank"] = "";


                if (dtRow["DateOfInstallation"].ToString() != "0")
                    toInsert["DateOfInstallation"] = dtRow["DateOfInstallation"].ToString();
                else
                    toInsert["DateOfInstallation"] = "";

                if (dtRow["No_Of_EDC"].ToString() != "0")
                    toInsert["No_Of_EDC"] = dtRow["No_Of_EDC"].ToString();
                else
                    toInsert["No_Of_EDC"] = "";

                if (dtRow["Type_Of_EDC"].ToString() != "0")
                    toInsert["Type_Of_EDC"] = dtRow["Type_Of_EDC"].ToString();
                else
                    toInsert["Type_Of_EDC"] = "";

                if (dtRow["MID"].ToString() != "0")
                    toInsert["MID"] = dtRow["MID"].ToString();
                else
                    toInsert["MID"] = "";

                if (dtRow["TID"].ToString() != "0")
                    toInsert["TID"] = dtRow["Department"].ToString();
                else
                    toInsert["TID"] = "";

                if (!string.IsNullOrEmpty(dtRow["Remarks"].ToString()))
                    toInsert["Remarks"] = dtRow["Remarks"].ToString();
                else
                    toInsert["Remarks"] = "";


                toInsert["AddedBy"] = Convert.ToString(Session["userID"]);
                tbvalidateTable.Rows.Add(toInsert);
                tbvalidateTable.AcceptChanges();
            }
            return tbvalidateTable;
        }

        [System.Web.Http.Authorize]
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
                string result = obj.GetResult("setDailyUpload '" + data + "','" + path + "','" + Convert.ToString(Session["userID"]) + "'");

                return Content(result);
            }
            catch (Exception ex)
            {
                return Content("Error : " + ex.Message);
            }
        }

    }
}
namespace RndApp.Controllers.api
{
    public class DailyTrackerController : ApiController
    {
        //[System.Web.Http.Authorize]
        //[System.Web.Http.HttpGet]
        //public string GetSubCodes(string SelectType, int id)
        //{
        //    AcceesModel obj = new AcceesModel();
        //    return obj.GetResult("GetSubCodeCollection  '" + SelectType + "'," + id);
        //}

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetSubCodes(int unique, String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetSubCodeCollection  '" + userid + "'," + unique);
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetApplicationList(string userid)
        {
            AcceesModel obj = new AcceesModel();
            long chkNumber = 0;
            bool canConvert = long.TryParse(userid, out chkNumber);
            if (canConvert)
                return obj.GetResult("GetApplcaitionOrMerchant  '" + userid + "','" + "NUMBER" + "'");
            else
                return obj.GetResult("GetApplcaitionOrMerchant  '" + userid + "','" + "VAR" + "'");
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetDailyTrackerList(string userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetDailyTrackerList '" + userid + "'");
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string GetDailyUploadById(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("GetDailyUploadById '" + userid + "'");
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        public string RemoveDailyDocs(String userid)
        {
            AcceesModel obj = new AcceesModel();
            return obj.GetResult("RemoveDailyDocs '" + userid + "'");
        }
    }
}
