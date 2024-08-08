using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirBrakeDown : MonoBehaviour
{
    //Animator anim;
    public Animator airbrake;
    public Animator brakeshoe1;
    public Animator brakeshoe2;
    public Animator brakeshoe3;
    public Animator brakeshoe4;
    public Animator brakeshoe5;
    public Animator brakeshoe6;
    public Animator brakeshoe7;
    public Animator brakeshoe8;

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
                        brakeshoe1.SetBool("Active",true);
                        brakeshoe2.SetBool("Active",true);
                        brakeshoe3.SetBool("Active",true);
                        brakeshoe4.SetBool("Active",true);
                        brakeshoe5.SetBool("Active",true);
                        brakeshoe6.SetBool("Active",true);
                        brakeshoe7.SetBool("Active",true);
                        brakeshoe8.SetBool("Active",true);
                        brakesApplied = true;
                        statusText.text = "Active Brake Status > Applied";
                    }
                    else
                    {
                       airbrake.SetBool("Active",false); 
                       brakeshoe1.SetBool("Active",false);
                       brakeshoe2.SetBool("Active",false);
                       brakeshoe3.SetBool("Active",false);
                       brakeshoe4.SetBool("Active",false);
                       brakeshoe5.SetBool("Active",false);
                       brakeshoe6.SetBool("Active",false);
                       brakeshoe7.SetBool("Active",false);
                       brakeshoe8.SetBool("Active",false);
                       brakesApplied = false;
                       statusText.text = "Active Brake Status > Released";
                    }
                    
                flipDown = !flipDown;
                }
            }
            
        }
    }
}
