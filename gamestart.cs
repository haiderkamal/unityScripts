using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamestart : MonoBehaviour {

	public GameObject menu;
	public GameObject menutwo;
    public GameObject menuthree;
    public GameObject menulevelselect;
	public snakemovements loader;
    public autosize planet;
    public AudioSource Audio;
    public AudioClip[] audioClip;
    public GameObject radialscore;
    public GameObject levels;
    public bool starter;
  //  public ADS adds;
    //public DataInserter dataInserter;
    void Start () {
        starter = true;
        radialscore.SetActive(false);
        levels.SetActive(false);
        planet.size = false;
        //dataInserter.uploadScore();

    }
    void PlaySound(int clip)
    {
        Audio.clip = audioClip[clip];
        Audio.Play();
    }
    public void optionss() {
        menu.SetActive(false);
        PlaySound(0);

    }
    public void starterr(){
    
            
          levels.SetActive(true);
          menu.SetActive(false);
          menulevelselect.SetActive(false);
          PlaySound(0);

}
	public void play(){
        if (starter == true)
        {
            //dataInserter.uploadScore();
            levels.SetActive(false);

            radialscore.SetActive(true);
            menuthree.SetActive(false);
            menutwo.SetActive(false);
            PlaySound(0);
            loader.speed = 2;
            menu.SetActive(false);
            planet.size = true;
            planet.starter();
            radialscore.SetActive(true);
            levels.SetActive(false);
        }
        starter = false;

	}
    public void home() {
        menu.SetActive(true);
        menuthree.SetActive(false);
        menutwo.SetActive(false);
        menulevelselect.SetActive(false);

     }

    



    public void level()
    {
       // menu.SetActive(false);
        menuthree.SetActive(false);
        menutwo.SetActive(false);
        menulevelselect.SetActive(true);
        PlaySound(0);


    }
    
    public void shop()
    {
       // menu.SetActive(false);
        menutwo.SetActive(true);
        PlaySound(0);


    }
    public void shopclose()
    {
        // menu.SetActive(false);
        menu.SetActive(true);

        menutwo.SetActive(false);
        menulevelselect.SetActive(false);
        PlaySound(0);


    }
    public void coinshop()
    {
       // menu.SetActive(false);
        menutwo.SetActive(false);
        menuthree.SetActive(true);
        PlaySound(0);

    }
	public void playerone(){
        menuthree.SetActive(false);
		menutwo.SetActive (false);
        menulevelselect.SetActive(false);

		 
	}
	
	
}
