namespace DungeonCrawler
{
    /// <summary>
    /// interface allows monsters to inherit an attack capability that doesn't require
    /// them to have weapons.
    /// </summary>
    interface INotSoCute
    {
        public int Attack()
        {
            return 0;
        }

    }
}
