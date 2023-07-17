using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Spark108.Today
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var dt = DateTime.Now;

            if (args.Length > 0 && args[0].Length > 2 && args[0][0] == 'n' && (args[0][1] == '-' || args[0][1] == '+') && int.TryParse(args[0].Substring(2), out int n))
            {
                if (args[0][1] == '+')
                {
                    dt = DateTime.Now.AddDays(n);
                }
                else
                {
                    dt = DateTime.Now.AddDays(-n);
                }
            }

            string month = "";
            switch (dt.Month)
            {
                case 1: month = "ЯНВАРЬ"; break;
                case 2: month = "ФЕВРАЛЬ"; break;
                case 3: month = "МАРТ"; break;
                case 4: month = "АПРЕЛЬ"; break;
                case 5: month = "МАЙ"; break;
                case 6: month = "ИЮНЬ"; break;
                case 7: month = "ИЮЛЬ"; break;
                case 8: month = "АВГУСТ"; break;
                case 9: month = "СЕНТЯБРЬ"; break;
                case 10: month = "ОКТЯБРЬ"; break;
                case 11: month = "НОЯБРЬ"; break;
                case 12: month = "ДЕКАБРЬ"; break;
            }

            var dir = new DirectoryInfo(@$"{Environment.CurrentDirectory}\{dt.Year}\{dt.Month}.{month}\{dt.Day}");
            if (!dir.Exists) 
            {
                dir.Create();
            }

            var psi = new ProcessStartInfo() 
            { 
                FileName = "explorer",
                Arguments = $"\"{dir.FullName}\"",
                UseShellExecute = false
            };

            Process.Start(psi);
        }
    }
}