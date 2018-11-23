using FInspectData;
using FInspectData.Interfaces;
using FInspectData.Models;
using System.Linq;

namespace FInspectServices
{
    public class MiStatusService : IMiStatusTransaction
    {
        private FinalInspectionContext _db = new FinalInspectionContext();

        public MiStatusTransaction GetMIStatusTransaction(int id)
        {
            var result = _db.MiStatusTransactions.FirstOrDefault(x => x.Id == id);
            return result;
        }
    }
}
