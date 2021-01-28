using System;
using System.IO;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine("data", "copyMe.png");
            var destination = Path.Combine("data", "copiedPNG.png");
            using (FileStream readStream = new FileStream(path, FileMode.Open))
            {
                using (FileStream writeStream = new FileStream(destination, FileMode.Create))
                {
                    while (true)
                    {
                        byte[] buffer = new byte[4096];
                        int count = readStream.Read(buffer, 0, buffer.Length);
                        if (count==0)
                        {
                            break;
                        }
                        writeStream.Write(buffer);
                    }
                }
            }
        }
    }
}