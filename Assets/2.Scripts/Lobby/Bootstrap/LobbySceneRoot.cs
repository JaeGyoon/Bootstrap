using UnityEngine;

public class LobbySceneRoot : MonoBehaviour
{
    [SerializeField] private Transform canvasTransform;

    public Transform CanvasTransform => canvasTransform;
}
