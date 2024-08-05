using UnityEngine;
using UnityEngine.UI;
public class HammerCheck : MonoBehaviour
{
   public Image defaultImage;
   public Image hoverImage;

   public AudioClip audioBrakesApplied; 
   public AudioClip audioBrakesReleased; // If clicked

   public Texture2D hammerCursor; // Reference to the hammer cursor texture
   private Renderer cubeRenderer; // Reference to the cube's Renderer

   private AudioSource audioSource; 

   public GameObject airBrake;
   private AirBrakeDown airBrakeState;

   private bool previousState;
   //private bool brakesApplied = false;
   //public Animator brakesOn;
   //public Animator brakesOff;

   //public string animationNameOn;
   //public string animationNameOff;
   //public bool animationPlayed = false;

   public Camera playerCamera;
   public Color initialColor;
   public Color newColor;

   void Start()
   {
       cubeRenderer = GetComponent<Renderer>();
       audioSource = GetComponent<AudioSource>();
       airBrakeState = airBrake.GetComponent<AirBrakeDown>();
       previousState = airBrakeState.brakesApplied;

       //cubeRenderer.material.color = initialColor;
   }

   void Update()
   {
       // Create a ray from the center of the screen
       Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
       RaycastHit hit;
       // Perform the raycast
       if (Physics.Raycast(ray, out hit))
       {
           // Check if the hit object is the cube
           if (hit.collider.gameObject == gameObject)
           {
               // Check if the left mouse button is clicked
               if (Input.GetMouseButtonDown(0))
               {
                   // Change the cube color to green
                   cubeRenderer.material.color = newColor;
                   if (airBrakeState.brakesApplied)
                   {
                       //if(previousState != airBrakeState.brakesApplied)
                       //{
                            PlayAudioClip(audioBrakesReleased);
                       //}
                       //PlayAudioClip(audioBrakesReleased);
                       //brakesOff.Play(animationNameOff);
                       //animationPlayed = false;
                   }
                   else
                   {
                       //if(previousState != airBrakeState.brakesApplied)
                       //{
                            PlayAudioClip(audioBrakesApplied);
                       //}
                       //PlayAudioClip(audioBrakesApplied);
                       //brakesOn.Play(animationNameOn);
                       //animationPlayed = true;
                       cubeRenderer.material.color = initialColor;
                   }
                   previousState = airBrakeState.brakesApplied;
                   
               }
           }

       }

   }

   private void OnMouseEnter()
   {
    defaultImage.enabled = false;
    hoverImage.enabled = true;
   }

   private void OnMouseExit()
   {
    defaultImage.enabled = true;
    hoverImage.enabled = false;
   }

   /*private void OnMouseDown()
   {
    if(animationPlayed)
    {
        PlayAudioClip(audioBrakesReleased);
    }
    else
    {
        PlayAudioClip(audioBrakesApplied);
    }
   }*/

   private void PlayAudioClip(AudioClip clip)
   {
       audioSource.clip = clip;
       audioSource.Play();
   }
}
