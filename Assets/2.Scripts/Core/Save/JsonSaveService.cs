using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public class JsonSaveService : ISaveService
{
    private const string FileName = "player_save.json";

    private PlayerSaveData currentSaveData;

    private string SavePath => Path.Combine(Application.persistentDataPath,FileName);

    public async Task InitializeAsync()
    {
        if ( File.Exists(SavePath) )
        {
            await LoadAsync();
        }
        else
        {
            currentSaveData = CreateDefaultSaveData();
        }
    }

    private async Task LoadAsync()
    {
        string json = await File.ReadAllTextAsync(SavePath);

        currentSaveData = JsonUtility.FromJson<PlayerSaveData>(json);

        Debug.Log("저장 데이터 로드!");
    }

    private static PlayerSaveData CreateDefaultSaveData()
    {
        Debug.Log("첫 세이브 데이터 생성!");

        return new PlayerSaveData();
    }

    public PlayerSaveData GetData()
    {
        return currentSaveData;
    }

    public async Task SaveAsync()
    {
        string json = JsonUtility.ToJson(currentSaveData, true);

        await File.WriteAllTextAsync(SavePath, json);
    }
}
