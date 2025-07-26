using TMPro;
using UnityEngine;

public class InputFieldFixer : MonoBehaviour
{
    // Text의 값이 채워져도 Placeholder가 사라지지 않는 문제 해결
    public TMP_InputField inputID;
    
    public void OnIDValueChanged()
    {
        Debug.Log("inputID.text: " + inputID.text);
        TogglePlaceholder(inputID, inputID.text);
    }

    private void TogglePlaceholder(TMP_InputField inputField, string text)
    {
        if (inputField != null && inputField.placeholder != null)
        {
            inputField.placeholder.gameObject.SetActive(string.IsNullOrEmpty(text));
        }
    }
}