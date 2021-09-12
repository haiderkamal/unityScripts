using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class flee : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public float enemydistance;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distance);
        if(distance < enemydistance)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newpos = transform.position + dirToPlayer;
            agent.SetDestination(newpos);
        }
        
    }
}
