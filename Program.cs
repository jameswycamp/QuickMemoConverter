using System;
using System.IO;
using System.Text.Json;

namespace QuickMemoConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string memofile = @"C:\temp\memoinfo.jlqm";

            if(File.Exists(memofile))
            {

                string note = File.ReadAllText(memofile);

                using (JsonDocument document = JsonDocument.Parse(note))
                {
                    JsonElement root = document.RootElement;

                    JsonElement memoCategory = root.GetProperty("Category");
                    memoCategory.TryGetProperty("CategoryName",out JsonElement categoryElement);

                    Console.WriteLine(categoryElement.ToString());

                    JsonElement memoContentList = root.GetProperty("MemoObjectList");

                    foreach (var memoContent in memoContentList.EnumerateArray())
                    {
                        if (memoContent.TryGetProperty("DescRaw",out JsonElement contentElement);)
                    }

                    
                    

                    Console.WriteLine(contentElement.ToString());
                }

                // Console.WriteLine(note);
            }
        }
    }
}
