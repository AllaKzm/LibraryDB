using System;
using System.Collections.Generic;

namespace LibraryDB.Models
{
    public partial class Genres
    {
        public Genres()
        {
            Books = new HashSet<Books>();
        }

        public long GenId { get; set; }
        public string GenTitle { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
