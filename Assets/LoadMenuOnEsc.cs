using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadMenuOnEsc : MonoBehaviour
{
    public string menuSceneName = "Main Menu";

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(menuSceneName);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
