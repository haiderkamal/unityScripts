using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    Animator animator;
    public float InputX;
    public float InputXcam;
    public float InputY;
    public VirtualJoystick controlScript;

    public Vector3 directionPlayer;
    public AudioSource audio;
    public AudioClip[] audioClips;
    public Rigidbody rb;
    public GameObject Player;

    public float time;
    public int AudioNumber = 0;
    public bool isDown;

    public bool isCrouch;
   
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        directionPlayer = controlScript.inputVector;

      
        
	}
	private void FixedUpdate(){

        if (isDown == true)
        {
            InputX = directionPlayer.x;

            InputY = directionPlayer.z;

            this.gameObject.transform.position += transform.forward * (InputY / 300f);
            this.gameObject.transform.position += transform.right * (InputX / 300f);

            animator.SetFloat("InputY", -2 + (-InputY));
            animator.SetFloat("InputX", -2);
            animator.SetFloat("Shoot", -2);
            footStepsSounds();
        }
        else if (isDown == false)
        {
            if (this.isCrouch == true)
            {

                InputX = directionPlayer.x;

                InputY = directionPlayer.z;

                this.gameObject.transform.position += transform.forward * (InputY / 500f);
                this.gameObject.transform.position += transform.right * (InputX / 500f);

                animator.SetFloat("InputY", -5 + (InputY));
                animator.SetFloat("InputX", -3);
                animator.SetFloat("Shoot", -3);
                footStepsSounds();
            }
            else
            {
                InputX = directionPlayer.x;

                InputY = directionPlayer.z;

                this.gameObject.transform.position += transform.forward * (InputY / 100f);
                this.gameObject.transform.position += transform.right * (InputX / 100f);

                animator.SetFloat("InputY", InputY);
                animator.SetFloat("Shoot", 0);

                animator.SetFloat("InputX", InputX);
                footStepsSounds();
            }
        }

    }
    public void footStepsSounds()
    {
        if (InputY > 0.1)
        {
            time += Time.deltaTime;
            //Debug.Log("Input Y " + InputY + " Time" + time);

            if (time > (1.3f-InputY))
            {
                time = 0;
                AudioNumber++;
                if (AudioNumber == audioClips.Length)
                {
                    AudioNumber = 0;
                }
                
                audio.clip = audioClips[AudioNumber];
                audio.Play();
                
            }
        }
    }
   
  
    
   
}
