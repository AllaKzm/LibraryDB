using System;
using System.Collections.Generic;

namespace LibraryDB.Models
{
    public partial class Positions
    {
        public Positions()
        {
            Employee = new HashSet<Employee>();
        }

        public long Id { get; set; }
        public string PositionTitle { get; set; }
        public double Salary { get; set; }
        public string Duties { get; set; }
        public string Demands { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
