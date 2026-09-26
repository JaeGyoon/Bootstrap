using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class LobbyCompositionRoot
{

    //private const string LobbyViewAddressableKey = "LobbyView";

    private const string HeroCatalogAddressableKey = "HeroCatalog";
    private const string HeroSelectionViewAddressableKey = "HeroSelectionView";

    private const string StageCatalogAddressableKey = "StageCatalog";
    private const string StageSelectionViewAddressableKey = "StageSelectionView";

    private readonly GameService gameService;

    private IHeroDataRepository heroDataRepository;
    private IStageDataRepository stageDataRepository;

    private readonly Transform canvasTransform;
    private LobbyController lobbyController;
    private LobbyView lobbyView;

    private HeroSelectionController heroSelectionController;
    private HeroCatalogSO HeroCatalogSO;
    private GameObject heroSelectionView;

    private StageSelectionController StageSelectionController;
    private StageCatalogSO StageCatalogSO;
    private GameObject stageSelectionView;

    public LobbyCompositionRoot(GameService gameService, IHeroDataRepository hero, IStageDataRepository stage, Transform canvas, LobbyView lobbyView)
    {
        this.gameService = gameService;
        heroDataRepository = hero;
        stageDataRepository = stage;
        canvasTransform = canvas;
        this.lobbyView = lobbyView;
    }

    public async Task InitializeAsync()
    {
        await InitializeHeroSelectionAsync();
        await InitializeStageSelectionAsync();

        lobbyController = new LobbyController(gameService, heroDataRepository, stageDataRepository,lobbyView, heroSelectionView, stageSelectionView);

        await lobbyController.InitializeAsync();

        

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

        heroSelectionView.transform.SetParent(canvasTransform, false);
        heroSelectionView.SetActive(false);
        
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

        stageSelectionView.transform.SetParent(canvasTransform, false);
        stageSelectionView.SetActive(false);

        return view;
    }



}
