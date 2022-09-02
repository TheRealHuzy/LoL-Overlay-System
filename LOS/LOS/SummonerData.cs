namespace LOS
{
    public class SummonerData
    {
        public string? summonerId { get; set; }
        public string? summonerName { get; set; }

        public SummonerData(string? summonerId, string? summonerName)
        {
            this.summonerId = summonerId;
            this.summonerName = summonerName;
        }
    }
}