using System.Collections.Generic;

namespace FInspectAPI.Models
{
    public class FinalInspectionUpload
    {
        public int Id { get; set; }
        public string Attachment { get; set; }
        public int FinalInspection_Id { get; set; }
    }
}