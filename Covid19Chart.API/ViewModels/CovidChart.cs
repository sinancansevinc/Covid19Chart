namespace Covid19Chart.API.ViewModels
{
    public class CovidChart
    {
        public CovidChart()
        {
            Count = new List<int>();
        }
        
        public string CovidDate { get; set; }
        public List<int> Count { get; set; }

    }
}
