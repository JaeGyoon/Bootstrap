using UnityEngine;

public sealed class GameService
{
    public IAddressableService AddressableService { get; }
    public ISaveService SaveService { get; }
    public ISceneLoader sceneLoader { get; }

    public GameService(IAddressableService addressable, ISaveService save, ISceneLoader scene)
    {
        AddressableService = addressable;
        SaveService = save;
        sceneLoader = scene;
    }
}
