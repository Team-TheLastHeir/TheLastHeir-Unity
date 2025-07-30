using UnityEngine;
using System;
public class PanelChangeManager : MonoBehaviour
{
    public void OnPanelChangeClicked(String changePanelName, String currentPanelName)
    {  
        // 현재 활성화된 패널을 비활성화
        GameObject currentPanel = GameObject.Find(currentPanelName);
        if (currentPanel != null)
        {
            currentPanel.SetActive(false);
        }
        
        // 변경할 패널을 활성화
        GameObject changePanel = GameObject.Find(changePanelName);
        if (changePanel != null)
        {
            changePanel.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Change panel '{changePanelName}' not found.");
        }
    }
}
