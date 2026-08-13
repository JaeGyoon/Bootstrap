using System.Threading.Tasks;
using UnityEngine;

public sealed class GameStartup
{
    private readonly GameCompositionRoot gameCompositionRoot;

    public GameStartup()
    {
        gameCompositionRoot = new GameCompositionRoot();
    }

    public async Task StartAsync()
    {
        GameService gameService = await gameCompositionRoot.InitializeAsync();

        await StartLobbyAsync(gameService);
    }

    private async Task StartLobbyAsync(GameService gameService)
    {
        await gameService.sceneLoader.LoadSceneAsync(SceneName.Lobby);

        Debug.Log("씬 이동 후 lobby Root 설정");

        LobbyCompositionRoot lobbyCompositionRoot = new LobbyCompositionRoot(gameService);

        lobbyCompositionRoot.Initialize();

        Debug.Log("씬 이동 후 lobby Root 설정 완료");
    }
}
