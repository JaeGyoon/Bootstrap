using System.Collections.Generic;
using UnityEngine;

public sealed class HeroCatalog
{
    private readonly HeroCatalogSO catalogSO;

    public HeroCatalog(HeroCatalogSO catalogSO)
    {
        this.catalogSO = catalogSO;
    }

    public IReadOnlyList<string> GetHeroIDs()
    {
        return catalogSO.HeroIDs;
    }
}
