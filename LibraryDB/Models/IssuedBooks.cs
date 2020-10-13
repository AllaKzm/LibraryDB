using System;
using System.Collections.Generic;

namespace LibraryDB.Models
{
    public partial class IssuedBooks
    {
        public byte[] IssueDate { get; set; }
        public byte[] ReturnDate { get; set; }
        public string ReturnMark { get; set; }
        public long EmpId { get; set; }
        public long ReadId { get; set; }
        public long BookId { get; set; }

        public virtual Books Book { get; set; }
        public virtual Employee Emp { get; set; }
        public virtual Readers Read { get; set; }
    }
}
