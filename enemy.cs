using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public Vector3 offset;
    public GameObject targetPole;
    public Animator animator;
    public Rigidbody rigidBody;
    public bool targetset;
    public AudioClip[] audio;
    public AudioSource audiocsource;
    public void Awake()
    {
        targetset = false;
    }
    public void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        animator = this.gameObject.GetComponent<Animator>();
         
    }
    public void Update()
    {
        if (targetset == true)
        {
            rigidBody.AddForce((targetPole.transform.position - this.transform.position) * (40f));
        }
    }
    private void OnEnable()
    {
        targetset = true;
        if (targetPole != null)
        {
            this.transform.position = targetPole.transform.position + offset;
        }
        //Invoke("Disable", 2f);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("follower"))
        {
            //Invoke("Disable", 0.01f);
            Disable();
            
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
