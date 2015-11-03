using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace OrdFyrirOrd.Interfaces
{
    public interface IReader
    {
        void MoveToContent();
        IReader Create(FileStream stream, XmlReaderSettings settings);
        IReader Create(string text, Source sourceType);
        void FormatSource(Source sourceType);
        void Create(JsonReader reader);
        bool Read();
        IReader GetReader();
    }
}
