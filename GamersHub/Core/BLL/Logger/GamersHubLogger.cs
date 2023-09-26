using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.BLL.Logger
{
    public enum LogType
    {
        Insert,
        Update,
        Delete,
        Select,
        Error,
        Warning,
        NotFound,
        NonValidation

    }
    public static class GamersHubLogger
    {
        public static void AddLog(string message,LogType logType)
        {
            FileStream fs = new FileStream("GamersHubLogs.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("Hata Zamanı : "+DateTime.Now+" Hata Mesajı : "+message+" Log Tipi : "+logType);
            sw.Flush();
            sw.Close();
        }
    }
}
