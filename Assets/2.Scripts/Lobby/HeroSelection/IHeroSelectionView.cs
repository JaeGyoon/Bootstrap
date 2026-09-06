using System;
using System.Collections.Generic;
using UnityEngine;

public interface IHeroSelectionView
{
    void ShowHeros(IReadOnlyList<HeroSO> heros, string selectedHeroID);

    void SetSelectedHero(string heroID);

    void SetHeroSelectedAction(Action<string> callback);
}
