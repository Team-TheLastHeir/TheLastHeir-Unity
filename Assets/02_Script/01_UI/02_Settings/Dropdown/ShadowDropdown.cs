using UnityEngine;
using UnityEngine.UI;

public class ShadowDropdown : MonoBehaviour
{
    public Dropdown shadowDropdown; 
    public Shadow targetShadow; 

    void Start()
    {
        // Dropdown 옵션 초기화
        shadowDropdown.ClearOptions();
        shadowDropdown.AddOptions(new System.Collections.Generic.List<string> { "Ultra", "High", "Middle", "Low" });

        // 초기 선택값 및 이벤트 연결
        shadowDropdown.onValueChanged.AddListener(OnShadowDropdownChanged);

        // 최초 적용
        OnShadowDropdownChanged(shadowDropdown.value);
    }

    void OnShadowDropdownChanged(int index)
    {
        switch (index)
        {
            case 0: // Ultra
                ApplyShadow(new Color(0,0,0,0.4f), new Vector2(8, -8), 6);
                break;
            case 1: // High
                ApplyShadow(new Color(0,0,0,0.3f), new Vector2(6, -6), 4);
                break;
            case 2: // Middle
                ApplyShadow(new Color(0,0,0,0.2f), new Vector2(4, -4), 2);
                break;
            case 3: // Low
                ApplyShadow(new Color(0,0,0,0.1f), new Vector2(2, -2), 1);
                break;
        }
    }

    void ApplyShadow(Color color, Vector2 distance, float softness)
    {
        if (targetShadow != null)
        {
            targetShadow.effectColor = color;
            targetShadow.effectDistance = distance;
        }
    }
}