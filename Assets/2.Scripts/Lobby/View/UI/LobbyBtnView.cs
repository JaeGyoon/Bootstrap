using System;
using UnityEngine;
using UnityEngine.UI;

public class LobbyBtnView : MonoBehaviour
{
    [SerializeField] private Button gameStartButton;
    [SerializeField] private Button heroSelectButton;
    [SerializeField] private Button stageSelectButton;

    public void SetGameStartBtnAction(Action action)
    {
        gameStartButton.onClick.RemoveAllListeners();
        gameStartButton.onClick.AddListener(() => action());
    }

    public void SetHeroSelectBtnAction(Action action)
    {
        heroSelectButton.onClick.RemoveAllListeners();
        heroSelectButton.onClick.AddListener(() => action());
    }

    public void SetStageSelectBtnAction(Action action)
    {
        stageSelectButton.onClick.RemoveAllListeners();
        stageSelectButton.onClick.AddListener(() => action());
    }
}
