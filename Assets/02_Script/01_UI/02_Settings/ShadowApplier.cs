using UnityEngine;

public class ShadowApplier : MonoBehaviour
{
    public Light mainLight; // Inspector에서 씬의 Directional Light 연결

    void Start()
    {
        int index = ShadowSettingManager.Instance != null ? ShadowSettingManager.Instance.ShadowLevelIndex : 0;
        switch (index)
        {
            case 0: SetShadowForAllObjects(true, true); if (mainLight != null) mainLight.shadowStrength = 1.0f; break;
            case 1: SetShadowForAllObjects(true, true); if (mainLight != null) mainLight.shadowStrength = 0.7f; break;
            case 2: SetShadowForAllObjects(true, true); if (mainLight != null) mainLight.shadowStrength = 0.5f; break;
            case 3: SetShadowForAllObjects(false, false); if (mainLight != null) mainLight.shadowStrength = 0.2f; break;
        }
    }

    void SetShadowForAllObjects(bool cast, bool receive)
    {
        MeshRenderer[] renderers = FindObjectsOfType<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.shadowCastingMode = cast ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.receiveShadows = receive;
        }
    }
}