using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OrdFyrirOrd
{
    public static class FileAccessorExtensions
    {
        public static void SaveEnumerableJson(this IEnumerable collection, string fileName, FileMode fileRights)
        {
            string path = Directory.GetCurrentDirectory();
            using (FileStream fs = File.Open(path + "/output/" + fileName, fileRights))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, collection);
            }
        }
    }
}
