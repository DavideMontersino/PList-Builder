using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public class PlistDict : IPlistValue
    {
        public IEnumerable<PlistKeyValuePair> Pairs
        {
            get;
            private set;
        }

        public PlistDict(IEnumerable<PlistKeyValuePair> pairs)
        {
            if (pairs == null)
            {
                throw new ArgumentNullException("pairs");
            }

            Pairs = pairs;
        }

        public string AsPlistXmlOutput()
        {
            StringBuilder output = new StringBuilder();

            output.Append(PlistOutputHelper.MakeOpeningTag(PlistOutputHelper.DictValueTag));

            if (Pairs != null)
            {
                foreach (PlistKeyValuePair pair in Pairs)
                {
                    output.Append(pair.AsPlistOutput());
                }
            }

            output.Append(PlistOutputHelper.MakeClosingTag(PlistOutputHelper.DictValueTag));

            return output.ToString();
        }
    }
}
