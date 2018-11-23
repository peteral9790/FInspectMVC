using System;
using System.Collections.Generic;

namespace FInspectData.Models
{
    public class FinalInspection
    {
        public int Id { get; set; }
        public string TMSPartNumber { get; set; }
        public string MiStatusBarcode { get; set; }
        public DateTime DateInspected { get; set; }
        public int QuantityInspected { get; set; }
        public int QuantityAccepted { get; set; }
        public string HardwareRequired { get; set; }
        public string InspectionType { get; set; }
        public string MfgLocation { get; set; }
        public string InspectionLocation { get; set; }

        public virtual Inspector Inspector { get; set; }
        public virtual ICollection<FinalInspectionUpload> FinalInspectionUploads { get; set; }

        //Methods for transforming list of strings to a  list of upload objects
        public List<string> GetUploadList(ICollection<FinalInspectionUpload> uploads)
        {
            List<string> uploadList = new List<string>();
            if (uploads != null)
            {
                foreach (var item in uploads)
                {
                    uploadList.Add(item.Attachment);
                }
            }
            return uploadList;
        }
        public ICollection<FinalInspectionUpload> GetUploadObjects(List<string> uploadList)
        {
            List<FinalInspectionUpload> uploads = new List<FinalInspectionUpload>();

            foreach (var upload in uploadList)
            {
                var newUpload = new FinalInspectionUpload();
                newUpload.Attachment = upload.ToString();
                uploads.Add(newUpload);
            }

            return uploads;

        }
    }

    
}
