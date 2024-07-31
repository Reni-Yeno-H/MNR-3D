using UnityEngine; 
using UnityEngine.EventSystems; 

public class CustomCursor : MonoBehaviour 
{ 
    public RectTransform cursorRectTransform; 

    void Update() { 
    
    // Cast a ray from the camera to the point on the screen where the custom cursor is Ray 
    Ray ray = Camera.main.ScreenPointToRay(cursorRectTransform.position); 
    RaycastHit hit; 
        if(Physics.Raycast(ray, out hit)) 
        { 
            // Check for clicks and handle interaction 
            if (Input.GetMouseButtonDown(0)) { 
            // Handle click on hit.collider.gameObject;
            Debug.Log("Clicked on: " + hit.collider.gameObject.name);
            } 
        } 
    }
}
