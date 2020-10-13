using System;
using System.Collections.Generic;

namespace LibraryDB.Models
{
    public partial class Publicist
    {
        public Publicist()
        {
            Books = new HashSet<Books>();
        }

        public long Id { get; set; }
        public string PublicistTitle { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
