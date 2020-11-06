using System;
using System.Collections.Generic;

namespace LibraryDB.Models
{
    public partial class Employee
    {
        public Employee()
        {
            IssuedBooks = new HashSet<IssuedBooks>();
        }

        public long EmpId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Id { get; set; }

        public virtual Positions IdNavigation { get; set; }
        public virtual ICollection<IssuedBooks> IssuedBooks { get; set; }
    }
}
