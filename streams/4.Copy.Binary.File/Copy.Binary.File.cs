using System;
using System.IO;
using System.Security.Cryptography;

namespace _4.Copy.Binary.File
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream readImage = new FileStream("../../../CopyMe.png", FileMode.Open))
            {
                using (FileStream writeImage = new FileStream("../../../Result.png", FileMode.Create))
                {
                    byte[] buff = new byte[4096];

                    while (readImage.CanRead)
                    {
                        int readBytes = readImage.Read(buff, 0, buff.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }
                        writeImage.Write(buff, 0, buff.Length);
                    }
                }
            }
        }
    }
}
