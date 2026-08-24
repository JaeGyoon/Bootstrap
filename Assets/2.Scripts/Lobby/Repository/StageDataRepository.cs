using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class StageDataRepository : IStageDataRepository
{
    private readonly IAddressableService addressableService;

    private readonly Dictionary<string, StageSO> cache = new Dictionary<string, StageSO>();
    public StageDataRepository(IAddressableService addressable)
    {
        addressableService = addressable;
    }

    public async Task<StageSO> LoadAsync(string id)
    {
        if (cache.TryGetValue(id, out StageSO cacheData))
        {
            return cacheData;
        }


        StageSO data = await addressableService.LoadAssetAsync<StageSO>(id);

        cache.Add(id, data);

        return data;
    }

    public void ClearCache()
    {
        foreach (StageSO data in cache.Values)
        {
            addressableService.Release(data);
        }

        cache.Clear();
    }
}
