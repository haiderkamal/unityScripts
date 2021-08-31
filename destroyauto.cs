using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyauto : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("food"))
        {
            Destroy(this.gameObject);
        }
        if (other.CompareTag("nnn"))
        {
            Destroy(other.gameObject);
        }
    }

   
}
