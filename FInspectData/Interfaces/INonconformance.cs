using FInspectData.Models;
using System.Collections.Generic;

namespace FInspectData.Interfaces
{
    public interface INonconformance
    {
        IEnumerable<Nonconformance> GetAllNonconformances();
        Nonconformance GetNonconformance(int id);
        void AddNonconformance(Nonconformance nonconformance);
        void UpdateNonconformance(Nonconformance nonconformance);
        void DeleteNonconformance(int id);
    }
}
