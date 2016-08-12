using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Cleaner
{
    class Program
    {
        public static void CleanFile(string srcPath, string dstPath, string[] badLines)
        {
            System.Console.WriteLine("Cleaning data within " + srcPath + "...");

            HashSet<string> hs = new HashSet<string>();
            string[] fileEntries = System.IO.Directory.GetFiles(srcPath);
            List<string> lines = new List<string>();

            foreach (string fileName in fileEntries)
                lines = System.IO.File.ReadAllLines(fileName).ToList<string>();
            foreach (string s in lines)
                if (!(badLines.Any(s.StartsWith)) && !(s == "\n"))
                    hs.Add(s);

            System.IO.File.WriteAllLines(dstPath, hs);
        }

        public static string GetFileName(string path)
        {
            string[] pathPieces = path.Split('\\');
            return pathPieces[pathPieces.Length - 1];
        }

        public static void Main(string[] args)
        {
            // common keywords shared among headers (that we don't want included)
            string[] badLines =
            {
                "ANHEUSER",
                "COPYRIGHT",
                "AUGUST",
                "FINAL",
                "AB WASHINGTON",
                "EUGENE",
                "****",
                "*****",
                "PAGE",
                "          "
            };

            string[] srcPaths = System.IO.Directory.GetDirectories(@"C:\Users\kjwkc3\Desktop\Rankers");
            string[] dstPaths = new string[srcPaths.Length];
            for (int i = 0; i < dstPaths.Length; i++)
            {
                dstPaths[i] = @"C:\Users\kjwkc3\Desktop\Rankers" + GetFileName(srcPaths[i]) + "_clean.txt";
            }

            for (int i = 0; i < srcPaths.Length; i++)
            {
                CleanFile(srcPaths[i], dstPaths[i], badLines);
            }

            System.Console.WriteLine("Cleaning Complete!");
            System.Console.ReadLine();
        }
    }
}
