using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace QuickMemoConverter
{
    class FileParser
    {
        public Memo ParseDirectoryToMemo(string unzippedFolder)
        {
            DirectoryInfo directory = new DirectoryInfo(unzippedFolder);

            var memoFilePath = directory.GetFiles("*.jlqm").FirstOrDefault().FullName;

            Console.WriteLine(memoFilePath);

            // if(File.Exists(memoFilePath))
            {
                
                string note = File.ReadAllText(memoFilePath);

                using (JsonDocument document = JsonDocument.Parse(note))
                {
                    var memos = new List<string>();

                    JsonElement root = document.RootElement;

                    JsonElement memoCategory = root.GetProperty("Category");
                    memoCategory.TryGetProperty("CategoryName",out JsonElement categoryElement);

                    JsonElement memoAccount = root.GetProperty("Category");
                    memoAccount.TryGetProperty("AccountName",out JsonElement accountElement);

                    JsonElement memoDate = root.GetProperty("Memo");
                    memoDate.TryGetProperty("CreatedTime",out JsonElement dateElement);

                    JsonElement memoContentList = root.GetProperty("MemoObjectList");

                    foreach (var memoContent in memoContentList.EnumerateArray())
                    {
                        if (memoContent.TryGetProperty("DescRaw",out JsonElement contentElement))
                        {
                        memos.Add(contentElement.ToString());
                        }
                    }

                    return new Memo(memos, dateElement.ToString(), accountElement.ToString(), categoryElement.ToString());
                }
            }
        }
    }
}