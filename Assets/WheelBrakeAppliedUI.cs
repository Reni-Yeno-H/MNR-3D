using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelBrakeAppliedUI : MonoBehaviour
{
    public List<GameObject> wheels; // Assign your 8 wheel GameObjects in the inspector
    public Text statusText; // Assign your Text UI element in the inspector
    private HashSet<GameObject> appliedWheels = new HashSet<GameObject>();
    private HashSet<GameObject> releasedWheels = new HashSet<GameObject>();

    private AirBrakeDown airBrakeState;

    void Start()
    {
        // Initialize the status text
        airBrakeState = GetComponent<AirBrakeDown>();
        statusText.text = "Brakes: Unfinished";

        // Ensure each wheel has the WheelClick component and set the manager reference
        foreach (GameObject wheel in wheels)
        {
            WheelClick wheelClick = wheel.GetComponent<WheelClick>();
            if (wheelClick == null)
            {
                wheelClick = wheel.AddComponent<WheelClick>();
            }
            wheelClick.manager = this;
        }
    }

    public void OnWheelClicked(GameObject wheel)
    {
        if (airBrakeState != null)
        {
        } else{
        
            // Handle applied brakes
            if (!appliedWheels.Contains(wheel))
            {
                appliedWheels.Add(wheel);
                if (appliedWheels.Count == wheels.Count)
                {
                    statusText.text = "Brakes: All 8 applied";

                }
            }
        
        
        
            // Handle released brakes
            if (!releasedWheels.Contains(wheel))
            {
                releasedWheels.Add(wheel);
                if (releasedWheels.Count == wheels.Count)
                {
                    statusText.text = "Brakes: All 8 released";
                }
            }
        }

        // Check if all wheels have been clicked for both states
        if (appliedWheels.Count == wheels.Count && releasedWheels.Count == wheels.Count)
        {
            statusText.text = "Brakes: All 8 Applied and Released";
        }
    }

}
