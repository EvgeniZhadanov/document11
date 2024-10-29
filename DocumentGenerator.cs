using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace ConsoleApp1
{
     
    internal class DocumentGenerator
    {
        public DateTime now = DateTime.Now;

        public void CreateContract(
                DateTime contractDate, string clientName, string clientINN, string clientAdres, string CurrentAccount, string bik, string ks, string name, string outputPath, string product, int amount, double price, double result)
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

                //товар
                document.ReplaceText("{{product}}", product);
                //количество
                document.ReplaceText("{{amount}}", amount.ToString());
                //цена
                document.ReplaceText("{{price}}", price.ToString());
                //сумма
                document.ReplaceText("{{result}}", result.ToString());

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
           DateTime contractDate, string clientName, string clientINN, string clientAdres, string CurrentAccount, string bik, string ks, string name, string outputPath, string product, int amount, double price, double result)
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
                //товар
                document.ReplaceText("{{product}}", product);
                //количество
                document.ReplaceText("{{amount}}", amount.ToString());
                //цена
                document.ReplaceText("{{price}}", price.ToString());
                //сумма
                document.ReplaceText("{{result}}", result.ToString());


                // Сохранение заполненного документа
                document.SaveAs(outputPath);
            }
        }


    }
}
