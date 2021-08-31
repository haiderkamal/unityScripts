using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animplay : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("mainsnake"))
        {
            anim.Play("animation1", -1, 2000f);
        }
    }
}
