using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Touch touch;
    private float speed;
    public Animator animator;
    public Rigidbody rb;
    public float speedF;
    public float AngularSpeed;
    public bool isTouched;
    public GameObject followerPrefab;
    public GameObject[] newFollowers;
    public int followersCount;
    // Start is called before the first frame update
    void Start()
    {
        
        speed = 0.1f;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            isTouched = true;
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {

                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speed,
                    transform.position.y,
                    transform.position.z);
                speedF = rb.velocity.magnitude;
                AngularSpeed = rb.angularVelocity.magnitude;

            }

        }
        else
        {
            isTouched = false;
            animator.SetBool("isRunning", false);
            if (followersCount > 0)
            {
                foreach (var item in newFollowers)
                {
                    if (item != null)
                    {
                        item.GetComponent<followerScript>().isRunning = false;
                    }
                }
            }
        }
            if (isTouched == true)
            {
                animator.SetBool("isRunning", true);
            if (followersCount > 0)
            {
                foreach (var item in newFollowers)
                {
                    if (item != null)
                    {
                        item.GetComponent<followerScript>().isRunning = true;
                    }
                }
            }
                playerController.ApplyForceToReachVelocity(rb, Vector3.forward * 15, 50);
            }
        
    }
    public static void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velocity, float force = 1, ForceMode mode = ForceMode.Force)
    {
        if (force == 0 || velocity.magnitude == 0)
            return;

        velocity = velocity + velocity.normalized * 0.2f * rigidbody.drag;

        //force = 1 => need 1 s to reach velocity (if mass is 1) => force can be max 1 / Time.fixedDeltaTime
        force = Mathf.Clamp(force, -rigidbody.mass / Time.fixedDeltaTime, rigidbody.mass / Time.fixedDeltaTime);

        //dot product is a projection from rhs to lhs with a length of result / lhs.magnitude https://www.youtube.com/watch?v=h0NJK4mEIJU
        if (rigidbody.velocity.magnitude == 0)
        {
            rigidbody.AddForce(velocity * force, mode);
        }
        else
        {
            var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody.velocity) / velocity.magnitude);
            rigidbody.AddForce((velocity - velocityProjectedToTarget) * force, mode);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ten"))
        {
            add10Followers();
            Destroy(other.gameObject);
        }
    }
    public void add10Followers()
    {
        followersCount += 10;
        for (int i = 0; i < 10; i++)
        {
            newFollowers[i] = Instantiate(followerPrefab);
            if (i % 2 == 0)
            {
                newFollowers[i].GetComponent<followerScript>().offset = new Vector3((i + 1), 0, 0);
            }
            else if (i % 2 == 1)
            {
                newFollowers[i].GetComponent<followerScript>().offset = new Vector3((-i - 1), 0, 0);
            }
        }
    }
}
