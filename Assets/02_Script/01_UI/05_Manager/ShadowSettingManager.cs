using UnityEngine;

public class ShadowSettingManager : MonoBehaviour
{
    public static ShadowSettingManager Instance { get; private set; }
    public int ShadowLevelIndex { get; set; } = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}