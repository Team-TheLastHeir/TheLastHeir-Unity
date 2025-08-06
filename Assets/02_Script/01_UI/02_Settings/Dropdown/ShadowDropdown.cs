using UnityEngine;
using UnityEngine.UI;

public class ShadowDropdown : MonoBehaviour
{
    public Dropdown shadowDropdown;
    public Light mainLight; 

    void Start()
    {
        shadowDropdown.onValueChanged.AddListener(OnDropdownChanged);
        int savedIndex = ShadowSettingManager.Instance != null ? ShadowSettingManager.Instance.ShadowLevelIndex : 0;
        shadowDropdown.value = savedIndex;
        OnDropdownChanged(savedIndex);
    }

    void OnDropdownChanged(int index)
    {
        if (ShadowSettingManager.Instance != null)
            ShadowSettingManager.Instance.ShadowLevelIndex = index;
        switch (index)
        {
            case 0: // Ultra
                SetShadowForAllObjects(true, true);
                if (mainLight != null) mainLight.shadowStrength = 1.0f;
                break;
            case 1: // High
                SetShadowForAllObjects(true, true);
                if (mainLight != null) mainLight.shadowStrength = 0.7f;
                break;
            case 2: // Middle
                SetShadowForAllObjects(true, true);
                if (mainLight != null) mainLight.shadowStrength = 0.5f;
                break;
            case 3: // Low
                SetShadowForAllObjects(false, false);
                if (mainLight != null) mainLight.shadowStrength = 0.2f;
                break;
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