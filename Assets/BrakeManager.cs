using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BrakeManager : MonoBehaviour
{
   public Text brakeStatusText; // Reference to the UI Text component
   public WheelBrake[] wheels; // Array to hold references to the WheelBrake scripts
   private bool[] appliedOnceStates; // Array to track if each wheel has been applied at least once
   private bool[] releasedOnceStates; // Array to track if each wheel has been released at least once
   private void Start()
   {
       if (wheels.Length != 8)
       {
           Debug.LogError("There should be exactly 8 wheels assigned in the BrakeManager.");
           return;
       }
       appliedOnceStates = new bool[wheels.Length];
       releasedOnceStates = new bool[wheels.Length];
       UpdateBrakeStatus();
   }
   public void UpdateWheelState(int wheelIndex, bool state)
   {
       if (wheelIndex < 0 || wheelIndex >= wheels.Length)
       {
           Debug.LogError($"Invalid wheel index: {wheelIndex}. Index should be between 0 and {wheels.Length - 1}.");
           return;
       }
       wheels[wheelIndex].brakesApplied = state;
       if (state)
           appliedOnceStates[wheelIndex] = true;
       else
           releasedOnceStates[wheelIndex] = true;
       UpdateBrakeStatus();
   }
   private void UpdateBrakeStatus()
   {
       int appliedCount = 0;
       int releasedCount = 0;
       int bothDoneCount = 0;
       for (int i = 0; i < wheels.Length; i++)
       {
           if (wheels[i].brakesApplied)
               appliedCount++;
           else
               releasedCount++;
           if (appliedOnceStates[i] && releasedOnceStates[i])
               bothDoneCount++;
       }
       if (bothDoneCount == wheels.Length)
       {
           brakeStatusText.text = "Brakes: All 8 wheels Released and Applied";
       }
       else if (appliedCount == wheels.Length)
       {
           brakeStatusText.text = "Brakes: All 8 wheels Applied";
       }
       else if (releasedCount == wheels.Length)
       {
           brakeStatusText.text = "Brakes: All 8 wheels Released";
       }
       else
       {
           brakeStatusText.text = "Brakes: Unfinished";
       }
   }
}