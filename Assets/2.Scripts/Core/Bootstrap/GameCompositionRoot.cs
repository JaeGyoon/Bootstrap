using System.Threading.Tasks;
using UnityEngine;

public sealed class GameCompositionRoot
{
    private IAddressableService addressableService;
    private ISaveService saveService;
    private ISceneLoader sceneLoader;

    public async Task<GameService> InitializeAsync()
    {
        CreateServiceAsync();

        await InitializeServiceAsync();

        return new GameService(addressableService, saveService, sceneLoader);
    }

    private void CreateServiceAsync()
    {
        addressableService = new AddressableService();
        saveService = new JsonSaveService();
        sceneLoader = new SceneLoader();
    }

    private async Task InitializeServiceAsync()
    {        
        await addressableService.InitializeAsync();
        await saveService.InitializeAsync();

        Debug.Log("모든 서비스 생성 및 초기화 완료");
    }

    public async Task LoadInitialSceneAsync()
    {
        await sceneLoader.LoadSceneAsync(SceneName.Lobby);
    }


}
