using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpScript : MonoBehaviour
{
    //Animator anim;
    public Camera cam;
    public Animator lever;
    private bool flipUp = true;
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
                    if(flipUp)
                    {
                        lever.SetBool("Active",true);
                    }
                    else
                    {
                       lever.SetBool("Active",false); 
                    }
                    
                flipUp = !flipUp;
                }
            }
            
        }
    }
}
