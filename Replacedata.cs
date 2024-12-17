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
        internal class Replacedata
            {
                        public void FillTemplate(Dictionary<string, string> placeholders)
        {
            List<string> templatePath = new List<string>
                { "Договор Поставки.docx", "Накладная_ТОРГ-12.docx", "счёт шаблон.docx"};
            string outputDirectory = "D:\\document\\";

            foreach (var tPath in templatePath)
            {
                string outputPath = Path.Combine(outputDirectory, Path.GetFileName(tPath));

                using (DocX document = DocX.Load(tPath))
                {
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
