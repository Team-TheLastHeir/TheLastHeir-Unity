using UnityEngine;

public class SimpleCameraSwitcher : MonoBehaviour, ICameraSwitcher
{
    [SerializeField] private Camera gameplayCamera;
    [SerializeField] private Camera cutsceneCamera;

    void Start()
    {
        gameplayCamera.enabled = true;
        cutsceneCamera.enabled = false;
    }

    public void SwitchToCutsceneCamera()
    {
        gameplayCamera.enabled = false;
        cutsceneCamera.enabled = true;
    }

    public void SwitchToGameplayCamera()
    {
        gameplayCamera.enabled = true;
        cutsceneCamera.enabled = false;
    }
}