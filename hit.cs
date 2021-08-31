using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hit : MonoBehaviour
{
    public Rigidbody rb;
    public Transform directionF = null;
    public float strength = 500f;
    public TrailRenderer[] tyreMarks;
    private Touch touch;
    public Vector2 startPos;
    public Vector2 direction;
    public float eulerAngY;
    public float speedHolder;
    public float speedBarValue;
    public Image speedBar;
    public bool pitchBool;
    public bool timeBool;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioClip[] clips;
    public AudioClip brakeSound;
    public AudioClip hitSound;
    public float pitchValue;
    public bool brakes;
    public float speedCar;
    public int shots;
    public Text info;
    public Text motorspeed;
    public Text rotSpeed;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
       
        Invoke("enableCollisionCheck", 2f);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.AddForce(directionF.forward * strength);
            foreach (TrailRenderer T in tyreMarks)
            {
                T.emitting = false;
            }
        }

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            switch (touch.phase)
            {               
                case TouchPhase.Began:                   
                    startPos = touch.position;
                    eulerAngY = this.gameObject.transform.localEulerAngles.y;
                    //collisionBool = false;
                    break;
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    if (direction.y < -600f)
                    {
                        speedHolder = 599f;
                    }
                    else if ((direction.y > -600f))
                    {
                        
                        if ((direction.y > 0))
                        {
                            speedHolder = -1 *direction.y;
                        }
                        else
                        {
                            speedHolder = direction.y;
                        }
                    }
                   
                    speedBarValue = -1 * speedHolder / 600f;

                    this.gameObject.transform.rotation = Quaternion.Euler(transform.rotation.x, (-200 * (direction.x / 350f)) + eulerAngY, transform.rotation.z);
                    speedBar.fillAmount = speedBarValue;

                    //timeBool = true;
                    //pitchBool = true;
                    break;
                case TouchPhase.Ended:
                    audioSource1.clip = clips[1];

                    pitchBool = false;
                    timeBool = false;

                    audioSource1.Play();
                    audioSource1.loop = true;
                    audioSource2.clip = clips[0];
                    audioSource2.Play();
                    speedCar = 500f * (speedBarValue / 1);
                    rb.AddForce(directionF.forward * speedCar);
                    foreach (TrailRenderer T in tyreMarks)
                    {
                        T.emitting = false;
                    }
                    // motorspeed.text = "Speed:"+speedBarValue.ToString();
                    
                    audioSource1.clip = clips[1];

                    pitchBool = false;
                    timeBool = false;

                    audioSource1.Play();
                    audioSource1.loop = true;
                    audioSource2.clip = clips[0];
                    audioSource2.Play();
                    shots += 1;
                    info.text = shots.ToString();
                    rotSpeed.text = "PTR: " + speedCar.ToString();
                    speedBar.fillAmount = 0;
                    //Invoke("stopCar", 3f);
                    break;
        }
        }
    }

   
    public void OnCollisionEnter(Collision collision)
    {
        
        if(collision.relativeVelocity.magnitude > 1)
        {
            foreach(TrailRenderer T in tyreMarks)
            {
                T.emitting = true;
                audioSource1.loop = false;
                audioSource1.Stop();
                 
                audioSource1.clip = brakeSound;
                audioSource1.Play();
                
            }
        }      
    }
}
