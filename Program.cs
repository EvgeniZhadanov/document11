using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

using Xceed.Words.NET;
using System.Net;
using Xceed.Document.NET;
using System.Xml.Linq;

namespace ConsoleApp1
{

    internal class Program
    {

        static JObject GetBankDataByBik(string bik)
        {
                        var jsonData = File.ReadAllText("1.json");
            var banks = JArray.Parse(jsonData);

            var bank = banks.FirstOrDefault(b => b["bik"].ToString() == bik);

            return bank as JObject;
        }

        static DateTime now = DateTime.Now;
        static void Main(string[] args)
        {

            var placeholders = new Dictionary<string, string>();
            placeholders["{{ContractNumber}}"] = now.ToString("ddmmyyyy/hh:mm");
            placeholders["{{ContractDate}}"] = now.ToLongDateString();

            Console.WriteLine("Введите наименование контрагента:");
            placeholders["{{counterparty}}"] = Console.ReadLine();
            Console.WriteLine("Введите ФИО руковадителя. \n фомилия:");
            string surname = Console.ReadLine();
            Console.Write("Имя:");
            string name = Console.ReadLine();
            Console.Write("Отчество:");
            string patronymic = Console.ReadLine(); 
            Person person = new Person(surname, name, patronymic);
            placeholders["{{longname}}"] = person.LongName();
            placeholders["{{shortname}}"] = person.ShortName();

            Console.WriteLine("Введите ИНН клиента:");
            placeholders["{{inn}}"] = Console.ReadLine();
            Console.WriteLine("Введите ОГРН клиента:");
            placeholders["{{ogrn}}"] = Console.ReadLine();
            Console.WriteLine("Введите расчётный счёт клиента:");
            placeholders["{{currentaccount}}"] = Console.ReadLine();

            Console.WriteLine("Введите БИК банка:");
            var bankData = GetBankDataByBik(Console.ReadLine());
                        if (bankData != null)
            {
                placeholders["{{bik}}"] = bankData["bik"].ToString();
                                placeholders["{{bankname}}"] = bankData["name"].ToString();
                placeholders["{{correspondentaccount}}"] = bankData["ks"].ToString();
            }
            else
            {
                Console.WriteLine("Информация о банке не найдена.");
            }

            Console.WriteLine("Введите адрес клиента:");
            placeholders["{{address}}"] = Console.ReadLine();
            Console.WriteLine("введите наименование товара");
            placeholders["{{product}}"] = Console.ReadLine();

            Console.WriteLine("введите количество");
            int _amount = int.Parse(Console.ReadLine());
            placeholders["{{amount}}"] = _amount.ToString();
            Console.WriteLine("введите цену за еденицу");
            decimal _price = decimal.Parse(Console.ReadLine());
            placeholders["{{price}}"] = _price.ToString();
                        decimal _result = _price * _amount;
            placeholders["{{result}}"] = _result.ToString();

            
            //Replacedata replacedata = new Replacedata();
            Replacedata.FillTemplate(placeholders);
            Console.WriteLine("Документы созданы");
            Console.Read();
        }
    }
}
