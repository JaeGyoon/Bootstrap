using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectionEntryView : MonoBehaviour
{
    [SerializeField] private Button selectBtn;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI stageNameText;
    [SerializeField] private TextMeshProUGUI lockedText;

    public string stageID;
    [SerializeField] private bool isSelected;
    [SerializeField] private bool isUnlocked;

    private Action<string> onSelected;

    public string StageID => stageID;

    public void Initialize(StageSO stageSO, bool isSelected, bool isUnlocked, Action<string> onSelected)
    {
        stageID = stageSO.ID;
        this.onSelected = onSelected;

        stageNameText.text = stageSO.DisplayName;
        iconImage.sprite = stageSO.Icon;

        SetSelected(isSelected);
        SetUnlocked(isUnlocked);

        selectBtn.onClick.RemoveAllListeners();
        selectBtn.onClick.AddListener(OnClick);

        Debug.Log("버튼 생성");
    }

    private void Refrash()
    {
        selectBtn.interactable = (isUnlocked && !isSelected);
    }

    public void SetSelected(bool isSelected)
    {
        this.isSelected = isSelected;

        Refrash();
    }

    public void SetUnlocked(bool isUnlocked)
    {
        this.isUnlocked = isUnlocked;

        Refrash();
    }

    private void OnClick()
    {
        Debug.Log("클릭 감지");

        if ( !isUnlocked || isSelected )
        {
            Debug.Log("리턴 호출");
            return;
        }

        onSelected?.Invoke(stageID);

    }
}
