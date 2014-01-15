using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public class PlistString : IPlistValue
    {
        public string Value
        {
            get;
            private set;
        }

        public PlistString(string val)
        {
            if (val == null)
            {
                throw new ArgumentNullException("val");
            }

            Value = val;
        }

        public string AsPlistXmlOutput()
        {
            return PlistOutputHelper.MakeSimpleValueWrappedWithTag(PlistOutputHelper.StringValueTag, 
                PlistOutputHelper.EscapeForXml(Value));
        }
    }
}
