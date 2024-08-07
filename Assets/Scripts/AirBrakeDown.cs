using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBrakeDown : MonoBehaviour
{
    //Animator anim;
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
                Animator animator = hit.collider.GetComponent<Animator>();

                if(animator!=null)
                {
                    if(flipDown)
                    {
                        animator.SetBool("Active",true);
                        brakesApplied = true;
                        statusText.text = "Brakes > Applied";
                    }
                    else
                    {
                       animator.SetBool("Active",false); 
                       brakesApplied = false;
                       statusText.text = "Brakes > Released";
                    }
                    
                flipDown = !flipDown;
                }
            }
            
        }
    }
}
