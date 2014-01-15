using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PListBuilder
{
    public class PlistReal : IPlistValue
    {
        public string Value
        {
            get;
            private set;
        }

        public PlistReal(double val)
        {
            Value = val.ToString();
        }

        public string AsPlistXmlOutput()
        {
            return PlistOutputHelper.MakeSimpleValueWrappedWithTag(PlistOutputHelper.RealValueTag, Value);
        }
    }
}
