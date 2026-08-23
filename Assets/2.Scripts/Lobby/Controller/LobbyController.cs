using System.Threading.Tasks;
using UnityEngine;

public sealed class LobbyController
{
    private readonly GameService gameService;

    private readonly ILobbyView lobbyView;
    private readonly IHeroDataRepository heroDataRepository;
    private readonly IStageDataRepository stageDataRepository;

    public LobbyController(GameService gameService, ILobbyView lobbyView, IHeroDataRepository heroRepository, IStageDataRepository stageRepository)
    {
        this.gameService = gameService;
        this.lobbyView = lobbyView;
        heroDataRepository = heroRepository;
        stageDataRepository = stageRepository;
    }

    public async Task InitializeAsync()
    {
        lobbyView.Show();

        await LoadStateAsync();

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

    private async Task LoadStateAsync()
    {
        PlayerSaveData playerSaveData = gameService.SaveService.CurrentSaveData;

        Debug.Log(playerSaveData.selectedHeroID);
        Debug.Log(playerSaveData.selectedStageID);

        HeroSO heroSO = await heroDataRepository.LoadAsync(playerSaveData.selectedHeroID);
        lobbyView.SetHeroName(heroSO.DisplayName);

        StageSO stageSO = await stageDataRepository.LoadAsync(playerSaveData.selectedStageID);
        lobbyView.SetStageName(stageSO.DisplayName);
    }
}
