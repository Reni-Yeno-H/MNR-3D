using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBrake : MonoBehaviour
{
   public bool brakesApplied = false; // Boolean to track the state
   public bool appliedOnce = false; // Boolean to track if the brakes have been applied at least once
   public bool releasedOnce = false; // Boolean to track if the brakes have been released at least once
   public int wheelIndex; // Index to identify the wheel
   private BrakeManager brakeManager; // Reference to the BrakeManager script
   private void Start()
   {
       brakeManager = FindObjectOfType<BrakeManager>(); // Find the BrakeManager in the scene
       if (brakeManager == null)
       {
           Debug.LogError("BrakeManager not found in the scene.");
       }
   }
   private void OnMouseDown()
   {
       // Toggle the brakesApplied state
       brakesApplied = !brakesApplied;
       // Track if the wheel has been applied or released at least once
       if (brakesApplied)
           appliedOnce = true;
       else
           releasedOnce = true;
       // Notify the BrakeManager of the state change
       brakeManager.UpdateWheelState(wheelIndex, brakesApplied);
   }
}