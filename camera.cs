using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
	public GameObject cam1;
	public GameObject cam2;
	public GameObject cam3;
	private int camnumber = 1;
	// Use this for initialization
	void Start () {
		cam1.SetActive (true);
		cam2.SetActive (false);
        cam3.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (camnumber > 2) {
			camnumber = 1;}
	}

	public void cameraselector(){
	
		camnumber += 1;

		if (camnumber == 2) {
			cam1.SetActive (false);
			cam3.SetActive (true);
		}

        if (camnumber == 1)
        {
            cam1.SetActive(true);
            cam3.SetActive(false);
        }
		
	
	
	}
}
