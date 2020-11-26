using System;
using System.Collections.Generic;

namespace QuickMemoConverter
{
    class Memo
    {
        public List<string> Memos { get; set; }

        public string CreatedDate { get; set; }

        public string Account { get; set; }

        public string Category { get; set; }

        public Memo(List<string> memos, string createdDate, string account, string category)
        {
            Memos = memos;
            CreatedDate = createdDate;
            Account = account;
            Category = category;
        }
    }
}
