using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private async void Start()
    {
        GameCompositionRoot gameCompositionRoot = new GameCompositionRoot();

        await gameCompositionRoot.InitializeAsync();

        Debug.Log("부트 스트랩 이니셜 종료");
    }
}
