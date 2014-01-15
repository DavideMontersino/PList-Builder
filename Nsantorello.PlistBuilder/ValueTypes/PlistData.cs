using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public class PlistData : IPlistValue
    {
        public string Value
        {
            get;
            private set;
        }

        public PlistData(byte[] val)
        {
            if (val == null)
            {
                throw new ArgumentNullException("val");
            }

            Value = Convert.ToBase64String(val);
        }

        public string AsPlistXmlOutput()
        {
            return PlistOutputHelper.MakeSimpleValueWrappedWithTag(PlistOutputHelper.DataValueTag, Value);
        }
    }
}
