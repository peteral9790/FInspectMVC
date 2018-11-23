using FInspectData.Models;

namespace FInspectData.Interfaces
{
    public interface IAssemblyDetails
    {
        Assembly GetAssemblyDetails(string PartNumber);
    }
}
