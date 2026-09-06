using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class StageSelectionView : MonoBehaviour, IStageSelectionView
{
    private Action<string> stageSelectedAction;

    public void ShowStages(IReadOnlyList<StageSO> stages, string selectedStageID)
    {
        foreach (StageSO stage in stages)
        {
            CreateStageEntry(stage, stage.ID == selectedStageID);
        }
    }

    private void CreateStageEntry(StageSO stage, bool isSelected)
    {

    }

    public void SetSelectedStage(string stageID)
    {

    }

    public void SetStageSelectedAction(Action<string> callback)
    {
        stageSelectedAction = callback;
    }

    private void OnStageClicked(string stageID)
    {
        stageSelectedAction?.Invoke(stageID);
    }
}
