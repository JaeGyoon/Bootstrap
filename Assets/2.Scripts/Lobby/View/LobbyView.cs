using System;
using UnityEngine;

public class LobbyView : MonoBehaviour, ILobbyView
{
    [SerializeField] LobbyStateView stateView;
    [SerializeField] LobbyBtnView btnView;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetHeroName(string  heroName)
    {
        stateView.SetHeroName(heroName);
    }

    public void SetStageName(string stageName)
    {
        stateView.SetStageName(stageName);
    }

    public void SetGameStartBtnAction(Action action)
    {
        btnView.SetGameStartBtnAction(action);
    }

    public void SetHeroSelectBtnAction(Action action)
    {
        btnView.SetHeroSelectBtnAction(action);
    }

    public void SetStageSelectBtnAction(Action action)
    {
        btnView.SetStageSelectBtnAction(action);
    }

}
