using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{
   // This method will be called when the button is clicked
   public void LoadNextScene()
   {
       // Get the current scene's build index
       int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
       // Calculate the next scene's build index
       int nextSceneIndex = currentSceneIndex + 1;
       // Check if the next scene index is within the valid range
       if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
       {
           // Load the next scene
           SceneManager.LoadScene(nextSceneIndex);
       }
       else
       {
           Debug.LogWarning("No next scene to load. Please check your build settings.");
       }
   }
}
