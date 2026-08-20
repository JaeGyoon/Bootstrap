using System.Threading.Tasks;
using UnityEngine;

public interface ISaveService
{
    PlayerSaveData CurrentSaveData { get; }

    Task InitializeAsync();

    PlayerSaveData GetData();

    Task SaveAsync();
}
