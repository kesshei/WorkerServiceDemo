using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceDemo
{
    internal class Log
    {
        public static readonly string LogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        public static object Lock = new object();
        static Log()
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
        }
        public static void Info(string msg)
        {
            var MSG = $"{DateTime.Now} - 消息: {msg}";
            Console.WriteLine(MSG);
            Write(MSG);
        }
        public static void Error(Exception ex, string msg = null)
        {
            var MSGMARK = msg == null ? "" : $"- 消息: {msg}";
            var MSG = $"{DateTime.Now}  - 异常: {ex.Message + ex.StackTrace} {MSGMARK}";
            Console.WriteLine(MSG);
            Write(MSG);
        }
        private static void Write(string msg)
        {
            lock (Lock)
            {
                File.AppendAllLines(Path.Combine(LogPath, $"{DateTime.Now.ToString("yyyyMMdd")}_log.txt"), new List<string>() { msg });
            }
        }
    }
}
