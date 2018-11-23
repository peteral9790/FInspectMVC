using FInspectData.Models;
using System.Collections.Generic;
using System.Linq;

namespace FInspectData.Interfaces
{
    public interface IInspection
    {
        IEnumerable<FinalInspection> GetAll();
        FinalInspection GetById(int id);
        void Add(FinalInspection newInspection);
        void Delete(int id);
        void Update(FinalInspection newInspectionDetails);
        string GetInspectorName(int id);
        IEnumerable<FinalInspection> GetByInspector(string Inspector_Id);
        IEnumerable<FinalInspection> GetByInspectionType(string InspectionType);
        FinalInspection GetByMiStatusBarcode(string MiStatusBarcode);
    }
}
