using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1ClassLibraryCS
{
    // Interface that is implemented by address book to enable writing and reading from JSON file
    public interface IJSONSerializer
    {
        Boolean readFromJSON(string file);
        Boolean writeToJSON(string file);
    }
}
