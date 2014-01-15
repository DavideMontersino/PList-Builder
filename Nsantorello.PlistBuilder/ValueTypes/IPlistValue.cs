using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public interface IPlistValue
    {
        /// <summary>
        /// Returns what the plist value would look like as output in an actual plist-formatted XML document.
        /// </summary>
        /// <returns></returns>
        string AsPlistXmlOutput();
    }
}
