using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PListBuilder
{
    public class PlistDocument
    {
        public IPlistValue Value
        {
            get;
            private set;
        }

        public PlistDocument(IPlistValue val)
        {
            if (val == null)
            {
                throw new ArgumentNullException("val");
            }

            Value = val;
        }

        public string ToPlistXmlOutput()
        {
            StringBuilder output = new StringBuilder();

            // Plist declaration and opening tag.
            output.Append(PlistOutputHelper.XmlDeclaration);
            output.Append(PlistOutputHelper.PlistDeclaration);
            output.Append(PlistOutputHelper.MakeOpeningTag(PlistOutputHelper.PlistTag, new string[] { PlistOutputHelper.PlistVersion }));
            output.Append(Value.AsPlistXmlOutput());
            output.Append(PlistOutputHelper.MakeClosingTag(PlistOutputHelper.PlistTag));

            return output.ToString();
        }

        public override string ToString()
        {
            return ToPlistXmlOutput();
        }
    }
}
