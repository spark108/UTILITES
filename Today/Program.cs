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

            if (args.Length > 0 && args[0].Length > 2 && args[0][0] == 'n' && int.TryParse(args[0].Substring(2), out int n))
            {
                if (args[0][1] == '+')
                {
                    dt = DateTime.Now.AddDays(n);
                }
                else if (args[0][1] == '-')
                {
                    dt = DateTime.Now.AddDays(-n);
                }
            }

            var dir = new DirectoryInfo(@$"{Environment.CurrentDirectory}\{dt.Year}\{dt.Month}.{getMonth(dt.Month)}\{dt.Day}");
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

        protected static string getMonth(int month)
        {
            switch (month)
            {
                case 1: return "ЯНВАРЬ";
                case 2: return "ФЕВРАЛЬ";
                case 3: return "МАРТ";
                case 4: return "АПРЕЛЬ";
                case 5: return "МАЙ";
                case 6: return "ИЮНЬ";
                case 7: return "ИЮЛЬ";
                case 8: return "АВГУСТ";
                case 9: return "СЕНТЯБРЬ";
                case 10: return "ОКТЯБРЬ";
                case 11: return "НОЯБРЬ";
                default: return "ДЕКАБРЬ";
            }
        }
    }
}