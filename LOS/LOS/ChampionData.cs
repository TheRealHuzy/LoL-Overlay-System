namespace LOS
{
    [Serializable]
    internal class ChampionData
    {
        public long id;
        public string name;
        public long level;
        public bool chestAquired;

        public ChampionData(long id, string name, long level = 0, bool chestAquired = false)
        {
            this.id = id;
            this.name = name;
            this.level = level;
            this.chestAquired = chestAquired;
        }
    }
}
