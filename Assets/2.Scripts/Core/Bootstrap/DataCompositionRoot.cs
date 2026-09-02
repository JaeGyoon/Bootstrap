using UnityEngine;

public class DataCompositionRoot
{
    private readonly IAddressableService addressable;

    public DataCompositionRoot(IAddressableService addressableService)
    {
        addressable = addressableService;
    }

    public DataService Build()
    {
        IHeroDataRepository heroRepository = new HeroDataRepository(addressable);

        IStageDataRepository stageRepository = new StageDataRepository(addressable);

        return new DataService(heroRepository, stageRepository);
    }

}
