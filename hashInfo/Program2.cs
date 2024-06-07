using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace hashInfo
{
    internal class Program2
    {

        public static string GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

            return Convert.ToBase64String(hash);
        }

        static void Main(string[] args)
        {
            string path = "C:\\Users\\Anton\\source\\repos\\first_product_lab1\\first_product_lab1\\passwords.txt";
            FileInfo fileInfo = new FileInfo(path);

            StreamWriter writer = fileInfo.CreateText();

            writer.WriteLine(GetHash("iamtheboss123" + "admin"));
            writer.WriteLine(GetHash("very3strong2pass1word" + "admin"));
            writer.WriteLine(GetHash("12345" + "admin"));

            writer.Close();
        }
    }
}
