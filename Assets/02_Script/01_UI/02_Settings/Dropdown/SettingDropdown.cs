using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SettingDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public SettingType settingType;

    // 필요에 따라 할당
    public Light mainLight;
    public Volume volume;

    private MotionBlur motionBlur;

    void Start()
    {
        if (volume != null)
        {
            volume.profile.TryGet<MotionBlur>(out motionBlur);
        }
        dropdown.onValueChanged.AddListener(OnDropdownChanged);

        int savedIndex = SettingManager.Instance != null
            ? SettingManager.Instance.GetSetting(settingType)
            : 0;

        dropdown.value = savedIndex;
        OnDropdownChanged(savedIndex);
    }

    public void OnDropdownChanged(int index)
    {
        if (SettingManager.Instance != null)
            SettingManager.Instance.SetSetting(settingType, index);

        // 설정별 처리 분기
        switch (settingType)
        {
            case SettingType.Shadow:
                ApplyShadow(index);
                break;
            case SettingType.Brightness:
                ApplyBrightness(index);
                break;
            case SettingType.Texture:
                ApplyTextureQuality(index);
                break;
            case SettingType.FPS:
                ApplyFPS(index);
                break;
            case SettingType.MotionBlur:
                ApplyVolume(index);
                break;
        }

        Debug.Log($"{settingType} Index: {index}");
    }

    void ApplyShadow(int index)
    {
        float[] shadowStrengths = { 1.0f, 0.7f, 0.5f, 0.2f };
        bool[] shadowCast = { true, true, true, false };
        bool[] shadowReceive = { true, true, true, false };

        SetShadowForAllObjects(shadowCast[index], shadowReceive[index]);
        if (mainLight != null)
            mainLight.shadowStrength = shadowStrengths[index];
    }

    void ApplyBrightness(int index)
    {
        float[] brightnessLevels = { 1.0f, 0.8f, 0.6f, 0.4f };
        if (mainLight != null)
            mainLight.intensity = brightnessLevels[index];
    }

    void ApplyTextureQuality(int index)
    {
        int[] qualityLevels = { 0, 1, 2, 3 }; // Unity QualitySetting 예시
        QualitySettings.globalTextureMipmapLimit = qualityLevels[index];
        Debug.Log("Texuture Quality : " + QualitySettings.globalTextureMipmapLimit);
    }

    void ApplyFPS(int index)
    {
        int[] fpxLevels = { -1, 144, 120, 90, 60, 30 };
        Application.targetFrameRate = fpxLevels[index];
    }

    void ApplyVolume(int index)
    {
        if (index == 0)
        {
            if (volume != null)
            {
                volume.profile.TryGet<MotionBlur>(out motionBlur);
            }
            motionBlur.active = true;
            Debug.Log("Motion Blur 활성화");
        }
        else if (index == 1)
        {
            motionBlur.active = false;
            Debug.Log("Motion Blur 비활성화");
        }
    }

    void SetShadowForAllObjects(bool cast, bool receive)
    {
        MeshRenderer[] renderers = FindObjectsOfType<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            renderer.shadowCastingMode =
                cast ? UnityEngine.Rendering.ShadowCastingMode.On : UnityEngine.Rendering.ShadowCastingMode.Off;
            renderer.receiveShadows = receive;
        }
    }
}