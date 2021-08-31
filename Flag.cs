using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject[] flagFace;
    public float time;
    public int i;
    public GameObject flagModel;
    public Transform target1;
    public Transform target2;
    public float speed;
    public bool near;
    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
        i = 0;
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.05f)
        {
           
            flagFace[i].SetActive(false);
            i += 1;
            if (i == 19)
            {
                i = 0;
            }
            flagFace[i].SetActive(true);
            time = 0;
        }
        if(near == true) { 
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target1.position, step);
        }
        else
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target2.position, step);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            near = true; 
        }
        else
        {
            near = false;
        }
    }
}
