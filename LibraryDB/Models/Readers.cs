using System;
using System.Collections.Generic;

namespace LibraryDB.Models
{
    public partial class Readers
    {
        public Readers()
        {
            IssuedBooks = new HashSet<IssuedBooks>();
        }

        public long ReadId { get; set; }
        public string Name { get; set; }
        public byte[] BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string PassportData { get; set; }

        public virtual ICollection<IssuedBooks> IssuedBooks { get; set; }
    }
}
