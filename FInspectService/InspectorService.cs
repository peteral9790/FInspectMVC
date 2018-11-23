 using FInspectData;
using FInspectData.Interfaces;
using FInspectData.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FInspectServices
{
    public class InspectorService : IInspector
    {
        private FinalInspectionContext _db = new FinalInspectionContext();

        public void Add(Inspector inspector)
        {
            if(inspector != null)
            {
                _db.Inspectors.Add(inspector);
                AttemptSave();
            }
        }

        public IEnumerable<Inspector> GetAll()
        {
            return _db.Inspectors;
        }

        public Inspector GetByEmployeeId(int employeeId)
        {
            var inspector = _db.Inspectors.FirstOrDefault(x => x.EmployeeId == employeeId);
            return inspector;
        }

        public void Delete(int id)
        {
            var inspector = _db.Inspectors.SingleOrDefault(x => x.Id == id);
            if (inspector != null)
            {
                _db.Inspectors.Remove(inspector);
                AttemptSave();
            }
            else
            {
                throw new NullReferenceException();
            }

        }

        public void Update(Inspector inspector)
        {
            if (inspector != null)
            {
                try
                {
                    var record = _db.Inspectors.Single(x => x.Id == inspector.Id);
                    record.FirstName = inspector.FirstName;
                    record.LastName = inspector.LastName;
                    record.Location = inspector.Location;
                    record.EmployeeId = inspector.EmployeeId;
                    _db.Entry(record).State = System.Data.Entity.EntityState.Modified;
                    AttemptSave();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
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
