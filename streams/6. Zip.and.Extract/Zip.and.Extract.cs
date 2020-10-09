using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip.and.Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("d:/temp", "d:/system/out.zip", CompressionLevel.Optimal, false);
            ZipFile.ExtractToDirectory("d:/system/out.zip", "d:/temp1/");
        }
    }
}
