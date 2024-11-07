using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Abstracts
{
    public static class ZipUtils
    {
        public static byte[] NewZip(Dictionary<string, Stream> entries)
        {
            var outputStream = new MemoryStream();

            using (var zip = new ZipFile())
            {
                foreach(var e in entries)
                {
                    zip.AddEntry(e.Key, e.Value);
                }

                zip.Save(outputStream);
            }

            outputStream.Position = 0;
            return outputStream.ToArray();
        }
    }
}
