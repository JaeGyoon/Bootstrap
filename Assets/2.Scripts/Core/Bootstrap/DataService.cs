using UnityEngine;

public sealed class DataService
{
    public IHeroDataRepository Hero { get; }

    public IStageDataRepository Stage { get; }

    public DataService(IHeroDataRepository hero, IStageDataRepository stage)
    {
        Hero = hero;
        Stage = stage;
    }
}
