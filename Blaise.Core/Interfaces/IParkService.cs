using System;
using System.Collections.Generic;

namespace Blaise.Core.Interfaces
{
    public interface IParkService
    {
        IEnumerable<string> GetServerParkNames();

        Guid GetInstrumentId(string instrumentName, string serverParkName);
    }
}
