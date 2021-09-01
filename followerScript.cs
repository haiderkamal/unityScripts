using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerScript : MonoBehaviour
{
    public GameObject mainPlayer;
    public bool isRunning;
    public Animator animator;
    public Rigidbody rigidBody;
    public Vector3 offset;
    public GameObject FollowThisObj;
    private Touch touch;
    public bool isTouched;
    public AudioClip[] audio;
    public AudioSource audiocsource;
    public void Awake()
    {
        mainPlayer = GameObject.Find("MainPlayerPool");
        FollowThisObj = GameObject.Find("FollowThis");
        audiocsource = mainPlayer.GetComponent<AudioSource>();
        //audiocsource = this.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        this.transform.position = mainPlayer.transform.position+offset;
        //Invoke("Disable", 2f);
    }


    void Start()
    {
        // mainPlayer = GameObject.Find("MainPlayer");
        rigidBody = this.GetComponent<Rigidbody>();
         animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            isTouched = true;
            touch = Input.GetTouch(0);
        }
        else if (Input.touchCount <= 0)
        {
            isTouched = false;
            this.animator.SetBool("isRunning", false);
        }
        if (isTouched == true)
        {

            this.animator.SetBool("isRunning", true);
        }
            //this.transform.position = Vector3.MoveTowards(transform.position, mainPlayer.transform.position, 0.1f);
            rigidBody.AddForce((FollowThisObj.transform.position - this.transform.position) * (40f));
        if (isRunning == true)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            //audiocsource.clip = audio[0];
            audiocsource.Play();
            Invoke("Disable", 0.005f);
           
            

        } if (other.CompareTag("enemyPlayer"))
        {
            //audiocsource.clip = audio[0];
            audiocsource.Play();
            Invoke("Disable", 0.005f);
            //Disable();
            

           
        }
    }
    void Disable()
    {
       
        this.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
}
