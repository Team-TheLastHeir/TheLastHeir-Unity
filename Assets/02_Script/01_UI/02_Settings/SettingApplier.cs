using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SettingApplier : MonoBehaviour
{
    public Light mainLight; // Inspector에서 씬의 Directional Light 연결

    private MotionBlur motionBlur;

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
        
        int fpsIndex = SettingManager.Instance.GetSetting(SettingType.FPS);
        ApplyFPS(fpsIndex);

        int motionBlurIndex = SettingManager.Instance.GetSetting(SettingType.MotionBlur);
        ApplyMotionBlur(motionBlurIndex);

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

    void ApplyFPS(int index)
    {
        int[] fpxLevels = { -1, 144, 120, 90, 60, 30 };
        Application.targetFrameRate = fpxLevels[index];
    }

    void ApplyMotionBlur(int index)
    {
        if (index == 0)
        {
            motionBlur.active = true;
        }
        else if (index == 1)
        {
            motionBlur.active = false;
        }
    }
}