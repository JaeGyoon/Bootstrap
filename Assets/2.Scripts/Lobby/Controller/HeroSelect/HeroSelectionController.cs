using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public sealed class HeroSelectionController
{
    private readonly HeroCatalog heroCatalog;
    private readonly IHeroDataRepository heroDataRepository;
    private readonly ISaveService saveService;
    private readonly IHeroSelectionView heroSelectionView;

    private readonly List<HeroSO> loadedHeros = new List<HeroSO>();

    public HeroSelectionController(HeroCatalog catalog, IHeroDataRepository repository, ISaveService save, IHeroSelectionView view)
    {
        heroCatalog = catalog;
        heroDataRepository = repository;
        saveService = save;
        heroSelectionView = view;
    }

    public async Task InitializeAsync()
    {
        IReadOnlyList<string> heroIDs = heroCatalog.GetHeroIDs();

        foreach(string heroID in heroIDs)
        {
            HeroSO so = await heroDataRepository.LoadAsync(heroID);

            loadedHeros.Add(so);
        }

        heroSelectionView.ShowHeros(loadedHeros, saveService.CurrentSaveData.selectedHeroID);

        BindEvents();
    }

    private void BindEvents()
    {
        heroSelectionView.SetHeroSelectedAction(OnHeroSelected);
    }

    private void OnHeroSelected(string heroID)
    {
        saveService.CurrentSaveData.selectedHeroID = heroID;

        saveService.MarkDirty();

        heroSelectionView.SetSelectedHero(heroID);
    }
}
