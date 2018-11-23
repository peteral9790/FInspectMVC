using System.ComponentModel.DataAnnotations;

namespace FInspectData.Models
{
    public class Assembly
    {
        [Key]
        public string TMSPartNumber { get; set; }
        public string CustomerPartNumber { get; set; }
        public string CableMI { get; set; }
        public string CableDescription { get; set; }
        public string Length { get; set; }
        public string FWDConnType { get; set; }
        public string FWDConnector { get; set; }
        public string FWDIntermediate { get; set; }
        public string AFTIntermediate { get; set; }
        public string AFTConnector { get; set; }
        public string AFTConnType { get; set; }
    }
}
