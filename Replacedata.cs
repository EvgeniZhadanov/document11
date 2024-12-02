using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Words.NET;

namespace ConsoleApp1
{
    internal class Replacedata
    {
        public DateTime now = DateTime.Now;
        List<string> templatePath = new List<string>
        { "Договор Поставки.docx", "Накладная_ТОРГ-12.docx", "счёт шаблон.docx"};

        string outputDirectory = "D:\\document\\";

        public Replacedata(
            string counterparty, string director, string inn, string ogrn, string address, string currentaccount, string bik, string correspondentaccount, string bankname, String product, int amount, decimal price, decimal result)
        {
            foreach (string tamplepath in templatePath)
            {
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(tamplepath));

                using (DocX document = DocX.Load(tamplepath))
                {
                    // Замена заполнителей на реальные данные
                    //ввод номера договора
                    document.ReplaceText("{{ContractNumber}}", now.ToString("ddMMyyyy"));
                    //ввод даты договора
                    document.ReplaceText("{{ContractDate}}", now.ToString("dd.MM.yyyy"));
                    //ввод наименование контрагента
                    document.ReplaceText("{{ClientName}}", counterparty);
                    //ввод ИНН контрагента
                    document.ReplaceText("{{clientINN}}", inn);
                    //ввод ОГРН
                    document.ReplaceText("{{clientOGRN}}", ogrn);
                    //ввод адреса
                    document.ReplaceText("{{ClientAdres}}", address);
                    //ввод расчётного счёта
                    document.ReplaceText("{{CurrentAccount}}", currentaccount);
                    //ввод БИК банка
                    document.ReplaceText("{{bik}}", bik);
                    // ввод кор-счёта
                    document.ReplaceText("{{ks}}", correspondentaccount);
                    //имя банка
                    document.ReplaceText("{{name}}", bankname);
                    //ФИО уполномоченного лица
                    document.ReplaceText("{{clientFIO}}", director);

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
}
