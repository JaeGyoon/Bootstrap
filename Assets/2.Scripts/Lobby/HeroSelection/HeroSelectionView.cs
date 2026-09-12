using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroSelectionView : MonoBehaviour, IHeroSelectionView
{
    private Action<string> heroSelectedAction;

    [SerializeField] private HeroSelectionEntryView entryView;
    [SerializeField] private Transform entryRoot;

    private readonly List<HeroSelectionEntryView> entries = new List<HeroSelectionEntryView>();

    public void ShowHeros(IReadOnlyList<HeroSO> heros, string selectedHeroID)
    {
        ClearEntries();

        foreach ( HeroSO hero in heros )
        {
            CreateHeroEntry(hero, selectedHeroID);
        }
    }

    private void ClearEntries()
    {
        foreach(HeroSelectionEntryView entry in entries)
        {
            if ( entry != null )
            {
                Destroy(entry.gameObject);
            }
        }

        entries.Clear();
    }

    private void CreateHeroEntry(HeroSO heroSO, string selectedHeroID)
    {
        HeroSelectionEntryView entry = Instantiate(entryView, entryRoot);

        entry.gameObject.SetActive(true);

        entry.Initialize(heroSO, heroSO.ID == selectedHeroID, heroSelectedAction);

        entries.Add(entry);
    }

    public void SetSelectedHero(string heroID)
    {
        foreach (HeroSelectionEntryView entry in entries)
        {
            entry.SetSelected(entry.heroID == heroID);
        }
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
