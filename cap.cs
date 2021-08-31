using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cap : MonoBehaviour {
	public GameObject body;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}void OnTrigger(Collider other)
	{
		if (other.gameObject.tag == "mainsnake" ) {
			Destroy (other.gameObject);
			body.SetActive(false);


	}
	}}
