using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class restarta : MonoBehaviour {
    public ADS adscript;
    public GameObject adds;
    public float h;
    public Text score;
	// Use this for initialization
	void Start () {
       
        adscript = GameObject.FindGameObjectWithTag("Main").GetComponent<ADS>();
        h = Random.Range(5.0f, 20.0f);

    }
	
	// Update is called once per frame
/*	void Update () {
        h =h + (0.1f * Time.deltaTime);
        score.text = h.ToString();
        if (h >= 10.0)
        {
            h = Random.Range(0.0f, 20.0f);

            adscript.RequestInterstitial();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
		
	}*/
}
