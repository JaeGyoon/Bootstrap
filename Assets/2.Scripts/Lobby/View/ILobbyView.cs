using System;
using UnityEngine;

public interface ILobbyView
{
    void Show();
    void Hide();

    void SetHeroName(string heroName);
    void SetStageName(string stageName);

    void SetGameStartBtnAction(Action action);
    void SetHeroSelectBtnAction(Action action);
    void SetStageSelectBtnAction(Action action);
}
