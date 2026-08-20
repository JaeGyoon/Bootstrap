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

        LoadState();

        BindButtons();
    }

    private void BindButtons()
    {
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

    private void LoadState()
    {
        PlayerSaveData playerSaveData = gameService.SaveService.CurrentSaveData;

        lobbyView.SetHeroName(playerSaveData.selectedHeroID);
        lobbyView.SetStageName(playerSaveData.selectedStageID);
    }
}
