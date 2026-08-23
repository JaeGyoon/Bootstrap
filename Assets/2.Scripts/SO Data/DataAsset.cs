using UnityEngine;

[CreateAssetMenu(fileName = "DataAsset", menuName = "Scriptable Objects/DataAsset")]
public class DataAsset : ScriptableObject
{
    [SerializeField] private string id;
    [SerializeField] private string displayName;
    [TextArea][SerializeField] private string description;
    [SerializeField] Sprite icon;

    public string ID => id;

    public string DisplayName => displayName;

    public string Description => description;

    public Sprite Icon => icon;
}
