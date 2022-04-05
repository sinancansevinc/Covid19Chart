using System;
using System.Collections.Generic;

namespace Covid19Chart.API.Models
{
    public partial class Covid
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public DateTime CovidDate { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
    }
}
