using UnityEngine;

public class WheelClick : MonoBehaviour
{
    public WheelBrakeAppliedUI manager;

    void OnMouseDown()
    {
        manager.OnWheelClicked(gameObject);
    }
}