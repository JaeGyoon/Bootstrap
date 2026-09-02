using System.Threading.Tasks;
using UnityEngine;

public class HeroSelectionCompositionRoot
{
    private readonly GameService gameService;
    private readonly IHeroDataRepository heroRepository;

    private HeroSelectionController controller;

    public HeroSelectionCompositionRoot(GameService gameService,IHeroDataRepository heroRepository)
    {
        this.gameService = gameService;
        this.heroRepository = heroRepository;
    }

    public async Task InitializeAsync()
    {
        HeroCatalogSO catalogSO = await gameService.AddressableService.LoadAssetAsync<HeroCatalogSO>("HeroCatalog");
        HeroCatalog catalog = new HeroCatalog(catalogSO);

        HeroSelectionView view = await CreateViewAsync();

        controller = new HeroSelectionController(catalog, heroRepository, gameService.SaveService, view);

        await controller.InitializeAsync();
    }

    private async Task<HeroSelectionView> CreateViewAsync()
    {
        GameObject instance = await gameService.AddressableService.InstantiateAsync("HeroSelectionView");

        HeroSelectionView view = instance.GetComponent<HeroSelectionView>();

        if ( view == null)
        {
            Debug.Log("뷰가 없음");
        }

        return view;
    }

}
