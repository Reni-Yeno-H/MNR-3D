using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelBrakeAppliedUI : MonoBehaviour
{
    public List<GameObject> wheels; // Assign your 8 wheel GameObjects in the inspector
    public Text statusText; // Assign your Text UI element in the inspector

    private HashSet<GameObject> Check = new HashSet<GameObject>();

    private AirBrakeDown airBrakeState;

    void Start()
    {
        // Initialize the status text
        airBrakeState = GetComponent<AirBrakeDown>();
        statusText.text = "Brakes: Unchecked";

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

            // Handle released brakes
            if (!Check.Contains(wheel))
            {
                Check.Add(wheel);
                if (Check.Count == wheels.Count)
                {
                    statusText.text = "All Checks Completed!";
                }
            }
    }

}
