using UnityEngine;
using TMPro;

public class LobbyStateView : MonoBehaviour
{
    [SerializeField] private TMP_Text heroNameText;
    [SerializeField] private TMP_Text stageNameText;

    public void SetHeroName(string heroName)
    {
        heroNameText.text = heroName;
    }

    public void SetStageName(string stageName)
    {
        stageNameText.text = stageName;
    }
}
