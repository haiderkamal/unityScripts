using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pill : MonoBehaviour
{
    public GameObject[] pillss;
        
    public float ttt;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            pillss[i].SetActive(false);
          
        }
    }
    // Update is called once per frame
    void Update()
    {
        ttt += Time.deltaTime;
        if (ttt >= 10f)
        {
            pillss[0].SetActive(true);
            pillss[1].SetActive(true);
            pillss[2].SetActive(true);
            pillss[3].SetActive(true);
          
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("mainsnake")){
            ttt = 0f;
            pillss[0].SetActive(false);
            pillss[1].SetActive(false);
            pillss[2].SetActive(false);
            pillss[3].SetActive(false);

            Update();
        }
    }
}