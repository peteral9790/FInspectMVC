using FInspectData;
using FInspectData.Interfaces;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using FInspectData.Models;
using System.Data.Entity.Infrastructure;
using System;

namespace FInspectService
{
    public class NonconformanceService : INonconformance
    {
        FinalInspectionContext _db = new FinalInspectionContext();

        public void AddNonconformance(Nonconformance nonconformance)
        {
            throw new NotImplementedException();
        }

        public void DeleteNonconformance(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nonconformance> GetAllNonconformances()
        {
            var NCHistory = _db.Nonconformances.Include(x => x.Inspector);
            return NCHistory;
        }

        public Nonconformance GetNonconformance(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateNonconformance(Nonconformance nonconformance)
        {
            throw new NotImplementedException();
        }
    }
}
