using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windowOpen : MonoBehaviour
{
    //Animator anim;
    public Camera cam;
    public Animator window;

    private bool isOpen = false;
    private Renderer color;
    void Start()
    {
        //anim = gameObject.GetComponent<Animator>();
        color = GetComponent<Renderer>();
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
    
                    if(isOpen)
                    {
                        color.material.color = Color.green;
                        window.SetBool("WindowOpen",false);

                    }
                    else
                    {
                       color.material.color = Color.red;
                       window.SetBool("WindowOpen",true); 

                    }
                    
                isOpen = !isOpen;
                

                }
            }
            
        }
    }
}

