using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PListBuilder
{
    public class PlistArray : IPlistValue
    {
        public ICollection<IPlistValue> Values
        {
            get;
            private set;
        }

        public PlistArray(ICollection<IPlistValue> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            Values = values;
        }

        public string AsPlistXmlOutput()
        {
            StringBuilder output = new StringBuilder();

            output.Append(PlistOutputHelper.MakeOpeningTag(PlistOutputHelper.ArrayValueTag));

            if (Values != null)
            {
                foreach (IPlistValue plv in Values)
                {
                    output.Append(plv.AsPlistXmlOutput());
                }
            }

            output.Append(PlistOutputHelper.MakeClosingTag(PlistOutputHelper.ArrayValueTag));

            return output.ToString();
        }
    }
}
