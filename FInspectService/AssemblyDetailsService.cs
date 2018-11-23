using FInspectData;
using FInspectData.Interfaces;
using FInspectData.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FInspectServices
{
    public class AssemblyDetailsService : IAssemblyDetails
    {
        private FinalInspectionContext _db = new FinalInspectionContext();

        public Assembly GetAssemblyDetails(string TMSPartNumber)
        {
            var result = _db.Assemblies.FirstOrDefault(a => a.TMSPartNumber == TMSPartNumber);
            return result;
        }

        public void AttemptSave()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
