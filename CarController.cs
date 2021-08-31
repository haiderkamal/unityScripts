using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CarController : MonoBehaviour 
{
    public GameObject[] vehicleList;
    public GameObject SelectedCar;
    public Image joystick;
    public Rigidbody rb;
    public Vector3 myVelocity;


    private Touch touch;
    public float speed;
    public Vector2 startPos;
    public Vector2 direction;
    public Text info;
    public Text motorspeed;
    public Text rotSpeed;
    public Image speedBar;
    public float speedBarValue;
    public WheelCollider[] wheels;
    public GameObject ArrowDirection;
    public float time;
    public bool timeBool;
    public AudioSource  audioSource1;
    public AudioSource  audioSource2;
    public AudioSource  audioSource3;
    public AudioClip[] clips;
    public AudioClip brakeSound;
    public AudioClip hitSound;
    public float pitchValue;
    public bool pitchBool;
    public bool brakes;
    public float eulerAngY;
    public GameObject wheelShapeL;
    public GameObject wheelShapeR;
    public bool collisionBool;
    public bool collisionWaitBool;
    public float collisionWaitTime;
    public int f;
    public float speedCar;
    public bool speedCarBool;
    public cameraFollow cam;
    public float speedHolder;
    public int shots;
    // Start is called before the first frame update
    void Start()
    {
        rb = SelectedCar.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -0.3F, 0);
        speed = 1f;
        time = 0.2f;
        timeBool = false;
        brakes = false;
        collisionBool = false;
        collisionWaitBool = false;
        collisionWaitTime = 0f;
        speedCar =0;
        speedCarBool = false;
        cam = cam.gameObject.GetComponent<cameraFollow>();
        shots = 0;
        for (int i = 0; i < wheels.Length; ++i)
        {
            var wheel = wheels[i];

            // create wheel shapes only when needed
            if (wheelShapeL != null)
            {

                var wsL = GameObject.Instantiate(wheelShapeL);
                var wsR = GameObject.Instantiate(wheelShapeR);
                if (i == 1)
                {
                    wsL.transform.parent = wheel.transform;
                }
                if (i == 2)
                {
                    wsL.transform.parent = wheel.transform;
                }
                if (i == 0)
                {
                    wsR.transform.parent = wheel.transform;
                }
                if (i == 3)
                {
                    wsR.transform.parent = wheel.transform;
                }

            }
        }
    }




    private void FixedUpdate()
    {
        SelectedCar.transform.Translate(Vector3.forward * speedCar);
    }
    // Update is called once per frame
    void Update()
    {
        if(speedCarBool == true)
        {
            speedCar -= (Time.deltaTime/20);
            //motorspeed.text = "Time:" + speedCar.ToString();
            if (speedCar < 0)
            {
                speedCar = 0;
                audioSource1.Stop();
                
            }
        }
        
        foreach (WheelCollider wheel in wheels)
        {
             
            if (wheelShapeR)
            {
                Quaternion q;
                Vector3 p;
                wheel.GetWorldPose(out p, out q);

                // assume that the only child of the wheelcollider is the wheel shape
                Transform shapeTransform = wheel.transform.GetChild(0);
                shapeTransform.position = p;
               // shapeTransform.rotation =  Quaternion.Euler(speedCar*1000,SelectedCar.transform.localEulerAngles.y, SelectedCar.transform.localEulerAngles.z);
                shapeTransform.Rotate(speedCar * 100, 0, 0);
            }

        }
        if (pitchBool == true)
        {
            pitchValue = 1.5f * speedCar / 0.3f ;
            //pitchValue = 1.5f * speedBarValue/1f ;
            //pitchValue = 1.5f * (time/20f);

           // rotSpeed.text = speedBarValue.ToString();
           // audioSource1.pitch = pitchValue;
           // audioSource1.volume = pitchValue;
            // audioSource1.volume = pitchValue;
        }
        if(pitchBool == false)
        {

            //time -= (0.1f );
           // speedBarValue -= (0.05f );
            //pitchValue = 1.5f * (time / 20f);
            pitchValue = 1.5f * (speedCar / 0.3f);
            if (pitchValue < 0.6f)
            {
                pitchValue = 0.6f;
            }
            audioSource1.pitch = pitchValue;
            audioSource1.volume = pitchValue/3;
             
            // if (time < 0)
            // {
            //     time = 0;
            // } 
            if (speedBarValue < 0)
            {
                speedBarValue = 0;
            }
           // rotSpeed.text = speedBarValue.ToString();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            wheels[0].brakeTorque = 0;
            wheels[1].brakeTorque = 0;
            wheels[2].brakeTorque = 0;
            wheels[3].brakeTorque = 0;
             
            
           
            timeBool = true;
            pitchBool = true;
            collisionBool = false;
        }
        if(timeBool == true)
        {
            time += 0.1f;
            if (time > 20)
            {
                time = 20;
                timeBool = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            wheels[0].brakeTorque = 0;
            wheels[1].brakeTorque = 0;
            wheels[2].brakeTorque = 0;
            wheels[3].brakeTorque = 0;
           
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            wheels[0].brakeTorque = 0;
            wheels[1].brakeTorque = 0;
            wheels[2].brakeTorque = 0;
            wheels[3].brakeTorque = 0;
            //    wheels[0].steerAngle = (45  );
            //    wheels[1].steerAngle = (45  );
            SelectedCar.transform.rotation = Quaternion.Euler(transform.rotation.x, (5 + SelectedCar.transform.rotation.y), transform.rotation.z);


        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            wheels[0].brakeTorque = 0;
            wheels[1].brakeTorque = 0;
            wheels[2].brakeTorque = 0;
            wheels[3].brakeTorque = 0;
            SelectedCar.transform.rotation = Quaternion.Euler(transform.rotation.x, (5 - SelectedCar.transform.rotation.y), transform.rotation.z);

            //  wheels[0].steerAngle = (-45  );
            //  wheels[1].steerAngle = (-45  );

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            wheels[0].steerAngle = (0);
            wheels[1].steerAngle = (0);
        }if (Input.GetKeyUp(KeyCode.D))
        {
            wheels[0].steerAngle = (0);
            wheels[1].steerAngle = (0);
        }


        /*

       
                    if (Input.GetKeyUp(KeyCode.W))
                {

                    wheels[2].motorTorque = time * 5;
                    wheels[3].motorTorque = time  * 5;

                    audioSource1.clip = clips[1];

                    pitchBool = false;
                    timeBool = false;

                    audioSource1.Play();
                    audioSource1.loop = true;
                    audioSource2.clip = clips[0];
                    audioSource2.Play();
                    motorspeed.text = wheels[2].motorTorque.ToString();

                    Invoke("stopCar", 3f);






                }

        */
               if (Input.GetKeyUp(KeyCode.W))
               {

                   speedCar = 0.3f;
                   speedCarBool = true;
                   audioSource1.clip = clips[1];

                   pitchBool = false;
                   timeBool = false;

                   audioSource1.Play();
                   audioSource1.loop = true;
                   audioSource2.clip = clips[0];
                   audioSource2.Play();
         //   motorspeed.text = "Speed:" + speedBarValue.ToString();
            shots += 1;
            info.text = shots.ToString();
            rotSpeed.text = "PTR: " + speedCar.ToString();
        }
          
        if (Input.GetKeyUp(KeyCode.S))
                                     {
                                         wheels[2].motorTorque = -time * 8;
                                         wheels[3].motorTorque = -time * 8;

                                         audioSource1.clip = clips[1];

                                         pitchBool = false;
                                         timeBool = false;

                                         audioSource1.Play();
                                         audioSource1.loop = true;
                                         audioSource2.clip = clips[0];
                                         audioSource2.Play();
                                          

                                         Invoke("stopCar", 3f);
                                     }
                                     if (Input.touchCount > 0)
                                     {
                                         touch = Input.GetTouch(0);

                                         switch (touch.phase)
                                         {
                                             //When a touch has first been detected, change the message and record the starting position
                                             case TouchPhase.Began:
                                                 // Record initial touch position.
                                                 startPos = touch.position;
                                                
                                                 eulerAngY = SelectedCar.transform.localEulerAngles.y;
                                                 collisionBool = false;
                                                 break;

                                             //Determine if the touch is a moving touch
                                             case TouchPhase.Moved:
                                                 // Determine direction by comparing the current touch position with the initial one
                                                 direction = touch.position - startPos;
                                                if (direction.y < -300f)
                                                {
                                                    speedHolder = 300f;
                                                }
                                                else if ((direction.y > -300f))
                                                {
                                                    speedHolder = direction.y;
                                                }
                                                
                              speedBarValue = -1 * speedHolder / 300f;
                     
                      SelectedCar.transform.rotation = Quaternion.Euler(transform.rotation.x,( -200 * (direction.x/350f)) + eulerAngY, transform.rotation.z);
                        


                   
                    speedBar.fillAmount = speedBarValue;
                    
                    timeBool = true;
                    pitchBool = true;
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    //rb.AddForce(direction * speed);
                
                    if (direction.y > 0)
                    {
                       
                        //rb.AddForce(10 * direction.x, 0, -10 * direction.y);
                       // wheels[2].steerAngle = (45 * (direction.x / 400));
                       // wheels[3].steerAngle = (45 * (direction.x / 400));

                       // rotSpeed.text = wheels[0].steerAngle.ToString();
                     //   wheels[0].motorTorque =  speedBarValue* ( 30)  * 300;
                      //  wheels[1].motorTorque = speedBarValue * ( 30) * 300;
                      //  motorspeed.text = wheels[0].motorTorque.ToString();
                    }
                    else
                    {
                         
                        audioSource1.clip = clips[1];

                        pitchBool = false;
                        timeBool = false;

                        audioSource1.Play();
                        audioSource1.loop = true;
                        audioSource2.clip = clips[0];
                        audioSource2.Play();
                        //rb.AddForce(-10 * direction.x, 0, -10 * direction.y);
                        // wheels[0].steerAngle = (-45 * (direction.x / 400));
                        // wheels[1].steerAngle = (-45 * (direction.x / 400));
                        //rotSpeed.text = wheels[0].steerAngle.ToString();
                        //  wheels[2].motorTorque = speedBarValue * ( 10) * 10;
                        //  wheels[3].motorTorque = speedBarValue * ( 10) * 10;
                        // 
                        // motorspeed.text = wheels[2].motorTorque.ToString();
                        //motorspeed.text = speedBarValue.ToString();


                        speedCar = 0.3f *(speedBarValue/1);
                       // motorspeed.text = "Speed:"+speedBarValue.ToString();
                        speedCarBool = true;
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

                    }



                   
                    speedBar.fillAmount = 0;
                    //Invoke("stopCar", 3f);
                    break;
            }



           

        }
        if (brakes == true)
        {
            if ((SelectedCar.GetComponent<Rigidbody>().velocity.magnitude) < 0.1f)
            {

                audioSource1.loop = false;
                audioSource1.Stop();
                brakes = true;
                audioSource1.clip = brakeSound;
                audioSource1.Play();
                brakes = false;
            }
            if (collisionBool == false)
            {
                if (wheels[2].rpm < 10)
                {
                    audioSource1.loop = false;
                    audioSource1.Stop();
                    brakes = true;
                    audioSource1.clip = brakeSound;
                    audioSource1.Play();
                    brakes = false;
                   
                }
            }
        }


        
        
        if(collisionWaitBool == true)
        {
            collisionWaitTime += (2*Time.deltaTime);
            if (collisionWaitTime >= 1)
            {
                collisionWaitBool = false;
            }
        }
        
    }
    public void OnCollisionEnter(Collision collision)
    {

        speedCar -= 0.1f;

        cam.enableShake();
        f += 1;
        
        if (collisionWaitBool == false)
        {

            
           
            
            audioSource3.clip = hitSound;
            audioSource3.Play();

            float y1 = SelectedCar.transform.eulerAngles.y;
                float y2 = (90 - y1);
                float y3 = (90 + y2);

                
                SelectedCar.transform.eulerAngles = new Vector3(SelectedCar.transform.eulerAngles.x, (-1*y1), transform.eulerAngles.z);
            // wheels[2].motorTorque = 0;
            // wheels[3].motorTorque = 0;

            //  wheels[2].motorTorque = time * 5;
            //       wheels[3].motorTorque = time  * 5;

           // collisionBool = true;
            collisionWaitBool = true;
                //SelectedCar.transform.rotation = Quaternion.Euler(transform.rotation.x, 180 + eulerAngY, transform.rotation.z);
             


        }



        if (collision.gameObject.CompareTag("nearGoal"))
        {

        }
        else if(collision.relativeVelocity.magnitude > 3f) {
            // SelectedCar.transform.rotation = Quaternion.Euler(transform.rotation.x, 180 + eulerAngY, transform.rotation.z);
           
         //   collisionBool = true;
         //   audioSource3.loop = false;
          //  audioSource3.clip = hitSound;
          //  audioSource3.Play();
          //  rotSpeed.text = collision.relativeVelocity.magnitude.ToString();

        }
        




    }
    public void stopCar()
    {
      
    //    wheels[0].steerAngle = 0;
    //    wheels[1].steerAngle = 0; 
     //   wheels[2].steerAngle = 0;
     //   wheels[3].steerAngle = 0;
        
    //    wheels[2].motorTorque = 0;
     //   wheels[3].motorTorque = 0;
     //   wheels[0].brakeTorque = 200;
      //  wheels[1].brakeTorque = 200;
      //  wheels[2].brakeTorque = 200;
     //   wheels[3].brakeTorque = 200;
        brakes = true;

       // speedBarValue = 0.1f;
       //pitchBool = true;
       //pitchValue = 1;

        
        
    }
    
}
