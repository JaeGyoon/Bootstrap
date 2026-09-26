using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private GameStartup gameStartup;

    private async void Start()
    {
        gameStartup = new GameStartup();

        await gameStartup.StartAsync();
    }

    private void OnDestory()
    {
        gameStartup?.Dispose();
    }
}
