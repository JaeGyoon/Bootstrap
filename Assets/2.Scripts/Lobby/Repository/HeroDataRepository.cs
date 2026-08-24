using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public sealed class HeroDataRepository : IHeroDataRepository
{
    private readonly IAddressableService addressableService;

    private readonly Dictionary<string, HeroSO> cache = new Dictionary<string, HeroSO>();

    public HeroDataRepository(IAddressableService addressable)
    {
        addressableService = addressable;
    }

    public async Task<HeroSO> LoadAsync(string id)
    {        
        if (cache.TryGetValue(id, out HeroSO cacheData))
        {
            return cacheData;
        }

        HeroSO data = await addressableService.LoadAssetAsync<HeroSO>(id);

        cache.Add(id, data);

        return data;
    }

    public void ClearCache()
    {
        foreach (HeroSO data in cache.Values)
        {
            addressableService.Release(data);
        }

        cache.Clear();
    }
}
