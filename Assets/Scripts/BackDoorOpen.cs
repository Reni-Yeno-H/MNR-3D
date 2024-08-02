using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackDoorOpen : MonoBehaviour
{
    //Animator anim;
    public Camera cam;
    public Animator door;
    //public Animator doorHandle;
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
                        door.SetBool("DoorOpen",false);
                        //doorHandle.SetBool("HandleOpen",false);
                    }
                    else
                    {
                       color.material.color = Color.red;
                       door.SetBool("DoorOpen",true); 
                       //doorHandle.SetBool("HandleOpen",true);
                    }
                    
                isOpen = !isOpen;
                }
            }
            
        }
    }
}
