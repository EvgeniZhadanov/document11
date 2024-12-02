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

namespace ConsoleApp1
{

    internal class Program
    {

        static JObject GetBankDataByBik(string bik)
        {
            //string jsonFilePath = @"C:\Users\Евгений\Desktop\1.json";
            var jsonData = File.ReadAllText("1.json");
            var banks = JArray.Parse(jsonData);

            var bank = banks.FirstOrDefault(b => b["bik"].ToString() == bik);

            return bank as JObject;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите наименование контрагента:");
            string counterparty = Console.ReadLine();
            Console.WriteLine("Введите имя клиента:");
            string director = Console.ReadLine();
            Console.WriteLine("Введите ИНН клиента:");
            string inn = Console.ReadLine();
            Console.WriteLine("Введите ОГРН клиента:");
            string ogrn = Console.ReadLine();
            Console.WriteLine("Введите расчётный счёт клиента:");
            string currentaccount = Console.ReadLine();

            Console.WriteLine("Введите БИК банка:");
            string bik = Console.ReadLine();
            string correspondentaccount = String.Empty;
            string bankname = String.Empty;

            // Загрузка данных из JSON файла
            var bankData = GetBankDataByBik(bik);

            if (bankData != null)
            {
                correspondentaccount = bankData["ks"].ToString();
                bankname = bankData["name"].ToString();
                //{bankData["address"]};
            }
            else
            {
                Console.WriteLine("Информация о банке не найдена.");
            }

            Console.WriteLine("Введите адрес клиента:");
            string address = Console.ReadLine();
            Console.WriteLine("введите наименование товара");
            string product = Console.ReadLine();
            Console.WriteLine("введите количество");
            int amount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите цену за еденицу");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            decimal result = price * amount;


            Replacedata document = new Replacedata(
                counterparty, director, inn, ogrn, address, currentaccount, bik, correspondentaccount, bankname, product, amount, price, result);
            
            Console.WriteLine("готов");
            Console.Read();
        }
    }
}
