using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xceed.Document.NET;

namespace ConsoleApp1
{
    internal class Person
    {
                public Person(string _surname, string _name, string _patronymic)
        {
                        Surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_surname.Trim(' '));
            Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_name.Trim(' '));
            Patronymic = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(_patronymic.Trim(' '));
                    }

        public string Surname { set; get; }
        public string Name{ set; get; } 
                public string Patronymic{ set; get; }
                

                public string ShortName()
        {
            return $"{ Surname} {Name[0]}.{Patronymic[0]}.";
        }

        public string LongName()
        {
            return $"{Surname} {Name} {Patronymic}";
        }

        
    }
}