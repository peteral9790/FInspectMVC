using FInspectData.Models;

namespace FInspectData.Interfaces
{
    public interface IMiStatusTransaction
    {
        MiStatusTransaction GetMIStatusTransaction(int id);
    }
}
