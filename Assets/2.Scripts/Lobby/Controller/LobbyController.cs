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

        lobbyView.SetHeroName("No Hero");
        lobbyView.SetStageName("No Stage");

        lobbyView.SetGameStartBtnAction(OnGameStartBtnClicked);
        lobbyView.SetHeroSelectBtnAction(OnHeroSelectBtnClicked);
        lobbyView.SetStageSelectBtnAction(OnStageSelectBtnClicked);
    }

    private void OnGameStartBtnClicked()
    {

    }

    private void OnHeroSelectBtnClicked()
    {

    }

    private void OnStageSelectBtnClicked()
    {

    }
}
