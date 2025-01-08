using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xceed.Words.NET;

namespace ConsoleApp1
{
        internal static class Replacedata
            {
        
        public static void FillTemplate(Dictionary<string, string> placeholders)
        {
            // получаем путь к папке с файломи шаблонов
            string filePath = @"D:\c++\1\bin\Debug\TemplateDocuments";
            var templatePath = Directory.GetFiles(filePath);
            // создаём путь к папке с готовыми документами
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string outputDirectory = Path.Combine(documentsPath, "Proba100");
            // проверяем папку на наличие 
            DirectoryInfo directoryInfo = new DirectoryInfo(outputDirectory);
            if (!directoryInfo.Exists) { directoryInfo.Create(); }


            // перебираем папку с шаблонами
            foreach (var tPath in templatePath)
                {
                // определяем файл для изменения по шаблону
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileName(tPath));
                // открываем файл для изменения
                    using (DocX document = DocX.Load(tPath))
                    {
                    // перебираем ключи для замены
                        foreach (var placeholder in placeholders)
                        {
                            document.ReplaceText(placeholder.Key, placeholder.Value);
                        }
                        document.SaveAs(outputPath);
                    }
                }
            }
                    
    }
}
