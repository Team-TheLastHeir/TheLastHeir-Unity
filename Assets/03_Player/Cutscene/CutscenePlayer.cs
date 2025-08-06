using System.Collections;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour, ICutscene
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float waitTime = 2f;

    private ICameraController cameraController;
    private CutscenePointsProvider pointsProvider;
    private ICameraSwitcher cameraSwitcher;

    public void Initialize(ICameraController cameraController,
        CutscenePointsProvider pointsProvider,
        ICameraSwitcher cameraSwitcher)
    {
        this.cameraController = cameraController;
        this.pointsProvider = pointsProvider;
        this.cameraSwitcher = cameraSwitcher;
    }

    public void PlayCutscene()
    {
        StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        cameraSwitcher.SwitchToCutsceneCamera();

        var points = pointsProvider.GetPoints();

        foreach (Transform point in points)
        {
            while (!cameraController.IsAtPosition(point))
            {
                cameraController.MoveTo(point, moveSpeed, rotationSpeed);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
        }
        
        cameraSwitcher.SwitchToGameplayCamera();
    }
}