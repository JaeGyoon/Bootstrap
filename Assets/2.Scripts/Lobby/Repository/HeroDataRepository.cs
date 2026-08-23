using System.Threading.Tasks;
using UnityEngine;

public sealed class HeroDataRepository : IHeroDataRepository
{
    private readonly IAddressableService addressableService;

    public HeroDataRepository(IAddressableService addressable)
    {
        addressableService = addressable;
    }

    public async Task<HeroSO> LoadAsync(string id)
    {
        HeroSO so = await addressableService.LoadAssetAsync<HeroSO>(id);

        return so;
    }
}
