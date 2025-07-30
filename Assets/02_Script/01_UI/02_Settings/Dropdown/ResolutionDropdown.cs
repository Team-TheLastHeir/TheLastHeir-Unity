using UnityEngine;
using UnityEngine.UI;

public class ResolutionSelector : MonoBehaviour
{
    public Dropdown resolutionDropdown; 

    public void OnResolutionChanged(int index)
    {
        string option = resolutionDropdown.options[index].text;
        string[] res = option.Split('x');
        int width = int.Parse(res[0].Trim());
        int height = int.Parse(res[1].Trim());

        Screen.SetResolution(width, height, Screen.fullScreen);
        Debug.Log($"해상도 변경: {width} x {height}");
    }
}