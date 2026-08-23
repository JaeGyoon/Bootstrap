using UnityEngine;
using System.Threading.Tasks;

public class LobbyCompositionRoot
{
    private const string LobbyViewAddressableKey = "LobbyView";

    private readonly GameService gameService;
    private LobbyController lobbyController;
    private IHeroDataRepository heroDataRepository;
    private IStageDataRepository stageRepository;

    public LobbyCompositionRoot(GameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task InitializeAsync()
    {
        CreateRepositories();

        LobbyView lobbyView = await CreateLobbyViewAsync();

        lobbyController = new LobbyController(gameService, lobbyView, heroDataRepository, stageRepository);

        await lobbyController.InitializeAsync();
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
}
