using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;

namespace ConsoleApp1
{
    internal class Person
    {
                public Person(string director)
        {
             strings = director.Split(' ');
        }
        public string[] strings { get; set; } 
        public string Director { set; get; } 

        


        public string ShortName()
        {
            string shortname = strings[0].Trim(' ');
            char n = strings[1].Trim(' ')[0];
            char p = strings[2].Trim(' ')[0];
            shortname += " " + n + ". " + p + ".";
            return shortname.ToUpper();
        }
        public string LongName()
        {
            string longname = strings[0].Trim(' ') + " " + strings[1].Trim(' ') + " " + strings[2].Trim(' ').ToString();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(longname);
        }

    }
}