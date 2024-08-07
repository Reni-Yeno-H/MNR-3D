using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBrakeDown : MonoBehaviour
{
    //Animator anim;
    public Animator airbrake;
    public Camera cam;
    private bool flipDown = true;
    public bool brakesApplied;
    public Text statusText;
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {

                if (hit.collider.gameObject==gameObject)
                {
                    if(flipDown)
                    {
                        airbrake.SetBool("Active",true);
                        brakesApplied = true;
                        statusText.text = "Active Brake Status > Applied";
                    }
                    else
                    {
                       airbrake.SetBool("Active",false); 
                       brakesApplied = false;
                       statusText.text = "Active Brake Status > Released";
                    }
                    
                flipDown = !flipDown;
                }
            }
            
        }
    }
}
