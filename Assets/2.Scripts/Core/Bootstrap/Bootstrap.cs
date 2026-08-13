using UnityEngine;

public class Bootstrap : MonoBehaviour
{    
    private async void Start()
    {
        GameStartup gameStartup = new GameStartup();

        await gameStartup.StartAsync();
    }
}
