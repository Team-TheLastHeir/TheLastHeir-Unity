using TMPro;
using UnityEngine;

public class InputFieldFixer : MonoBehaviour
{
    // Text의 값이 채워져도 Placeholder가 사라지지 않는 문제 해결
    public TMP_InputField inputID;
    public TMP_InputField inputPW;
    
    public void OnIDValueChanged(string value)
    {
        Debug.Log("Id" + value);
        TogglePlaceholder(inputID, value);
    }
    
    public void OnPWValueChanged(string value)
    {
        Debug.Log("PW" + value);  
        TogglePlaceholder(inputPW, value);
    }

    private void TogglePlaceholder(TMP_InputField inputField, string text)
    {
        if (inputField != null && inputField.placeholder != null)
        {
            inputField.placeholder.gameObject.SetActive(string.IsNullOrEmpty(text));
        }
    }
}