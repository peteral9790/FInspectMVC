using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FInspectData.Models
{
    public class FinalInspectionUpload
    {
        [Key]
        public int Id { get; set; }
        public string Attachment { get; set; }

        public int FinalInspection_Id { get; set; }

        [ForeignKey("FinalInspection_Id")]
        public virtual FinalInspection FinalInspection { get; set; }
    }
}
