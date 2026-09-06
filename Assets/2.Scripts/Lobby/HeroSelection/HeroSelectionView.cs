using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionView : MonoBehaviour, IHeroSelectionView
{
    private Action<string> heroSelectedAction;

    public void ShowHeros(IReadOnlyList<HeroSO> heros, string selectedHeroID)
    {
        foreach( HeroSO hero in heros )
        {
            CreateHeroEntry(hero, hero.ID == selectedHeroID);
        }
    }

    private void CreateHeroEntry(HeroSO hero, bool isSelected)
    {

    }

    public void SetSelectedHero(string heroID)
    {

    }

    public void SetHeroSelectedAction(Action<string> callback)
    {
        heroSelectedAction = callback;
    }

    private void OnHeroClicked(string heroID)
    {
        heroSelectedAction?.Invoke(heroID);
    }
}
