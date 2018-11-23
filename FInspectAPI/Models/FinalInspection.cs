using System;
using System.Collections.Generic;

namespace FInspectAPI.Models
{
    public class FinalInspection
    {
        public int? Id { get; set; }
        public string TMSPartNumber { get; set; }
        public string MiStatusBarcode { get; set; }
        public string DateInspected { get; set; }
        public int QuantityInspected { get; set; }
        public int QuantityAccepted { get; set; }
        public string MfgLocation { get; set; }
        public string InspectionLocation { get; set; }
        public string InspectionType { get; set; }
        public string InspectorName { get; set; }
        public int EmployeeId { get; set; }
        public List<FinalInspectionUpload> FinalInspectionUploads { get; set; }

        public List<FinalInspectionUpload> ConvertList(List<FInspectData.Models.FinalInspectionUpload> _uploads)
        {
            List<FinalInspectionUpload> uploads = new List<FinalInspectionUpload>();
            foreach (var item in _uploads)
            {
                var upload = new FinalInspectionUpload();
                upload.Attachment = item.Attachment;
                upload.Id = item.Id;
                upload.FinalInspection_Id = item.FinalInspection_Id;
            }
            return uploads;
        }
    }
}