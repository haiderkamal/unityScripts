using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour {
	
	void Update(){
        transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
	}
		void OnTriggerEnter(Collider other)
	{
		
		if (other.CompareTag ("mainsnake")) {
			//Destroy (this.gameObject);
		}
		
       // if (other.CompareTag("water"))
        //{
           
         //   Destroy(this.gameObject);
        //}
       
	}






}