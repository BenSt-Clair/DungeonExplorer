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
    interface IInteract
    {
        public void StashItem()
        {
            return;
        }
        
    }
    interface IHasStats
    {
        public int DisplayStamina()
        {
            return 0;
        }
        
    }
}
