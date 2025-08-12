using UnityEngine;

public class SettingApplier : MonoBehaviour
{
    public Light mainLight; // Inspector에서 씬의 Directional Light 연결

    void Start()
    {
        ApplyAllSettings();
    }

    public void ApplyAllSettings()
    {
        int shadowIndex = SettingManager.Instance.GetSetting(SettingType.Shadow);
        ApplyShadow(shadowIndex);

        int brightnessIndex = SettingManager.Instance.GetSetting(SettingType.Brightness);
        ApplyBrightness(brightnessIndex);

        // 필요시 다른 세팅도 추가
    }

    void ApplyShadow(int index)
    {
        float[] shadowStrengths = { 1.0f, 0.7f, 0.5f, 0.2f };
        bool[] shadowCast = { true, true, true, false };
        bool[] shadowReceive = { true, true, true, false };

        MeshRenderer[] renderers = FindObjectsOfType<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.shadowCastingMode = shadowCast[index] ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.receiveShadows = shadowReceive[index];
        }
        if (mainLight != null)
            mainLight.shadowStrength = shadowStrengths[index];
    }

    void ApplyBrightness(int index)
    {
        float[] brightnessLevels = { 1.0f, 0.8f, 0.6f, 0.4f };
        if (mainLight != null)
            mainLight.intensity = brightnessLevels[index];
    }
}