using System;
using System.Collections.Generic;
using UnityEngine;

public interface IStageSelectionView
{
    void ShowStages(IReadOnlyList<StageSO> heros, string selectedStageID, IReadOnlyList<bool> unlockedStates);

    void SetSelectedStage(string stageID);

    void SetStageSelectedAction(Action<string> callback);
}
