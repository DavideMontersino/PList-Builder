using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PListBuilder
{
    public class PlistInt : IPlistValue
    {
        public string Value
        {
            get;
            private set;
        }

        public PlistInt(int val)
        {
            Value = val.ToString();
        }

        public string AsPlistXmlOutput()
        {
            return PlistOutputHelper.MakeSimpleValueWrappedWithTag(PlistOutputHelper.IntValueTag, Value);
        }
    }
}
