using UnityEngine;
using System.Threading.Tasks;

public class LobbyCompositionRoot
{
    private const string LobbyViewAddressableKey = "LobbyView";

    private GameService gameService;
    private LobbyController lobbyController;

    public LobbyCompositionRoot(GameService gameService)
    {
        this.gameService = gameService;
    }

    public async Task InitializeAsync()
    {
        LobbyView lobbyView = await CreateLobbyViewAsync();

        lobbyController = new LobbyController(gameService, lobbyView);

        lobbyController.Initialize();
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
}
