using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forward : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.position += transform.forward * 0.05f;
    }
}
