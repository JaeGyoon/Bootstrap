using UnityEngine;

public class LobbyView : MonoBehaviour, ILobbyView
{    
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
