using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableService : IAddressableService
{
    public async Task InitializeAsync()
    {
        AsyncOperationHandle handle = Addressables.InitializeAsync();

        await handle.Task;
    }

    public async Task<T> LoadAssetAsync<T>(string key) where T : Object
    {
        AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(key);

        T asset = await handle.Task;
                
        return asset;
    }

    public async Task<GameObject> InstantiateAsync(string key)
    {
        AsyncOperationHandle<GameObject> handle = Addressables.InstantiateAsync(key);

        GameObject instance = await handle.Task;

        Debug.Log($"어드레서블 오브젝트 생성 : {instance.name}");

        return instance;
    }    

    public void Release<T>(T asset) where T : Object
    {
        if ( asset == null )
        {
            return;
        }

        Addressables.Release(asset);
    }

    public void ReleaseInstance(GameObject instance)
    {
        if ( instance == null )
        {
            return;
        }

        Addressables.ReleaseInstance(instance);
    }
    
}
