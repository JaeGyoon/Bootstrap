using System.Threading.Tasks;
using UnityEngine;

public class StageDataRepository : IStageDataRepository
{
    private readonly IAddressableService addressableService;

    public StageDataRepository(IAddressableService addressable)
    {
        addressableService = addressable;
    }

    public async Task<StageSO> LoadAsync(string id)
    {
        StageSO so = await addressableService.LoadAssetAsync<StageSO>(id);

        return so;
    }
}
