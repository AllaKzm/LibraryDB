using System;
using System.Collections.Generic;

namespace LibraryDB.Models
{
    public partial class Books
    {
        public Books()
        {
            IssuedBooks = new HashSet<IssuedBooks>();
        }

        public long BookId { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public DateTime PubYear { get; set; }
        public long GenId { get; set; }
        public long Id { get; set; }

        public virtual Genres Gen { get; set; }
        public virtual Publicist IdNavigation { get; set; }
        public virtual ICollection<IssuedBooks> IssuedBooks { get; set; }
    }
}
