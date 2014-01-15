using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Dynamic;

namespace PListBuilder
{
    public static class PlistGenerator
    {
        /// <summary>
        /// Serializes a simple .NET object into a plist document.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="indent"></param>
        /// <returns></returns>
        public static string Serialize(object obj, bool indent)
        {
            // Get a plist value for the object.
            IPlistValue docRoot = CreatePlistValue(obj);
            // Create a plist document from the object's value.
            PlistDocument doc = new PlistDocument(docRoot);

            return doc.ToPlistXmlOutput();
        }

        /// <summary>
        /// Creates a plist value representing the object provided based on its type.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static IPlistValue CreatePlistValue(object val)
        {
            if (val == null)
            {
                return null;
            }
            else if (val is int)
            {
                return new PlistInt((int)val);
            }
            else if (val is double)
            {
                return new PlistReal((double)val);
            }
            else if (val is float)
            {
                return new PlistReal((float)val);
            }
            else if (val is bool)
            {
                return new PlistBool((bool)val);
            }
            else if (val is string)
            {
                return new PlistString(val.ToString());
            }
            else if (val is DateTime)
            {
                return new PlistDate((DateTime)val);
            }
            else if (val is byte[])
            {
                return new PlistData((byte[])val);
            }
            else if (val is IDictionary)
            {
                return CreatePlistDict((IDictionary)val);
            }
            else if (val is ExpandoObject)
            {
                return CreateExpandoValue((ExpandoObject)val);
            }
            else if (val is IEnumerable)
            {
                return CreatePlistArray((IEnumerable)val);
            }
            else
            {
                // This is a more complex object, so analyze its properties!
                return CreateComplexValue(val);
            }
        }

        private static IPlistValue CreateExpandoValue(ExpandoObject val)
        {
            var asDict = (IDictionary<string, object>)val;
            List<PlistKeyValuePair> pairs = new List<PlistKeyValuePair>();
            PlistDict properties = new PlistDict(pairs);
            // For objects that don't have any properties, interpret it as a string
            // and get its value from ToString.  
            // This is for things like enums and such.
            if (asDict.Count() == 0)
            {
                return new PlistString(val.ToString());
            }

            foreach (var pi in asDict)
            {
                IPlistValue propVal = CreatePlistValue(pi.Value);

                if (propVal != null)
                {
                    pairs.Add(new PlistKeyValuePair(pi.Key, propVal));
                }
            }

            return properties;
        }

        /// <summary>
        /// Create a plist key value pair from an object's list of properties.
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        private static IPlistValue CreateComplexValue(object val)
        {
            // Grab properties of the object.
            PropertyInfo[] valProps = val.GetType().GetProperties();
            List<PlistKeyValuePair> pairs = new List<PlistKeyValuePair>();
            PlistDict properties = new PlistDict(pairs);

            // For objects that don't have any properties, interpret it as a string
            // and get its value from ToString.  
            // This is for things like enums and such.
            if (valProps.Length == 0)
            {
                return new PlistString(val.ToString());
            }

            // Loop through each property.
            foreach (PropertyInfo pi in valProps)
            {
                // Convert the property's value to a plist value.
                IPlistValue propVal = CreatePlistValue(pi.GetValue(val, null));

                // If the value isn't null, add it to the list of pairs.
                if (propVal != null)
                {
                    pairs.Add(new PlistKeyValuePair(pi.Name, propVal));
                }
            }

            return properties;
        }

        /// <summary>
        /// Creates a plist array from an IEnumerable.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        private static PlistArray CreatePlistArray(IEnumerable enumerable)
        {
            // Create a new plist array.
            List<IPlistValue> arrayVals = new List<IPlistValue>();
            PlistArray finalArray = new PlistArray(arrayVals);

            // Iterate through each value in the array and create a plist value for it,
            // then add it to the plist array.
            foreach (object newObj in enumerable)
            {
                arrayVals.Add(CreatePlistValue(newObj));
            }

            return finalArray;
        }

        /// <summary>
        /// Creates a plist dictionary from an IDictionary.
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        private static IPlistValue CreatePlistDict(IDictionary dict)
        {
            // Create a new plist dict.
            List<PlistKeyValuePair> pairs = new List<PlistKeyValuePair>();
            PlistDict finalDict = new PlistDict(pairs);

            // Iterate through each key in the dictionary and create a plist value for it,
            // then add it to the plist dict.
            foreach (object key in dict.Keys)
            {
                // Keys HAVE to be a string in plist format, so we call ToString on the key.
                string keyString = key.ToString();

                // Grab the value the key maps to.
                object mappedValue = dict[key];
                IPlistValue mappedAsPlist = CreatePlistValue(mappedValue);

                // If the mapped value isn't null, add it to the list of pairs.
                if (mappedAsPlist != null)
                {
                    pairs.Add(new PlistKeyValuePair(keyString, mappedAsPlist));
                }
            }

            return finalDict;
        }
    }
}
