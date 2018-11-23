using FInspectAPI.Models;
using FInspectServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace FInspectAPI.Controllers
{
    public class FinalInspectionController : ApiController
    {
        private readonly FinalInspectionService _InspectionService = new FinalInspectionService();
        private readonly InspectorService _InspectorService = new InspectorService();
        private readonly FinalInspectionuploadService _FileService = new FinalInspectionuploadService();

        [HttpGet()]
        [ActionName("GetInspections")]
        public IHttpActionResult GetInspections()
        {
            //System.Threading.Thread.Sleep(2000);
            try
            {
                var InspectionHistory = _InspectionService.GetAll().Select(result => new FinalInspection
                {
                    Id = result.Id,
                    TMSPartNumber = result.TMSPartNumber,
                    MiStatusBarcode = result.MiStatusBarcode,
                    DateInspected = result.DateInspected.ToString("MM/dd/yyyy"),
                    QuantityInspected = result.QuantityInspected,
                    QuantityAccepted = result.QuantityAccepted,
                    InspectionType = result.InspectionType,
                    MfgLocation = result.MfgLocation,
                    InspectionLocation = result.InspectionLocation,
                    InspectorName = result.Inspector.FirstName + " " + result.Inspector.LastName,
                    EmployeeId = result.Inspector.EmployeeId,
                    FinalInspectionUploads = ConvertAPIUploads(result.FinalInspectionUploads)
                });
                if (InspectionHistory != null)
                {
                    return Ok(InspectionHistory);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost()]
        [ActionName("AddNewInspection")]
        public IHttpActionResult AddNewInspection(FinalInspection newInspection)
        {
            if(ModelState.IsValid)
            {
                //var upload = new FInspectData.Models.FinalInspectionUpload();
                //var inspector = new FInspectData.Models.Inspector();
                //inspector = _InspectorService.GetByEmployeeId(newInspection.EmployeeId);
                var Record = new FInspectData.Models.FinalInspection()
                {
                    TMSPartNumber = newInspection.TMSPartNumber,
                    MiStatusBarcode = newInspection.MiStatusBarcode,
                    DateInspected = DateTime.Now,
                    QuantityAccepted = newInspection.QuantityAccepted,
                    QuantityInspected = newInspection.QuantityInspected,
                    MfgLocation = newInspection.MfgLocation,
                    InspectionLocation = newInspection.InspectionLocation,
                    InspectionType = newInspection.InspectionType,
                    Inspector = _InspectorService.GetByEmployeeId(newInspection.EmployeeId),
                    FinalInspectionUploads = ConvertDATAUploads(newInspection.FinalInspectionUploads)
                };
                //if (newInspection.FinalInspectionUploads != null)
                //{
                //    foreach (var item in newInspection.FinalInspectionUploads)
                //    {
                //        var upload = new FInspectData.Models.FinalInspectionUpload
                //        {
                //            Attachment = item.ToString()
                //        };
                //        Record.FinalInspectionUploads.Add(upload);
                //    }
                //}
                _InspectionService.Add(Record);
                return Ok(newInspection);
            }
            else
            {
                return BadRequest("Model state not valid. " + ModelState);
            }            
        }

        [HttpDelete()]
        [ActionName("DeleteInspection")]
        public IHttpActionResult DeleteInspection(int id)
        {
            if (id != 0)
            {
                _InspectionService.Delete(id);
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut()]
        [ActionName("UpdateInspection")]
        public IHttpActionResult UpdateInspection(int? id, FinalInspection inspection)
        {
            if (id != inspection.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var newDetails = new FInspectData.Models.FinalInspection()
                {
                    //Id = inspection.Id ?? default(int),
                    Id = inspection.Id.GetValueOrDefault(),
                    TMSPartNumber = inspection.TMSPartNumber,
                    MiStatusBarcode = inspection.MiStatusBarcode,
                    QuantityInspected = inspection.QuantityInspected,
                    QuantityAccepted = inspection.QuantityAccepted,
                    MfgLocation = inspection.MfgLocation,
                    InspectionLocation = inspection.InspectionLocation,
                    InspectionType = inspection.InspectionType,
                    Inspector = _InspectorService.GetByEmployeeId(inspection.EmployeeId),
                    FinalInspectionUploads = ConvertDATAUploads(inspection.FinalInspectionUploads)
                    //FinalInspectionUploads = new List<FInspectData.Models.FinalInspectionUpload>()
                };
                // Call get upload method on FinalInspection Object, creates list of objects from list of strings
                //newDetails.FinalInspectionUploads = newDetails.GetUploadObjects(inspection.FinalInspectionUploads);
                _InspectionService.Update(newDetails);
                return Ok(System.Net.HttpStatusCode.NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpPost()]
        [ActionName("UploadInspectionFiles")]
        public IHttpActionResult UploadInspectionFiles()
        {
            int i = 0;
            int j = 1;
            int cntSuccess = 0;
            var uploadedFileNames = new List<string>();
            string result = string.Empty;

            HttpResponseMessage response = new HttpResponseMessage();

            var httpRequest = HttpContext.Current.Request;
            if(httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[i];
                    var filePath = HttpContext.Current.Server.MapPath("~/Uploads/" + postedFile.FileName);
                    try
                    {
                        postedFile.SaveAs(filePath);
                        uploadedFileNames.Add(httpRequest.Files[i].FileName);
                        cntSuccess++;
                    }
                    catch (Exception ex)
                    {
                        return BadRequest("Unable to upload files! " + ex.Message);
                    }

                    i++;
                }
            }

            return Json(uploadedFileNames);

            //result = cntSuccess.ToString() + " files uploaded successfully. <br/>";
            //result += "<ul>";

            //foreach (var f in uploadedFileNames)
            //{
            //    result += "<li id=Upload_" + j + "\">" + f + "</li>";
            //    j++;
            //}

            //result += "</ul>";
            //return Json(result);
        }

        [HttpGet()]
        [ActionName("DownloadFiles")]
        public IHttpActionResult DownloadFiles(int id)
        {
            FInspectData.Models.FinalInspectionUpload fileObj = new FInspectData.Models.FinalInspectionUpload();
            fileObj = _FileService.GetFileById(id);
            string fileName = fileObj.Attachment;
            string filePath = HttpContext.Current.Server.MapPath("/Uploads/" + fileName);

            var dataBytes = File.ReadAllBytes(filePath);
            var dataStream = new MemoryStream(dataBytes);
            return new UploadResult(dataStream, Request, fileName);
        }

        public List<FinalInspectionUpload> ConvertAPIUploads(ICollection<FInspectData.Models.FinalInspectionUpload> _uploads)
        {
            List<FinalInspectionUpload> uploads = new List<FinalInspectionUpload>();
            foreach(var upload in _uploads)
            {
                var newUpload = new FinalInspectionUpload();
                newUpload.Id = upload.Id;
                newUpload.Attachment = upload.Attachment;
                newUpload.FinalInspection_Id = upload.FinalInspection_Id;
                uploads.Add(newUpload);
            }
            return uploads;
        }

        public List<FInspectData.Models.FinalInspectionUpload> ConvertDATAUploads(List<FinalInspectionUpload> _uploads)
        {
            List<FInspectData.Models.FinalInspectionUpload> uploads = new List<FInspectData.Models.FinalInspectionUpload>();
            foreach (var upload in _uploads)
            {
                var newUpload = new FInspectData.Models.FinalInspectionUpload();
                newUpload.Id = upload.Id;
                newUpload.Attachment = upload.Attachment;
                newUpload.FinalInspection_Id = upload.FinalInspection_Id;
                uploads.Add(newUpload);
            }
            return uploads;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

    }
}