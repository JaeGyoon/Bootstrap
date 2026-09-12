using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class LobbyCompositionRoot
{    
    private const string LobbyViewAddressableKey = "LobbyView";

    private const string HeroCatalogAddressableKey = "HeroCatalog";
    private const string HeroSelectionViewAddressableKey = "HeroSelectionView";

    private const string StageCatalogAddressableKey = "StageCatalog";
    private const string StageSelectionViewAddressableKey = "StageSelectionView";

    private readonly GameService gameService;

    private IHeroDataRepository heroDataRepository;
    private IStageDataRepository stageDataRepository;

    private LobbyController lobbyController;
    private HeroSelectionController heroSelectionController;
    private HeroCatalogSO HeroCatalogSO;
    private StageSelectionController StageSelectionController;
    private StageCatalogSO StageCatalogSO;

    private LobbyView lobbyView;
    private GameObject heroSelectionView;
    private GameObject stageSelectionView;

    public LobbyCompositionRoot(GameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task InitializeAsync()
    {
        CreateRepositories();

        lobbyView = await CreateLobbyViewAsync();

        lobbyController = new LobbyController(gameService, lobbyView, heroDataRepository, stageDataRepository);

        await lobbyController.InitializeAsync();

        await InitializeHeroSelectionAsync();
        await InitializeStageSelectionAsync();

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
        stageDataRepository = new StageDataRepository(gameService.AddressableService);
    }

    public void Dispose()
    {
        heroDataRepository?.ClearCache();
        stageDataRepository?.ClearCache();

        if ( lobbyView != null)
        {
            gameService.AddressableService.ReleaseInstance(lobbyView.gameObject);

            lobbyView = null;
        }

        lobbyController = null;

        gameService.AddressableService.ReleaseInstance(heroSelectionView);
        heroSelectionView = null;
        gameService.AddressableService.Release(HeroCatalogSO);
        HeroCatalogSO = null;

        gameService.AddressableService.ReleaseInstance(stageSelectionView);
        stageSelectionView = null;
        gameService.AddressableService.Release(StageCatalogSO);
        StageCatalogSO = null;
    }

    private async Task InitializeHeroSelectionAsync()
    {
        HeroCatalogSO catalogSO = await gameService.AddressableService.LoadAssetAsync<HeroCatalogSO>(HeroCatalogAddressableKey);
        HeroCatalog catalog = new HeroCatalog(catalogSO);

        HeroSelectionView view = await CreateHeroSelectionViewAsync();

        heroSelectionController = new HeroSelectionController(catalog, heroDataRepository, gameService.SaveService, view);

        await heroSelectionController.InitializeAsync();
    }

    private async Task InitializeStageSelectionAsync()
    {
        StageCatalogSO catalogSO = await gameService.AddressableService.LoadAssetAsync<StageCatalogSO>(StageCatalogAddressableKey);
        StageCatalog catalog = new StageCatalog(catalogSO);

        StageSelectionView view = await CreateStageSelectionViewAsync();

        StageSelectionController = new StageSelectionController(catalog, stageDataRepository, gameService.SaveService, view);

        await StageSelectionController.InitializeAsync();
    }

    private async Task<HeroSelectionView> CreateHeroSelectionViewAsync()
    {
        heroSelectionView = await gameService.AddressableService.InstantiateAsync(HeroSelectionViewAddressableKey);

        HeroSelectionView view = heroSelectionView.GetComponent<HeroSelectionView>();

        if (view == null)
        {
            Debug.Log("뷰가 없음");
        }

        return view;
    }

    private async Task<StageSelectionView> CreateStageSelectionViewAsync()
    {
        stageSelectionView = await gameService.AddressableService.InstantiateAsync(StageSelectionViewAddressableKey);

        StageSelectionView view = stageSelectionView.GetComponent<StageSelectionView>();

        if (view == null)
        {
            Debug.Log("뷰가 없음");
        }

        return view;
    }



}
