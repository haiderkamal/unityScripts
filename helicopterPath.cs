using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helicopterPath : MonoBehaviour
{
    // Array of waypoints to walk from one to the next one
    [SerializeField]
    public Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    public float moveSpeed = 2f;

    // Index of current waypoint from which Enemy walks
    // to the next one
    public int waypointIndex = 0;
    public Vector3 relativeVector;
    // Use this for initialization
    private void Start()
    {

        // Set position of Enemy as position of the first waypoint
      //  waypointIndex = waypoints.Length;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if (waypointIndex < waypoints.Length)
        {
            if (transform.position != waypoints[waypointIndex].transform.position)
            {

                // Move Enemy from current waypoint to the next one
                // using MoveTowards method
                this.transform.position = Vector3.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);


                relativeVector = ((this.waypoints[waypointIndex].transform.position) - (this.gameObject.transform.position));
                this.gameObject.transform.rotation = Quaternion.LookRotation(relativeVector);
            }
            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
           else if (transform.position == waypoints[waypointIndex].transform.position)
            {
                relativeVector = ((this.waypoints[waypointIndex+1].transform.position) - (this.gameObject.transform.position));
                this.gameObject.transform.rotation = Quaternion.LookRotation(relativeVector);
            }
        }
        
    }
}
