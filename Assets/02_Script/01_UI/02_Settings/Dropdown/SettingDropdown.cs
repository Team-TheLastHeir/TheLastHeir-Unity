using UnityEngine;
using UnityEngine.UI;

public class SettingDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public SettingType settingType;

    // 필요에 따라 할당
    public Light mainLight;

    void Start()
    {
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
        }

        Debug.Log($"{settingType} Index: {index}");
    }

    void ApplyShadow(int index)
    {
        // 예시: Shadow 옵션별 적용
        float[] shadowStrengths = { 1.0f, 0.7f, 0.5f, 0.2f };
        bool[] shadowCast = { true, true, true, false };
        bool[] shadowReceive = { true, true, true, false };

        SetShadowForAllObjects(shadowCast[index], shadowReceive[index]);
        if (mainLight != null)
            mainLight.shadowStrength = shadowStrengths[index];
    }

    void ApplyBrightness(int index)
    {
        // 예시: 밝기 단계별 적용
        float[] brightnessLevels = { 1.0f, 0.8f, 0.6f, 0.4f };
        if (mainLight != null)
            mainLight.intensity = brightnessLevels[index];
    }

    void ApplyTextureQuality(int index)
    {
        // 예시: 텍스처 품질 단계별 적용
        int[] qualityLevels = { 0, 1, 2, 3 }; // Unity QualitySetting 예시
        QualitySettings.globalTextureMipmapLimit = qualityLevels[index];
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