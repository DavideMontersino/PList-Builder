using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public class PlistKeyValuePair
    {
        public string Key
        {
            get;
            private set;
        }

        public IPlistValue Value 
        { 
            get; 
            private set; 
        }

        public PlistKeyValuePair(string key, IPlistValue val)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("Key cannot be null or empty.");
            }

            if (val == null)
            {
                throw new ArgumentNullException("val");
            }

            Key = key;
            Value = val;
        }

        public string AsPlistOutput()
        {
            return AsPlistOutputHelper(Key, Value);
        }

        protected static string AsPlistOutputHelper(string key, IPlistValue value)
        {
            StringBuilder output = new StringBuilder();

            // Add key.
            output.Append(PlistOutputHelper.MakeSimpleValueWrappedWithTag(PlistOutputHelper.KeyTag, key));

            // Add value.
            output.Append(value.AsPlistXmlOutput());

            return output.ToString();
        }
    }
}
