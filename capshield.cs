using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capshield : MonoBehaviour {
    public snakemovements script;
    public GameObject shield;
    public GameObject shield1;
    
	// Use this for initialization
	void Start () {
        shield.SetActive(false);
        shield1.SetActive(false);
        script = GameObject.FindGameObjectWithTag("mainsnakeoo").GetComponent<snakemovements>();
	}
	
	// Update is called once per frame
	void Update () {
        if (script.spchek == true) {

            shield.SetActive(true);
            shield1.SetActive(true);
        }
        if (script.spchek == false)
        {

            shield.SetActive(false); 
            shield1.SetActive(false);
        }
	}
}
