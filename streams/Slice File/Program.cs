﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Slice_File
{
    class Program
    {
        static void Main(string[] args)
        {
            

            int parts = 4;

            List<string> files = new List<string> { "Part-1.txt", "Part-2.txt ", "Part-3.txt ", "Part-4.txt" };

            using (var streamReadFile = new FileStream("../../../SliceMe.txt",FileMode.Open))
            {

                long pieceSize = (long)Math.Ceiling((double)streamReadFile.Length / parts);

                for (int i = 0; i < parts; i++)
                {

                    long currentPieceSize = 0;

                    using (var streamCreateFile = new FileStream(files[i], FileMode.Create))
                    {

                        byte[] buffer = new byte[4096];

                        while ((streamReadFile.Read(buffer, 0, buffer.Length)) == buffer.Length)
                        {

                            currentPieceSize += buffer.Length;
                            streamCreateFile.Write(buffer, 0, buffer.Length);

                            if (currentPieceSize >= pieceSize) 
                            {
                                break; 
                            }

                        }

                    }

                }
            }
        }
    }
}
