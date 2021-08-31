using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class restartscript : MonoBehaviour {
	public snakemovements saver;
    //public ADS adds;
    //public DataInserter dataInserter;
    public GameObject creditsCanvas;
	void Start () {
	//	saver = GameObject.FindGameObjectWithTag ("mainsnakeo").GetComponent<snakemovements> ();
      //  adds = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ADS>();
        //dataInserter = GameObject.FindGameObjectWithTag("multiplayer").GetComponent<DataInserter>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void startgame()
    {
       // uperietms.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void restartgame()
    {

        
        //uperietms.SetActive(false);
       
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //dataInserter.uploadScore();

        }
        else {
           // adds.RequestInterstitial();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //dataInserter.uploadScore();

        
        }

		
	}
    public void showCredits()
    {
        creditsCanvas.SetActive(true);

    }
	public void exitgame(){
		Application.Quit();
	}
}
