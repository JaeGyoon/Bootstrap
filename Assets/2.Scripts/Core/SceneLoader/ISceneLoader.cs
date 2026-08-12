using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public interface ISceneLoader
{
    Task LoadSceneAsync(SceneName sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single);
}
