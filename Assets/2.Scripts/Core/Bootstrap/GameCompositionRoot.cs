using System.Threading.Tasks;
using UnityEngine;

public sealed class GameCompositionRoot
{    

    public GameService GameService { get; private set; }

    public IHeroDataRepository HeroDataRepository { get; private set; }
    public IStageDataRepository StageDataRepository { get; private set; }

    public async Task InitializeAsync()
    {
        CreateServiceAsync();
        CreateDataRepository();

        await InitializeServiceAsync();
    }

    private void CreateServiceAsync()
    {
        IAddressableService addressableService = new AddressableService();
        ISaveService saveService = new JsonSaveService();
        ISceneLoader sceneLoader = new SceneLoader();

        GameService = new GameService(addressableService, saveService, sceneLoader);
    }

    private void CreateDataRepository()
    {
        HeroDataRepository = new HeroDataRepository(GameService.AddressableService);
        StageDataRepository = new StageDataRepository(GameService.AddressableService);
    }

    private async Task InitializeServiceAsync()
    {        
        await GameService.AddressableService.InitializeAsync();
        await GameService.SaveService.InitializeAsync();

        Debug.Log("모든 서비스 생성 및 초기화 완료");
    }

    public void Dispose()
    {
        GameService.Dispose();
    }
   /* public async Task LoadInitialSceneAsync()
    {
        await sceneLoader.LoadSceneAsync(SceneName.Lobby);
    }*/


}
