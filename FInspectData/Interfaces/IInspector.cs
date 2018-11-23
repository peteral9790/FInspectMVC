using FInspectData.Models;
using System.Collections.Generic;

namespace FInspectData.Interfaces
{
    public interface IInspector
    {
        void Delete(int id);
        void Update(Inspector inspector);
        Inspector GetByEmployeeId(int employeeId);
        IEnumerable<Inspector> GetAll();
        void Add(Inspector inspector);
    }
}
