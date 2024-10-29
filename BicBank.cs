using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
namespace ConsoleApp1
{
    internal class BicBank
    {
//        Console.WriteLine("Введите БИК банка:");
            //string bik = Console.ReadLine();

        // Загрузка данных из JSON файла
        var bankData = GetBankDataByBik(bik);

            if (bankData != null)
            {
                Console.WriteLine($"Название банка: {bankData["name"]}");
                Console.WriteLine($"Корреспондентский счет: {bankData["ks"]}");
                Console.WriteLine($"Адрес: {bankData["address"]}");
            }
            else
            {
                Console.WriteLine("Информация о банке не найдена.");
            }

        

        static JObject GetBankDataByBik(string bik)
{
    string jsonFilePath = @"C:\Users\Евгений\Desktop\1.json";
    var jsonData = File.ReadAllText(jsonFilePath);
    var banks = JArray.Parse(jsonData);

    var bank = banks.FirstOrDefault(b => b["bik"].ToString() == bik);

    return bank as JObject;
}

//Console.Read();    
}
}
