using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.OracleClient;
using RndApp.Models;

namespace RndApp.Controllers
{
    public class ChatController : Controller
    {
        public ActionResult WebRTCDemo()
        {
            return View();
        }
      
        public ActionResult PDFUpload()
        {
            return View();
        }
        public ActionResult conference()
        {
            return View();
        }
        public ActionResult PopWindow()
        {
            return View();
        }
        public ActionResult ChatWindow()
        {
            return View();
        }
        public ActionResult FileUpload()
        {

            OracleConnection Ocon = new OracleConnection();
            OracleCommand Ocommand = new OracleCommand();
            DataTable dtACKID = new DataTable();
            OracleDataAdapter daACKID = null;
            Ocon.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["CibilConnectionString"];
            Ocon.Open();
            Ocommand.Connection = Ocon;
            int i = 0;
            do {
                dtACKID = new DataTable();

                Ocommand.CommandText = "SELECT ACK_ID,nvl(PROCESS_STATUS,'') PROCESS_STATUS from middleware_cibil_ip_new where SRNO=" + 11184;
                daACKID = new OracleDataAdapter(Ocommand);
                daACKID.Fill(dtACKID);
               
                i++;
            } while (i < 5);
            AcceesModel am = new AcceesModel();
            if (dtACKID != null)
            {
                #region Bulk Upload
                if (dtACKID.Rows.Count > 0 && dtACKID.Rows[0][1].ToString() == "RECEIVED PDF")
                {
                    Ocommand.CommandText = "SELECT *  FROM MIDDLEWARE_CIBIL_IP_NEW where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _Middle = new DataTable();
                    daACKID.Fill(_Middle);

                    Ocommand.CommandText = "SELECT *  from JSON_CIBIL_ACCOUNT where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _ACCOUNT = new DataTable();
                    daACKID.Fill(_ACCOUNT);

                    Ocommand.CommandText = "SELECT * from JSON_CIBIL_ADDRESSES where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _ADDRESSES = new DataTable();
                    daACKID.Fill(_ADDRESSES);

                    Ocommand.CommandText = "SELECT *  from JSON_CIBIL_DISPUTE_REMARKS where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _DISPUTE = new DataTable();
                    daACKID.Fill(_DISPUTE);

                    Ocommand.CommandText = "SELECT *  from JSON_CIBIL_EMPLOYEEMENT where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _EMPLOYEEMENT = new DataTable();
                    daACKID.Fill(_EMPLOYEEMENT);

                    Ocommand.CommandText = "SELECT *  from JSON_CIBIL_ENQUIRY where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _ENQUIRY = new DataTable();
                    daACKID.Fill(_ENQUIRY);

                    Ocommand.CommandText = "SELECT * from JSON_CIBIL_ID where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _ID = new DataTable();
                    daACKID.Fill(_ID);

                    Ocommand.CommandText = "SELECT *  from JSON_CIBIL_PHONE where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _PHONE = new DataTable();
                    daACKID.Fill(_PHONE);

                    Ocommand.CommandText = "SELECT * from JSON_CIBIL_SCORE where ACK_ID=" + dtACKID.Rows[0][0];
                    DataTable _SCORE = new DataTable();
                    daACKID.Fill(_SCORE);

                    am.BulkUpload(_Middle, "MIDDLEWARE_CIBIL_IP_NEW");
                    am.BulkUpload(_ACCOUNT, "JSON_CIBIL_ACCOUNT");
                    am.BulkUpload(_ADDRESSES, "JSON_CIBIL_ADDRESSES");
                    am.BulkUpload(_DISPUTE, "JSON_CIBIL_DISPUTE_REMARKS");
                    am.BulkUpload(_EMPLOYEEMENT, "JSON_CIBIL_EMPLOYEEMENT");
                    am.BulkUpload(_ENQUIRY, "JSON_CIBIL_ENQUIRY");
                    am.BulkUpload(_ID, "JSON_CIBIL_ID");
                    am.BulkUpload(_PHONE, "JSON_CIBIL_PHONE");
                    am.BulkUpload(_SCORE, "JSON_CIBIL_SCORE");
                    am.GetResult("updateCibilScore " + 11184);
                }
                #endregion
            }
            Ocon.Close();
            Ocon.Dispose();
            return View();
        }
        public ActionResult PopupWindow()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(HttpPostedFileBase file1)
        {

            return Content("");
        }
        public ActionResult UploadFile()
        {

            return View();
        }
        public ActionResult Compress()
        {

            return View();
        }
        public ActionResult SpeechToText()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 3; //3 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }

                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        //TO:DO
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        ViewBag.Message = "File uploaded successfully";
                    }
                }
            }
            return Content("");
        }
    }
}
