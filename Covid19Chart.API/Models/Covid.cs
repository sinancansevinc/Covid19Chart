using System;
using System.Collections.Generic;

namespace Covid19Chart.API.Models
{
    public partial class Covid
    {
        public int Id { get; set; }
        public int CaseCount { get; set; }
        public DateTime CovidDate { get; set; }
        public int CountryId { get; set; }
        public int DeathCount { get; set; }
        public int RecoverCount { get; set; }
    }
}
