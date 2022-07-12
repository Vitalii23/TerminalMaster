using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Storage;

namespace TerminalMaster.Logging
{
    class LogFile
    {
        public async Task WriteLogAsync(string message, string functionExp)
        {
            try
            {

                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile storageFile = await storageFolder.GetFileAsync("log.txt");
                await FileIO.WriteTextAsync(storageFile, "Swift as a shadow");
                if (!File.Exists("./log.txt"))
                {
                    
                    //using (StreamWriter writer = File.AppendText(storageFile.get))
                    //{
                    //    writer.Write("\r\nDate: ");
                    //    writer.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                    //    writer.Write("Void: ");
                    //    writer.WriteLine($"{functionExp}");
                    //    writer.WriteLine($"{message}");
                    //    writer.Write("------------------");
                    //    MessageDialog dialog = new MessageDialog("Ошибка программы: " + message);
                    //}
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        public void ReaderLog(StreamReader reader)
        {
            while ((_ = reader.ReadLine()) != null)
            {

            }
        }
    }
}
