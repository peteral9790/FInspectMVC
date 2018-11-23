using FInspectData;
using FInspectData.Interfaces;
using FInspectData.Models;
using System.Linq;

namespace FInspectServices
{
    public class FinalInspectionuploadService : IFinalInspectionUpload
    {
        FinalInspectionContext _db = new FinalInspectionContext();

        public FinalInspectionUpload GetFileById(int id)
        {
            return _db.FinalInspectionUploads.FirstOrDefault(u => u.Id == id);
        }
    }
}
