using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinbuy : MonoBehaviour
{
    public snakemovements playerscript;
   
    //public ADS un;
    // Use this for initialization
    void Start()
    {
        playerscript = GameObject.FindGameObjectWithTag("mainsnakeo").GetComponent<snakemovements>();
        //advideos = GameObject.FindGameObjectWithTag("Ad").GetComponent<ADS>();
      //  un = GameObject.FindGameObjectWithTag("Ad").GetComponent<unityads>();

        
    }

    // Update is called once per frame
    
    public void coin1()
    {
      //  un.freeCoins();
        
        
    }
    public void coin2()
    {

       
            playerscript.scorer += 50;
        
    }
    public void coin3()
    {

      
            playerscript.scorer += 100;
        
    }
    public void coin4()
    {

       
            playerscript.scorer += 200;
        
    }
    public void coin5()
    {

      
            playerscript.scorer += 500;
        
    }
    public void coin6()
    {

     
            playerscript.scorer += 500;
       
    }
}
