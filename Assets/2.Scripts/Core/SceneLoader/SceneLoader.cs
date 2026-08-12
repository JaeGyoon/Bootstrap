using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : ISceneLoader
{    
    public async Task LoadSceneAsync(SceneName sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        string sceneNameString = sceneName.ToString();

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNameString, loadSceneMode);

        await operation;
    }
}
