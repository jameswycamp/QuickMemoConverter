using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace QuickMemoConverter
{
    class FileHandler
    {
        public List<string> LqmToZip(string directoryPath)
        {
            var memoFiles = new List<string>();

            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            foreach (var file in directory.EnumerateFiles("*.lqm"))
            {
                var oldFileName = file.FullName;

                var newFileName = oldFileName.Replace("lqm","zip");

                memoFiles.Add(newFileName);

                File.Move(oldFileName, newFileName);
                // ZipFile.CreateFromDirectory(file.FullName, file.Directory.FullName);
            }

            return memoFiles;
        }

        public List<string> UnzipMemos(List<string> zipFilePaths)
        {
            var unzippedFolders = new List<string>();

            foreach(var zipFilePath in zipFilePaths)
            {
                var unzipPath = zipFilePath.Replace(".zip","/");

                ZipFile.ExtractToDirectory(zipFilePath, unzipPath);

                File.Delete(zipFilePath);

                unzippedFolders.Add(unzipPath);
            }

            return unzippedFolders;
        }
    }

}