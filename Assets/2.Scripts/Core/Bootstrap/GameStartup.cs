using System.Threading.Tasks;
using UnityEngine;

public sealed class GameStartup
{
    private GameCompositionRoot gameCompositionRoot;
    private LobbyCompositionRoot lobbyCompositionRoot;
    
    public async Task StartAsync()
    {
        gameCompositionRoot = new GameCompositionRoot();
        await gameCompositionRoot.InitializeAsync();

        await gameCompositionRoot.GameService.sceneLoader.LoadSceneAsync(SceneName.Lobby);

        Debug.Log("Lobby Scene 이동");

        LobbySceneRoot lobbySceneRoot = UnityEngine.Object.FindFirstObjectByType<LobbySceneRoot>();

        LobbyView lobbyView = lobbySceneRoot.GetComponentInChildren<LobbyView>();

        lobbyCompositionRoot = new LobbyCompositionRoot(
            gameCompositionRoot.GameService,
            gameCompositionRoot.HeroDataRepository,
            gameCompositionRoot.StageDataRepository,
            lobbySceneRoot.CanvasTransform,
            lobbyView);

        await lobbyCompositionRoot.InitializeAsync();
    }

    public void Dispose()
    {
        lobbyCompositionRoot?.Dispose();
        gameCompositionRoot?.Dispose();

        lobbyCompositionRoot = null;
        gameCompositionRoot = null;
    }
}
