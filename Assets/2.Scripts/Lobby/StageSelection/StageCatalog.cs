using System.Collections.Generic;
using UnityEngine;

public sealed class StageCatalog
{
    private readonly StageCatalogSO catalogSO;

    public StageCatalog(StageCatalogSO catalogSO)
    {
        this.catalogSO = catalogSO;
    }

    public IReadOnlyList<string> GetStageIDs()
    {
        return catalogSO.StageIDs;
    }
}
