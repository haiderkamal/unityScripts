using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class clr : MonoBehaviour {
    public Color[] colors;
   
	public void hello () {
        GetComponent<Image>().color = colors[Random.Range(0, colors.Length)];
	}
	
}
