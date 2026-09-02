using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class LobbyCompositionRoot
{
    private const string LobbyViewAddressableKey = "LobbyView";
    private const string HeroCatalogAddressableKey = "HeroCatalog";
    private const string HeroSelectionViewAddressableKey = "HeroSelectionView";

    private readonly GameService gameService;

    private LobbyController lobbyController;
    private HeroSelectionController heroSelectionController;
    private HeroCatalogSO HeroCatalogSO;

    private IHeroDataRepository heroDataRepository;
    private IStageDataRepository stageRepository;

    private LobbyView lobbyView;
    private HeroSelectionView heroSelectionView;

    public LobbyCompositionRoot(GameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task InitializeAsync()
    {
        CreateRepositories();

        lobbyView = await CreateLobbyViewAsync();

        lobbyController = new LobbyController(gameService, lobbyView, heroDataRepository, stageRepository);

        await lobbyController.InitializeAsync();

        await InitializeHeroSelectionAsync();
    }

    private async Task<LobbyView> CreateLobbyViewAsync()
    {
        GameObject viewObject = await gameService.AddressableService.InstantiateAsync(LobbyViewAddressableKey);

        LobbyView lobbyView = viewObject.GetComponent<LobbyView>();

        if (lobbyView == null)
        {
            Debug.Log("로비 뷰 어드레서블 확인 필요");
        }

        return lobbyView;
    }

    private void CreateRepositories()
    {
        heroDataRepository = new HeroDataRepository(gameService.AddressableService);
        stageRepository = new StageDataRepository(gameService.AddressableService);
    }

    public void Dispose()
    {
        heroDataRepository?.ClearCache();
        stageRepository?.ClearCache();

        if ( lobbyView != null)
        {
            gameService.AddressableService.ReleaseInstance(lobbyView.gameObject);

            lobbyView = null;
        }

        lobbyController = null;
    }

    private async Task InitializeHeroSelectionAsync()
    {
        HeroCatalogSO catalogSO = await gameService.AddressableService.LoadAssetAsync<HeroCatalogSO>(HeroCatalogAddressableKey);
        HeroCatalog catalog = new HeroCatalog(catalogSO);

        HeroSelectionView view = await CreateViewAsync();

        heroSelectionController = new HeroSelectionController(catalog, heroDataRepository, gameService.SaveService, view);

        await heroSelectionController.InitializeAsync();
    }

    private async Task<HeroSelectionView> CreateViewAsync()
    {
        GameObject instance = await gameService.AddressableService.InstantiateAsync(HeroSelectionViewAddressableKey);

        HeroSelectionView view = instance.GetComponent<HeroSelectionView>();

        if (view == null)
        {
            Debug.Log("뷰가 없음");
        }

        return view;
    }


}
