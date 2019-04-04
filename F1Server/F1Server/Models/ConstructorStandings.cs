using System.Collections.Generic;

namespace ConstructorStandings
{

    public class Constructor
    {
        public string constructorId { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string nationality { get; set; }
    }

    public class ConstructorStanding
    {
        public string position { get; set; }
        public string positionText { get; set; }
        public string points { get; set; }
        public string wins { get; set; }
        public Constructor Constructor { get; set; }
    }

    public class StandingsList
    {
        public string season { get; set; }
        public string round { get; set; }
        public List<ConstructorStanding> ConstructorStandings { get; set; }
    }

    public class StandingsTable
    {
        public string season { get; set; }
        public List<StandingsList> StandingsLists { get; set; }
    }

    public class MRData
    {
        public string xmlns { get; set; }
        public string series { get; set; }
        public string url { get; set; }
        public string limit { get; set; }
        public string offset { get; set; }
        public string total { get; set; }
        public StandingsTable StandingsTable { get; set; }
    }

    public class ConstructorStandings
    {
        public MRData MRData { get; set; }
    }

}