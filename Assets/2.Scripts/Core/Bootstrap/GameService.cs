using System;
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

    public void Dispose()
    {
        if ( SaveService is IDisposable save)
        {
            save.Dispose();
        }

        if (AddressableService is IDisposable addressable)
        {
            addressable.Dispose();
        }

        if (sceneLoader is IDisposable scener)
        {
            scener.Dispose();
        }
    }
}
