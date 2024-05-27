using FlowerClient.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowerClient.Additions
{
    internal class SaveHeaders // сохранение заголовков в файл
    {
        public static void SaveHeaderFieldsToFile(Header header, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(header.FingerPrint);
                writer.WriteLine(header.RefreshToken);
            }
        }
    }
}
