using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public sealed class StageSelectionController
{
    private readonly StageCatalog stageCatalog;
    private readonly IStageDataRepository stageDataRepository;
    private readonly ISaveService saveService;
    private readonly IStageSelectionView stsgeSelectionView;

    private readonly List<StageSO> loadedStages = new List<StageSO>();

    public StageSelectionController(StageCatalog catalog, IStageDataRepository repository, ISaveService save, IStageSelectionView view)
    {
        stageCatalog = catalog;
        stageDataRepository = repository;
        saveService = save;
        stsgeSelectionView = view;
    }


    public async Task InitializeAsync()
    {
        IReadOnlyList<string> StageIDs = stageCatalog.GetStageIDs();
        List<bool> unlockedStates = new();

        foreach (string StageID in StageIDs)
        {
            StageSO so = await stageDataRepository.LoadAsync(StageID);
            loadedStages.Add(so);

            //bool isUnlocked = saveService.CurrentSaveData.IsStageUnlocked(so.ID);
            bool isUnlocked = true;

            unlockedStates.Add(isUnlocked);
        }

        BindEvents();

        stsgeSelectionView.ShowStages(loadedStages, saveService.CurrentSaveData.selectedStageID, unlockedStates);

        
    }

    private void BindEvents()
    {
        stsgeSelectionView.SetStageSelectedAction(OnStageSelected);
    }

    private void OnStageSelected(string stageID)
    {        
        saveService.CurrentSaveData.selectedStageID = stageID;

        Debug.Log($"선택된 스테이지 : {saveService.CurrentSaveData.selectedStageID}");

        saveService.MarkDirty();

        stsgeSelectionView.SetSelectedStage(stageID);
    }

    private StageSO FindStage(string stageID)
    {
        foreach(StageSO stage in loadedStages)
        {
            if ( stage.ID == stageID )
            {
                return stage;
            }
        }

        return null;
    }

    
}
