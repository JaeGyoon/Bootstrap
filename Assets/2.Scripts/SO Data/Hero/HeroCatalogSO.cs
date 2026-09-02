using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeroCatalogSO", menuName = "Scriptable Objects/HeroCatalogSO")]
public sealed class HeroCatalogSO : ScriptableObject
{
    [SerializeField] private List<string> heroIDs = new List<string>();

    public IReadOnlyList<string> HeroIDs => heroIDs;
}
