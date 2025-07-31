using UnityEngine;

public class CutscenePointsProvider : MonoBehaviour
{
    [SerializeField] private Transform cutsceneFolder;

    public Transform[] GetPoints()
    {
        Transform[] points = new Transform[cutsceneFolder.childCount];
        for (int i = 0; i < cutsceneFolder.childCount; i++)
        {
            points[i] = cutsceneFolder.GetChild(i);
        }
        return points;
    }
}