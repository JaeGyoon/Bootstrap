using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HeroSelectionEntryView : MonoBehaviour
{
    [SerializeField] private Button selectBtn;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI heroNameText;

    private string heroID;
    private Action<string> onSelected;

    public string HeroID => heroID;

    public void Initialize(HeroSO heroSO, bool isSelected, Action<string> onSelected)
    {
        heroID = heroSO.ID;
        this.onSelected = onSelected;

        heroNameText.text = heroSO.DisplayName;
        iconImage.sprite = heroSO.Icon;

        SetSelected(isSelected);

        selectBtn.onClick.RemoveAllListeners();

        selectBtn.onClick.AddListener(OnClick);

        Debug.Log("버튼 생성");
    }

    public void SetSelected(bool isSelected)
    {
        selectBtn.interactable = !isSelected;
    }

    private void OnClick()
    {
        Debug.Log("클릭 감지");

        onSelected?.Invoke(heroID);

        

        
    }

    private void OnDestroy()
    {
        onSelected = null;
    }
}
