using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public class PlistBool : IPlistValue
    {
        public string Value
        {
            get;
            private set;
        }

        public PlistBool(bool val)
        {
            Value = val.ToString().ToLower();
        }

        public string AsPlistXmlOutput()
        {
            return PlistOutputHelper.MakeSelfClosingTag(Value);
        }
    }
}
