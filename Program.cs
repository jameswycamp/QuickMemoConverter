using System;
using System.IO;
using System.Text.Json;

namespace QuickMemoConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // var memoDirectory = @"I:\test\";
            var memoDirectory = @"I:\test\QuickMemo+_201123_203959(4)";
            
            var fileHandler = new FileHandler();

            var fileParser = new FileParser();

            var memo = fileParser.ParseDirectoryToMemo(memoDirectory);

            Console.WriteLine(memo.Category);

            // var files = fileHandler.LqmToZip(memoDirectory);

            // var unzippedFolders =  fileHandler.UnzipMemos(files);

            // foreach(var f in unzippedFolders)
            // {
            //     Console.WriteLine(f);
            // }
        }
    }
}
