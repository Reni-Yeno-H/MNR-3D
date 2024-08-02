using UnityEngine;
using UnityEngine.UI;
public class HammerCheck : MonoBehaviour
{
   public Texture2D hammerCursor; // Reference to the hammer cursor texture
   private Renderer cubeRenderer; // Reference to the cube's Renderer
   private bool isHovering = false; // To track if the cursor is hovering over the cube
   private CursorMode cursorMode = CursorMode.Auto;
   private Vector2 hotSpot = Vector2.zero; // Hotspot for the custom cursor
   public Camera playerCamera;
   public Color initialColor;

   void Start()
   {
       cubeRenderer = GetComponent<Renderer>();
       //cubeRenderer.material.color = initialColor;
   }
   void Update()
   {
       // Create a ray from the center of the screen
       Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       // Perform the raycast
       if (Physics.Raycast(ray, out hit))
       {
           // Check if the hit object is the cube
           if (hit.collider.gameObject == gameObject)
           {
               // Change the cursor to the hammer icon
               Cursor.SetCursor(hammerCursor, hotSpot, cursorMode);
               isHovering = true;
               // Check if the left mouse button is clicked
               if (Input.GetMouseButtonDown(0))
               {
                   // Change the cube color to green
                   cubeRenderer.material.color = initialColor;
               }
           }
           else
           {
               ResetCursor();
           }
       }
       else
       {
           ResetCursor();
       }
   }
   private void ResetCursor()
   {
       if (isHovering)
       {
           Cursor.SetCursor(null, Vector2.zero, cursorMode); // Change back to the default cursor
           isHovering = false;
       }
   }
}
