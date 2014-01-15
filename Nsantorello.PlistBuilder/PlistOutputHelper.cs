using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder
{
    public static class PlistOutputHelper
    {
        internal static readonly string KeyTag = "key";
        internal static readonly string IntValueTag = "integer";
        internal static readonly string RealValueTag = "real";
        internal static readonly string DateValueTag = "date";
        internal static readonly string DataValueTag = "data";
        internal static readonly string StringValueTag = "string";
        internal static readonly string DictValueTag = "dict";
        internal static readonly string ArrayValueTag = "array";
        internal static readonly string XmlDeclaration = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
        internal static readonly string PlistDeclaration = "<!DOCTYPE plist PUBLIC \"-//Apple//DTD PLIST 1.0//EN\" \"http://www.apple.com/DTDs/PropertyList-1.0.dtd\">";
        internal static readonly string PlistTag = "plist";
        internal static readonly string PlistVersion = "version=\"1.0\"";

        internal static string MakeOpeningTag(string tagName)
        {
            return MakeOpeningTag(tagName, null);
        }

        internal static string MakeOpeningTag(string tagName, IEnumerable<string> tagAttributes)
        {
            StringBuilder tag = new StringBuilder();

            tag.Append("<" + tagName);

            if (tagAttributes != null)
            {
                foreach (string attr in tagAttributes)
                {
                    tag.Append(" " + attr);
                }
            }

            tag.Append(">");

            return tag.ToString();
        }

        internal static string MakeClosingTag(string tagName)
        {
            StringBuilder tag = new StringBuilder();

            tag.Append("</" + tagName + ">");

            return tag.ToString();
        }

        internal static string MakeSelfClosingTag(string tagName)
        {
            return MakeSelfClosingTag(tagName, null);
        }

        internal static string MakeSelfClosingTag(string tagName, IEnumerable<string> tagAttributes)
        {
            StringBuilder tag = new StringBuilder();

            tag.Append("<" + tagName);

            if (tagAttributes != null)
            {
                foreach (string attr in tagAttributes)
                {
                    tag.Append(" " + attr);
                }
            }

            tag.Append(" />");

            return tag.ToString();
        }

        internal static string MakeSimpleValueWrappedWithTag(string tagName, string value)
        {
            StringBuilder tag = new StringBuilder();
            tag.Append(MakeOpeningTag(tagName));
            tag.Append(value);
            tag.Append(MakeClosingTag(tagName));
            return tag.ToString();
        }

        internal static string EscapeForXml(string str)
        {
            return str
                .Replace("&", "&amp;")
                .Replace("<", "&lt;")
                .Replace(">", "&gt;")
                .Replace("'", "&apos;")
                .Replace("\"", "&quot;");
        }
    }
}
