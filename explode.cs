using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour {
    public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mainsnake"))
        {
            this.explosion.SetActive(true);

            Invoke("destroy", 0.5f);
            
        
        }
    }
    public void destroy() {
        Destroy(this.gameObject);
    }
}
