using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace Nsantorello.PlistBuilder.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Use this method to test out how things are serialized.  
             * Here we initialize some objects and serialize them below. */
            SimpleInt i1 = new SimpleInt() { Whole = 1, Fraction = 222 };
            SimpleInt i2 = new SimpleInt() { Whole = 2, Fraction = 333 };
            SimpleInt i3 = new SimpleInt() { Whole = 3, Fraction = 444 };
            Dictionary<string, SimpleInt> dict = new Dictionary<string,SimpleInt>();
            dict.Add("i1", i1);
            dict.Add("i2", i2);
            dict.Add("i3", i3);

            Dictionary<string, string> strings = new Dictionary<string, string>();
            strings.Add("str1", "hello1");
            strings.Add("str2", "hello2");
            strings.Add("str3", "hello3");
            strings.Add("str4", "hello4");

            SimpleObj obj = new SimpleObj()
            {
                MyBool = true,
                MyData = new byte[] { 0x4d, 0x61, 0x6e },
                MyDouble = 3.14,
                MyDoubles = new List<double>() { 1.0, 1.1, 1.2, 1.3, 1.4 },
                MyFloat = 1.611111f,
                MyInt = 8,
                MyInts = new int[] { 1, 1, 2, 3, 5, 8 },
                MyString = "Hello world!",
                MyTime = DateTime.Now,
                MyDict = dict
            };

            SimpleObj obj2 = new SimpleObj()
            {
                MyBool = true,
                MyData = new byte[] { 0x4d, 0x61, 0x6e },
                MyDouble = 3.14,
                MyDoubles = new List<double>() { 1.0, 1.1, 1.2, 1.3, 1.4 },
                MyFloat = 1.611111f,
                MyInt = 8,
                MyInts = new int[] { 1, 1, 2, 3, 5, 8 },
                MyString = "Hello world!",
                MyTime = DateTime.Now,
                MyObj = obj,
                MyOtherDict = strings
            };

            dynamic eo = new ExpandoObject();
            eo.FirstObject = "testString";
            eo.SecondObject = obj2;

            string serialized = PlistGenerator.Serialize(eo, true);
            
            Console.WriteLine(serialized);
            Console.ReadLine();
        }
    }

    class SimpleObj
    {
        public int MyInt { get; set; }
        public bool MyBool { get; set; }
        public float MyFloat { get; set; }
        public double MyDouble { get; set; }
        public DateTime MyTime { get; set; }
        public string MyString { get; set; }
        public byte[] MyData { get; set; }
        public int[] MyInts { get; set; }
        public List<double> MyDoubles { get; set; }
        public object MyObj { get; set; }
        public Dictionary<string, SimpleInt> MyDict { get; set; }
        public Dictionary<string, string> MyOtherDict { get; set; }
    }

    class SimpleInt
    {
        public int Whole { get; set; }
        public int Fraction { get; set; }
    }
}
