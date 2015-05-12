using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S9.Web.Helpers;
using S9.Web.Helpers.Extensoes;

namespace ArcoticWindowsService
{
    public static class ServiceLog
    {
        public static string errorDir = Environment.CurrentDirectory + @"Logs\Errors\";
        private static string eventsFileName = Environment.CurrentDirectory + @"Logs\Events.log";
        private static string taskFileName = Environment.CurrentDirectory + @"Logs\Tasks.log";
        private static StreamWriter sWriter;

        public static void SaveServiceEvent(string text)
        {
            Save(eventsFileName, text);
        }
        public static void SaveServiceTask(string text)
        {
            Save(taskFileName, text);
        }
        private static void Save(string fileName, string text)
        {
            sWriter = new StreamWriter(fileName, true);
            sWriter.WriteLine(DateTime.Now.ToString() + " - " + text);
            sWriter.Flush();
            sWriter.Close();
        }
    }
}
