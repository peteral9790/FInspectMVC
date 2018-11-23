using System;
namespace FInspectData.Models
{
    public class Nonconformance
    {
        public int Id { get; set; }
        public string TMSPartNumber { get; set; }
        public string SerialNumbers { get; set; }
        public string MiStatusBarcode { get; set; }
        public DateTime DateRejected { get; set; }
        public int QuantityRejected { get; set; }
        public string RejectCategory { get; set; }
        public string RejectDescription { get; set; }
        public string PersonResponsible { get; set; }
        public string RootCause { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public string Disposition { get; set; }

        public virtual Inspector Inspector { get; set; }
    }
}
