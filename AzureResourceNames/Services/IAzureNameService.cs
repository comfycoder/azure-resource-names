using System.Collections.Generic;
using AzureResourceNames.Models;

namespace AzureResourceNames.Services
{
    public interface IAzureNameService
    {
        IEnumerable<string> GetResourceNames(NameViewModel name);
        IEnumerable<string> GetResourceName(NameViewModel name, string resourceType);
    }
}