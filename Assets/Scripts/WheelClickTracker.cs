using UnityEngine;
using UnityEngine.UI;
public class WheelClickTracker : MonoBehaviour
{
   public GameObject cube;
   private bool[] wheelClicked;
   private int totalWheels = 8;
   private int currentClicks = 0;
   private int iterations = 0;
   public Text messageText;  // Assuming you have a UI Text to show the message
   void Start()
   {
       wheelClicked = new bool[totalWheels];
       ResetWheels();
   }
   void Update()
   {
       if (Input.GetMouseButtonDown(0))
       {
           Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
           RaycastHit hit;
           if (Physics.Raycast(ray, out hit))
           {
               GameObject clickedObject = hit.transform.gameObject;
               for (int i = 0; i < totalWheels; i++)
               {
                   if (clickedObject == gameObject && gameObject.name == $"Wheel{i + 1}")
                   {
                       if (!wheelClicked[i])
                       {
                           wheelClicked[i] = true;
                           currentClicks++;
                           CheckAllWheelsClicked();
                       }
                       return;
                   }
               }
               if (clickedObject == cube)
               {
                   iterations++;
                   messageText.text = $"Iteration {iterations}: Released and applied all 8 wheels";
                   ResetWheels();
               }
           }
       }
   }
   void CheckAllWheelsClicked()
   {
       for (int i = 0; i < totalWheels; i++)
       {
           if (!wheelClicked[i])
               return;
       }
       // All wheels clicked for this iteration
       if (currentClicks == totalWheels)
       {
           messageText.text = $"All wheels clicked!";
           iterations++;
           messageText.text = $"Iteration {iterations}: Released and applied all 8 wheels";
           ResetWheels();
       }
   }
   void ResetWheels()
   {
       for (int i = 0; i < totalWheels; i++)
       {
           wheelClicked[i] = false;
       }
       currentClicks = 0;
   }
}