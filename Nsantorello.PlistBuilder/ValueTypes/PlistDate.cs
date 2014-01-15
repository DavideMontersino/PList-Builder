using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public class PlistDate : IPlistValue
    {
        private string Value
        {
            get;
            set;
        }

        public PlistDate(DateTime val)
        {
            Value = val.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

        public string AsPlistXmlOutput()
        {
            return PlistOutputHelper.MakeSimpleValueWrappedWithTag(PlistOutputHelper.DateValueTag, Value);
        }
    }
}
