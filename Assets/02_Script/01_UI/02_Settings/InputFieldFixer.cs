using TMPro;
using UnityEngine;

public class InputFieldFixer : MonoBehaviour
{
    // Text의 값이 채워져도 Placeholder가 사라지지 않는 문제 해결
    public TMP_InputField inputID;
    
    public void OnIDValueChanged(string value)
    {
        Debug.Log("value" + value);
        Debug.Log("inputID.text: " + inputID.text);
        TogglePlaceholder(inputID, value);
    }

    private void TogglePlaceholder(TMP_InputField inputField, string text)
    {
        if (inputField != null && inputField.placeholder != null)
        {
            inputField.placeholder.gameObject.SetActive(string.IsNullOrEmpty(text));
        }
    }
}