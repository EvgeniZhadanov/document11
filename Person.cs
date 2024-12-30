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
                public Person(string _surname, string _name, string _patronymic)
        {
                        Surname = _surname;
            Name = _name;
            Patronymic = _patronymic;
                    }
        
        public string Surname { set; get; }
        public string Name{ set; get; } 
                public string Patronymic{ set; get; }
                

                public string ShortName()
        {
            return $"{ Surname.Trim(' ')} {Name.Trim(' ')[0]}. {Patronymic.Trim(' ')[0]}.".ToUpper();
        }

        public string LongName()
        {
            string longname = $"{Surname.Trim(' ')} {Name.Trim(' ')} {Patronymic.Trim(' ')}";
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(longname);
        }

    }
}