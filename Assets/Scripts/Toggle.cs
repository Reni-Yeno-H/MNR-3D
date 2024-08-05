using UnityEngine;

public class Toggle : MonoBehaviour
{
    public GameObject panel;
    
    public void TogglePanelVisibility()
    {
        if(panel != null)
        {
        panel.SetActive(panel.activeSelf);
        }
    }
}
