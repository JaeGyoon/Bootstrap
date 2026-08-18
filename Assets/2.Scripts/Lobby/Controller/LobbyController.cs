using UnityEngine;

public sealed class LobbyController
{
    private readonly GameService gameService;
    private readonly ILobbyView lobbyView;

    public LobbyController(GameService gameService, ILobbyView lobbyView)
    {
        this.gameService = gameService;
        this.lobbyView = lobbyView;
    }

    public void Initialize()
    {
        lobbyView.Show();
    }
}
