using System;
using System.IO;
using System.Text;

namespace Server
{
    class Log
    {
        string filePath;

        public Log()
        {
            filePath = Directory.GetCurrentDirectory() + "\\logfile.txt";
            SaveMessage("------------------------------Starting log------------------------------");
        }


        public void SaveMessage(string msg)
        {
            string logMsg = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss:FFF]:") + msg;

            try
            { 
                using (StreamWriter file = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    file.WriteLine(logMsg);
                }
            }
            catch( Exception e)
            {
            }


            Console.WriteLine(logMsg);
        }

    }


}
