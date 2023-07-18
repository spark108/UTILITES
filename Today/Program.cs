using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;

namespace Spark108.Today
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var defFormat = @"Y\m.M\d.m";
            var dt = DateTime.Now;

            foreach (var arg in args) 
            { 
                if (arg.StartsWith("n"))
                {
                    if (arg.Length > 2 && int.TryParse(args[0].Substring(2), out int n))
                    {
                        if (arg[1] == '+')
                        {
                            dt = DateTime.Now.AddDays(n);
                        }
                        else if (arg[1] == '-')
                        {
                            dt = DateTime.Now.AddDays(-n);
                        }
                    }
                }
                else if (arg.StartsWith("-format="))
                {
                    //var line = string.Join(" ", args);
                }
            }

            var path = defFormat.Replace("Y", dt.Year.ToString());
            path = path.Replace("M", getMonth(dt.Month));
            path = path.Replace("m", dt.Month.ToString());
            path = path.Replace("d", dt.Day.ToString());

            var dir = new DirectoryInfo(@$"{Environment.CurrentDirectory}\{path}");
            if (!dir.Exists) 
            {
                dir.Create();

                try
                {
                    var templateDir = new DirectoryInfo(@$"{Environment.CurrentDirectory}\template");
                    if (templateDir.Exists)
                    {
                        foreach (var templateCopyDir in GetDirectories(templateDir))
                        {
                            var newFullName = templateCopyDir.FullName
                                .Replace(templateDir.FullName, dir.FullName)
                                .Replace("%d%", dt.Day.ToString())
                                .Replace("%m%", dt.Month.ToString())
                                .Replace("%M%", getMonth(dt.Month))
                                .Replace("%Y%", dt.Year.ToString());

                            Directory.CreateDirectory(newFullName);
                        }

                        foreach (var templateCopyFile in GetFiles(templateDir))
                        {
                            var newFullName = templateCopyFile.FullName
                                .Replace(templateDir.FullName, dir.FullName)
                                .Replace("%d%", dt.Day.ToString())
                                .Replace("%m%", dt.Month.ToString())
                                .Replace("%M%", getMonth(dt.Month))
                                .Replace("%Y%", dt.Year.ToString());

                            File.Copy(templateCopyFile.FullName, newFullName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании дириктории из шаблона: {ex.Message}.", "Ошибка");
                }
            }

            var psi = new ProcessStartInfo() 
            { 
                FileName = "explorer",
                Arguments = $"\"{dir.FullName}\"",
                UseShellExecute = false
            };

            Process.Start(psi);
        }

        protected static DirectoryInfo[] GetDirectories(DirectoryInfo dir) 
        {
            List<DirectoryInfo> dirs = new();
            dirs.AddRange(dir.GetDirectories());

            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                dirs.AddRange(GetDirectories(dirInfo));
            }

            return dirs.ToArray();
        }

        protected static FileInfo[] GetFiles(DirectoryInfo dir)
        {
            List<FileInfo> files = new();
            files.AddRange(dir.GetFiles());

            foreach (DirectoryInfo dirInfo in dir.GetDirectories())
            {
                files.AddRange(GetFiles(dirInfo));
            }

            return files.ToArray();
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