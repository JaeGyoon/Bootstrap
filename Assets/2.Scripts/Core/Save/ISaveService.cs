using System.Threading.Tasks;
using UnityEngine;

public interface ISaveService
{
    Task InitializeAsync();

    PlayerSaveData GetData();

    Task SaveAsync();
}
