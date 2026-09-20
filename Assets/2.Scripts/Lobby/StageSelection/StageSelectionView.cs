using System;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public sealed class StageSelectionView : MonoBehaviour, IStageSelectionView
{
    private Action<string> stageSelectedAction;

    [SerializeField] private StageSelectionEntryView entryView;
    [SerializeField] private Transform entryRoot;

    private readonly List<StageSelectionEntryView> entries = new List<StageSelectionEntryView>();

    public void ShowStages(IReadOnlyList<StageSO> stages, string selectedStageID, IReadOnlyList<bool> unlockedStates)
    {
        ClearEntries();

        /*foreach (StageSO stage in stages)
        {
            CreateStageEntry(stage, selectedStageID);
        }*/

        for ( int i = 0; i < stages.Count; i++ )
        {
            CreateStageEntry(stages[i], selectedStageID, unlockedStates[i]);
        }
    }

    private void ClearEntries()
    {
        foreach (StageSelectionEntryView entry in entries)
        {
            if (entry != null)
            {
                Destroy(entry.gameObject);
            }
        }

        entries.Clear();
    }

    private void CreateStageEntry(StageSO stageSO, string selectedStageID, bool isUnlocked)
    {
        /*bool isUnlocked = (stageSO != null); */

        StageSelectionEntryView entry = Instantiate(entryView, entryRoot);

        entry.gameObject.SetActive(true);

        entry.Initialize(stageSO, stageSO.ID == selectedStageID, isUnlocked, stageSelectedAction);

        entries.Add(entry);
    }

    public void SetSelectedStage(string stageID)
    {
        foreach (StageSelectionEntryView entry in entries)
        {
            entry.SetSelected(entry.StageID == stageID);
        }
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
