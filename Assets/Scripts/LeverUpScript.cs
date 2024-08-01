using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverUpScript : MonoBehaviour
{
    //Animator anim;
    public Camera cam;
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
                Animator animator = hit.collider.GetComponent<Animator>();

                if(animator!=null)
                {
                    if(flipUp)
                    {
                        animator.SetBool("Active",true);
                    }
                    else
                    {
                       animator.SetBool("Active",false); 
                    }
                    
                flipUp = !flipUp;
                }
            }
            
        }
    }
}
