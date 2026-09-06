using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageCatalogSO", menuName = "Scriptable Objects/StageCatalogSO")]
public class StageCatalogSO : ScriptableObject
{
    [SerializeField] private List<string> stageIDs = new List<string>();

    public IReadOnlyList<string> StageIDs => stageIDs;
}
