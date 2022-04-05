using System;
using System.Collections.Generic;

namespace Covid19Chart.API.Models
{
    public partial class Country
    {
        public Country()
        {
            Covids = new HashSet<Covid>();
        }

        public int Id { get; set; }
        public string Country1 { get; set; } = null!;

        public virtual ICollection<Covid> Covids { get; set; }
    }
}
