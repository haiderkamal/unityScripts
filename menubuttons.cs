using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class menubuttons : MonoBehaviour {
    public Image planet_img;
    public Sprite[] planet_sprites;
    public Image snake_img;
    public Sprite[] snake_sprites;
    public Image GLOBE;
    public Sprite[] GLOBE_sprite;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void changeimg1() {
       GLOBE.sprite = GLOBE_sprite[0];
        planet_img.sprite = planet_sprites[0]; 
   
    }
  public void changeimg2()
    {
        GLOBE.sprite = GLOBE_sprite[1];

        planet_img.sprite = planet_sprites[1];
    }
  public void changeimg3()
    {
        GLOBE.sprite = GLOBE_sprite[2];

        planet_img.sprite = planet_sprites[2];
    }
  public void changeimg4()
    {
        GLOBE.sprite = GLOBE_sprite[3];

        planet_img.sprite = planet_sprites[3];
    }
  public void changeimg5()
    {
        GLOBE.sprite = GLOBE_sprite[4];

        planet_img.sprite = planet_sprites[4];
    }
//--------------------------------------------------------------------------------------------------------------//
  public void changeimg11()
  {
      snake_img.sprite = snake_sprites[0];
  }
  public void changeimg22()
  {
      snake_img.sprite = snake_sprites[1];
  }
  public void changeimg33()
  {
      snake_img.sprite = snake_sprites[2];
  }
  public void changeimg44()
  {
      snake_img.sprite = snake_sprites[3];
  }
  public void changeimg55()
  {
      snake_img.sprite = snake_sprites[4];
  }
}
