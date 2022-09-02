namespace LOS
{
    [Serializable]
    public class BasicData
    {
        public string? version { get; set; }
        public string? apiKey { get; set; }
        public string? lolClientLocation { get; set; }

        public string? defaultSummoner { get; set; }
        public List<SummonerData>? summonerData { get; set; }

        public BasicData(string version, string apiKey, string lolClientLocation)
        {
            this.version = version;
            this.apiKey = apiKey;
            this.lolClientLocation = lolClientLocation;
            summonerData = new List<SummonerData>();
        }

        public BasicData()
        {
            summonerData = new List<SummonerData>();
        }
    }
}
