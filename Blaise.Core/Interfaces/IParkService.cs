using System.Collections.Generic;

namespace Blaise.Core.Interfaces
{
    public interface IParkService
    {
        IEnumerable<string> GetParks();
    }
}