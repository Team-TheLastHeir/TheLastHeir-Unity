using UnityEngine;

public class CutsceneBootstrap : MonoBehaviour
{
    [SerializeField] private CutscenePlayer cutscenePlayer;
    [SerializeField] private SimpleCameraController cameraController;
    [SerializeField] private CutscenePointsProvider pointsProvider;
    [SerializeField] private SimpleCameraSwitcher cameraSwitcher;

    void Awake()
    {
        cutscenePlayer.Initialize(cameraController, pointsProvider, cameraSwitcher);
    }

    void Start()
    {
        cutscenePlayer.PlayCutscene();
    }
}