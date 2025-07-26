using UnityEngine;
using UnityEngine.UI;

public class CheckRemember : MonoBehaviour
{
    public Button RememberButton;
    public RawImage CheckImage;
    private bool isChecked = false;

    void Start()
    {
        ChangeImage();
    }
    public void OnCheckedButton()
    {
        isChecked = !isChecked;
        ChangeImage();
    }

    private void ChangeImage()
    {
        if (isChecked)
        { 
            CheckImage.enabled = true;
        }

        else
        {
            CheckImage.enabled = false;
        }
    }
}
