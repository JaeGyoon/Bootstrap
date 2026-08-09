using System.Threading.Tasks;
using UnityEngine;

public interface IAddressableService
{
    Task InitializeAsync();

    Task<T> LoadAssetAsync<T>(string key) where T : Object;

    Task<GameObject> InstantiateAsync(string key);

    void Release<T>(T asset) where T : Object;

    void ReleaseInstance(GameObject instance);
}
