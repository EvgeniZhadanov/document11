using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
        internal class Way
    {
        // передача пути программе к шаблонам из файла Settings
        public static string SettingsWay()
        {
            string occupation = ConfigurationManager.AppSettings["keyTemplate"];
            string path = String.Empty;
            using (StreamReader settingsStream = new StreamReader(occupation ))
            {
                string settingsRow = String.Empty;
                while (!settingsStream.EndOfStream)
                {
                    settingsRow = settingsStream.ReadLine();
string[] setting = settingsRow.Split('=');

                    if (setting[0] == "keyTemplate")
                    {
                        path = setting[1];
                    }
                }
            }
            return path;
        }
    
    }
}
