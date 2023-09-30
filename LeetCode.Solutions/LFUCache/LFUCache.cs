namespace LeetCode.Solutions.LFUCache;

public class LFUCache
{
    public class CacheItem
    {
        public int Value { get; set; }
        public int Frequency { get; set; } = 0;
        public DateTimeOffset LastUsed { get; set; } = DateTimeOffset.UtcNow;

        public CacheItem(int val)
        {
            Value = val;
        }

        public void UpdateUsage()
        {
            Frequency++;
            LastUsed = DateTimeOffset.UtcNow;
        }
        
    }

    public int Capacity;
    public Dictionary<int, CacheItem> CachedItems = new ();
    private bool CanInsert => Capacity > CachedItems.Count;
    
    
    public LFUCache(int capacity)
    {
        Capacity = capacity;
    }
    
    public int Get(int key)
    {
        var itemExists = CachedItems.TryGetValue(key, out var item);

        if (!itemExists) 
            return -1;
        
        item.UpdateUsage();
        return item.Value;

    }
    
    public void Put(int key, int value)
    {
        if (!CanInsert && !CachedItems.TryGetValue(key, out _))
        {
            var keyToRemove = GetLeastUsedKey();
            if (!CachedItems.Remove(keyToRemove))
                return;
        }

        var itemExists = CachedItems.TryGetValue(key, out var existingItem);

        if (!itemExists || existingItem == null)
            existingItem = new CacheItem(value);

        existingItem.Value = value;
        existingItem.UpdateUsage();

        CachedItems.TryAdd(key, existingItem);
    }

    public int GetLeastUsedKey()
    {
        var minFrequency =CachedItems
            .Select(x => x.Value.Frequency)
            .DefaultIfEmpty()
            .Min();

        if (minFrequency == default)
            return -1;
        
        return CachedItems
            .Where(x => x.Value.Frequency == minFrequency)
            .MinBy(x => x.Value.LastUsed)
            .Key;
    }
}