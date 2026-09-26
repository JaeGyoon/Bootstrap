using System.Threading.Tasks;
using UnityEngine;

public sealed class LobbyController
{
    private readonly GameService gameService;

    private readonly ILobbyView lobbyView;
    private readonly IHeroDataRepository heroDataRepository;
    private readonly IStageDataRepository stageDataRepository;

    private readonly GameObject heroSelectionObject;
    private readonly GameObject stageSelectionObject;

    public LobbyController(GameService gameService,
        IHeroDataRepository heroDataRepository,
        IStageDataRepository stageDataRepository,
        ILobbyView lobbyView, GameObject heroSelect,
        GameObject stageSelect)
    {
        this.gameService = gameService;
        this.heroDataRepository = heroDataRepository;
        this.stageDataRepository = stageDataRepository;
        this.lobbyView = lobbyView;
        heroSelectionObject = heroSelect;
        stageSelectionObject = stageSelect;
    }

    public async Task InitializeAsync()
    {
        BindButtons();

        lobbyView.Show();

        await LoadStateAsync();
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
        heroSelectionObject.SetActive(true);
        stageSelectionObject.SetActive(false);
    }

    private void OnStageSelectBtnClicked()
    {        
        heroSelectionObject.SetActive(false);
        stageSelectionObject.SetActive(true);
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
