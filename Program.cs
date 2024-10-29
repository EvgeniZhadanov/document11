using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

using Xceed.Words.NET;

namespace ConsoleApp1
{
    
    internal class Program
    {
        

        static JObject GetBankDataByBik(string bik)
        {
            string jsonFilePath = @"C:\Users\Евгений\Desktop\1.json";
            var jsonData = File.ReadAllText(jsonFilePath);
            var banks = JArray.Parse(jsonData);

            var bank = banks.FirstOrDefault(b => b["bik"].ToString() == bik);

            return bank as JObject;
        }

        static void Main(string[] args)
        {
            WriteLine("Введите наименование контрагента:");
            string clientName = ReadLine();
            WriteLine("Введите имя клиента:");
            string clientFIO = ReadLine();
            WriteLine("Введите ИНН клиента:");
            string clientINN = ReadLine();
            WriteLine("Введите ОГРН клиента:");
            string clientOGRN = ReadLine();
            WriteLine("Введите расчётный счёт клиента:");
            string CurrentAccount = ReadLine();

            WriteLine("Введите БИК банка:");
            string bik = ReadLine();
            string ks = String.Empty;
            string name = String.Empty;

            // Загрузка данных из JSON файла
            var bankData = GetBankDataByBik(bik);

            if (bankData != null)
            {
                ks = bankData["ks"].ToString();
                name = bankData["name"].ToString();
                //{bankData["address"]};
            }
            else
            {
                WriteLine("Информация о банке не найдена.");
            }


            WriteLine("Введите адрес клиента:");
            string ClientAdres = ReadLine();

            WriteLine("введите наименование товара");
            string product = ReadLine();    
            WriteLine("введите количество");
            int amount = Convert.ToInt32(ReadLine());
            WriteLine("введите цену за еденицу");
            double price = Convert.ToDouble(ReadLine());
            double result = price * amount;

            DocumentGenerator check = new DocumentGenerator();
            check.CreateContract(
                check.now, clientName, clientINN, ClientAdres, CurrentAccount, bik, ks, name, @"D:\document\счёт шаблон.docx",
                product, amount, price, result);

            DocumentGenerator productsList = new DocumentGenerator();
            productsList.CreateProductsList(
                productsList.now, clientName, clientINN, ClientAdres, CurrentAccount, bik, ks, name, @"D:\document\Накладная_ТОРГ-12.docx",
product, amount, price, result);

            DocumentGenerator docGen = new DocumentGenerator();
            docGen.CreateContract(
                docGen.now, clientName, clientINN, clientOGRN, ClientAdres, CurrentAccount, bik, ks, name, clientFIO, @"D:\document\Договор Поставки.docx");

            Read();
        }
/*
        public class DocumentGenerator
        {
            public void CreateContract(
                DateTime contractDate, string clientName, string clientINN, string clientAdres, string CurrentAccount, string bik, string ks, string name, string outputPath)
            {
                string checkPath = "счёт шаблон.docx";
                using (DocX document = DocX.Load(checkPath))
                {
                    // Замена заполнителей на реальные данные
                    //ввод номера договора
                    document.ReplaceText("{{ContractNumber}}", now.ToString("ddMMyyyy"));
                    //ввод даты договора
                    document.ReplaceText("{{ContractDate}}", now.ToString("dd.MM.yyyy"));
                    //ввод наименование контрагента
                    document.ReplaceText("{{ClientName}}", clientName);
                    //ввод ИНН контрагента
                    document.ReplaceText("{{clientINN}}", clientINN);
                    //ввод ОГРН
                    //document.ReplaceText("{{clientOGRN}}", clientOGRN);
                    //ввод адреса
                    document.ReplaceText("{{ClientAdres}}", clientAdres);
                    //ввод расчётного счёта
                    document.ReplaceText("{{CurrentAccount}}", CurrentAccount);
                    //ввод БИК банка
                    document.ReplaceText("{{bik}}", bik);
                    // ввод кор-счёта
                    document.ReplaceText("{{ks}}", ks);
                    //имя банка
                    document.ReplaceText("{{name}}", name);
                    //ФИО уполномоченного лица
                    //document.ReplaceText("{{clientFIO}}", clientFIO);


                    // Сохранение заполненного документа
                    document.SaveAs(outputPath);
                }
            }

            public void CreateContract(
                DateTime contractDate, string clientName, string clientINN, string clientOGRN, string clientAdres, string CurrentAccount, string bik, string ks, string name, string clientFIO, string outputPath)
            {
                string templatePath = "Договор Поставки.docx";

                using (DocX document = DocX.Load(templatePath))
                {
                    // Замена заполнителей на реальные данные
                    //ввод номера договора
                    document.ReplaceText("{{ContractNumber}}", now.ToString("ddMMyyyy"));
                    //ввод даты договора
                    document.ReplaceText("{{ContractDate}}", now.ToString("dd.MM.yyyy"));
                    //ввод наименование контрагента
                    document.ReplaceText("{{ClientName}}", clientName);
                    //ввод ИНН контрагента
                    document.ReplaceText("{{clientINN}}", clientINN);
                    //ввод ОГРН
                    document.ReplaceText("{{clientOGRN}}", clientOGRN);
                    //ввод адреса
                    document.ReplaceText("{{ClientAdres}}", clientAdres);
                    //ввод расчётного счёта
                    document.ReplaceText("{{CurrentAccount}}", CurrentAccount);
                    //ввод БИК банка
                    document.ReplaceText("{{bik}}", bik);
                    // ввод кор-счёта
                    document.ReplaceText("{{ks}}", ks);
                    //имя банка
                    document.ReplaceText("{{name}}", name);
                    //ФИО уполномоченного лица
                    document.ReplaceText("{{clientFIO}}", clientFIO);


                    // Сохранение заполненного документа
                    document.SaveAs(outputPath);
                }
            }
            
            public void CreateProductsList(
               DateTime contractDate, string clientName, string clientINN, string clientAdres, string CurrentAccount, string bik, string ks, string name, string outputPath)
            {
                string goodslistPath = "Накладная_ТОРГ-12.docx";
                using (DocX document = DocX.Load(goodslistPath))
                {
                    // Замена заполнителей на реальные данные
                    //ввод номера договора
                    document.ReplaceText("{{ContractNumber}}", now.ToString("ddMMyyyy"));
                    //ввод даты договора
                    document.ReplaceText("{{ContractDate}}", now.ToString("dd.MM.yyyy"));
                    //ввод наименование контрагента
                    document.ReplaceText("{{ClientName}}", clientName);
                    //ввод ИНН контрагента
                    document.ReplaceText("{{clientINN}}", clientINN);
                    //ввод ОГРН
                    //document.ReplaceText("{{clientOGRN}}", clientOGRN);
                    //ввод адреса
                    document.ReplaceText("{{ClientAdres}}", clientAdres);
                    //ввод расчётного счёта
                    document.ReplaceText("{{CurrentAccount}}", CurrentAccount);
                    //ввод БИК банка
                    document.ReplaceText("{{bik}}", bik);
                    // ввод кор-счёта
                    document.ReplaceText("{{ks}}", ks);
                    //имя банка
                    document.ReplaceText("{{name}}", name);
                    //ФИО уполномоченного лица
                    //document.ReplaceText("{{clientFIO}}", clientFIO);


                    // Сохранение заполненного документа
                    document.SaveAs(outputPath);
                }
            }
            
        }

*/
    }
}
