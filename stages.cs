using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stages : MonoBehaviour {
    public GameObject fence;
    public GameObject river;
    public GameObject trees;
    public GameObject well;
    public GameObject gasspill1;
    public GameObject gaspill2;
    public GameObject gaspill3;
    public GameObject gaspill4;
    public GameObject mountains;
    public GameObject henkeeper;
    public GameObject water;
    public GameObject land;
    public GameObject waterboundries;
    public GameObject foodgenland;
    public GameObject foodgenwater;
    public GameObject buymore;
    public int a1 = 0;
    public int a2 = 0;
    public int a3 = 0;
    public int a4 = 0;
    public int a5 = 0;
    public int a6 = 0;
    public int a7 = 0;
    public int levelscore;
    public colorchanger timerchanger;

    public Image[] imge;
    public Sprite[] spri;
    public Sprite disableimg;

    public Text minus;
    public GameObject minuss;
    public gamestart starter;
    public snakemovements snakescriptt;

	// Use this for initialization
	public void Start () {
        levelscore += snakescriptt.scorer;
        minuss.SetActive(false);
        snakescriptt = GameObject.FindGameObjectWithTag("mainsnakeoo").GetComponent<snakemovements>();
        fence.SetActive(false);
        river.SetActive(false);
        trees.SetActive(false);
        well.SetActive(false);
        gasspill1.SetActive(false);
        gaspill2.SetActive(false);
        gaspill3.SetActive(false);
        gaspill4.SetActive(false);
        mountains.SetActive(false);
        henkeeper.SetActive(false);
        water.SetActive(false);
       //land.SetActive(false);
        waterboundries.SetActive(false);
        foodgenland.SetActive(false);
        foodgenwater.SetActive(false); 

	}
	
	// Update is called once per frame
    void Update()
    {
        if (a1 >= 1)
        {
            imge[1].sprite = spri[1];
        }
        if (a2 >= 1)
        {
            imge[2].sprite = spri[2];

        }
        if (a3 >= 1)
        {
            imge[3].sprite = spri[3];

        }
        if (a4 >= 1)
        {
            imge[4].sprite = spri[4];

        }
        if (a5 >= 1)
        {
            imge[5].sprite = spri[5];

        }
        if (a6 >= 1)
        {
            imge[6].sprite = spri[6];

        }
        if (a7 >= 1)
        {
            imge[7].sprite = spri[7];

        }
    }

    public void one()
    {
        timerchanger.countdownn = 100f;
        fence.SetActive(true);
        gasspill1.SetActive(true);
        foodgenland.SetActive(true);
        land.SetActive(true);
        starter.play();
    }
    public void two()
    {
        if (snakescriptt.scorer >= 20)
        {
            a1 = 1;
                    }
        if (a1 == 1)
        {

            land.SetActive(true);
            gasspill1.SetActive(true);
            gaspill2.SetActive(true);

            timerchanger.countdownn = 200f;
            fence.SetActive(true);
            trees.SetActive(true);
            foodgenland.SetActive(true);
            starter.play();
        }
        else if (snakescriptt.scorer <= 20)
        {
            a1 = 0;
            minus.text = "You Need " + (20 - snakescriptt.scorer).ToString() + " Gold Coins To Unlock This Level";
            minuss.SetActive(true);
        }
    }
    
    public void three()
    {
         if (snakescriptt.scorer >= 40)
        {
            if (a1 == 1)
            {
            a2 = 1;
            }
            else if (a1 == 0)
            {
                minus.text = "Complete Previous Level First";
                minuss.SetActive(true);
            }
        }
         if (a2 == 1)
         {
             
                 starter.play();
                 land.SetActive(true);
                 well.SetActive(true);
                 gasspill1.SetActive(true);
                 gaspill2.SetActive(true);
                 timerchanger.countdownn = 300f;
                 fence.SetActive(true);
                 trees.SetActive(true);
                 mountains.SetActive(true);
                 foodgenland.SetActive(true);
                 starter.play();
             
            
         }
         else  if (snakescriptt.scorer <=40)
        {
            minus.text = "You Need " + (40 - snakescriptt.scorer).ToString() + " Gold Coins To Unlock This Level";
             minuss.SetActive(true);
        }
       
    }
    public void four()
    { if (snakescriptt.scorer >= 60)
        {
            
            if (a2 == 1)
            {
                a3 = 1;
            }
            else if (a2 == 0)
            {
                minus.text = "Complete Previous Level First";
                minuss.SetActive(true);
            }
        }
         if (a3 == 1)
         {
            starter.play();
            land.SetActive(true);
            well.SetActive(true);
            gasspill1.SetActive(true);
            gaspill2.SetActive(true);
            gaspill3.SetActive(true);
            timerchanger.countdownn = 400f;
            fence.SetActive(true);
            trees.SetActive(true);
            mountains.SetActive(true);
            henkeeper.SetActive(true);
            foodgenland.SetActive(true);
            starter.play();
         }
             else if (snakescriptt.scorer <=60)
        {
            minus.text = "You Need " + (60 - snakescriptt.scorer).ToString() + " Gold Coins To Unlock This Level";
                 minuss.SetActive(true);
        }
       
    }
    public void five()
    {
        if (snakescriptt.scorer >= 80)
        {
            
            if (a3 == 1)
            {
                a4 = 1;
            }
            else if (a3 == 0)
            {
                minus.text = "Complete Previous Level First";
                minuss.SetActive(true);
            }
        }
        if (a4 == 1)
        {
            a4 = 1;
            starter.play();

            land.SetActive(true);
            well.SetActive(true);
            gasspill1.SetActive(true);
            gaspill2.SetActive(true);
            gaspill3.SetActive(true);
            gaspill4.SetActive(true);
            timerchanger.countdownn = 500f;
            fence.SetActive(true);
            trees.SetActive(true);
            mountains.SetActive(true);
            henkeeper.SetActive(true);
            river.SetActive(true);
            foodgenland.SetActive(true);
            starter.play();
        }
        else if (snakescriptt.scorer <= 80)
        { minus.text = "You Need " + (80 - snakescriptt.scorer).ToString() + " Gold Coins To Unlock This Level";
        minuss.SetActive(true);
        }
       
    }
    public void six()
    {
         if (snakescriptt.scorer >= 100)
        {
            
            if (a4 == 1)
            {
                a5 = 1;
            }
            else if (a4 == 0)
            {
                minus.text = "Complete Previous Level First";
                minuss.SetActive(true);
            }
        }
         if (a5 == 1)
         {
             a5 = 1;
             starter.play();

             land.SetActive(true);
             well.SetActive(true);
             gasspill1.SetActive(true);
             gaspill2.SetActive(true);
             gaspill3.SetActive(true);
             gaspill4.SetActive(true);
             timerchanger.countdownn = 1000f;
             fence.SetActive(true);
             trees.SetActive(true);
             mountains.SetActive(true);
             henkeeper.SetActive(true);
             river.SetActive(true);
             foodgenland.SetActive(true);
             starter.play();
         }
        else if (snakescriptt.scorer >= 0)
        {
            minus.text = "You Need " + (100 - snakescriptt.scorer).ToString() + " Gold Coins To Unlock This Level";
            minuss.SetActive(true);
        }
        
    }
    public void seven()
    {  if (snakescriptt.scorer >= 150)
        {
            if (a5 == 1)
            {
                a6 = 1;
            }
            else if (a5 == 0)
            {
                minus.text = "Complete Previous Level First";
                minuss.SetActive(true);
            }
        }
         if (a6 == 1)
         {
              a6 = 1;
            starter.play();

            water.SetActive(true);
            timerchanger.countdownn = 100f;
            waterboundries.SetActive(true);
            foodgenwater.SetActive(true);
            starter.play();
         }
             else if (snakescriptt.scorer <=0)
         {
             minus.text = "You Need " + (150 - snakescriptt.scorer).ToString() + " Gold Coins To Unlock This Level";
        minuss.SetActive(true);
        }
        
    }
    public void eight()
    {
        minus.text = "COMMING SOON !!! ";
        minuss.SetActive(true);

    }
    public void nine()
    {
        minus.text = "COMMING SOON !!! ";
        minuss.SetActive(true);


    }
    public void ten()
    {
        minus.text = "COMMING SOON !!! ";
        minuss.SetActive(true);


    }
    public void eleven()
    {
        minus.text = "COMMING SOON !!! ";
        minuss.SetActive(true);

    }
    public void twelve()
    {
        minus.text = "COMMING SOON !!! ";
        minuss.SetActive(true);

    }
    public void minussclose()
    {
        minuss.SetActive(false);
    {
        
    }
    }
    public void SaveCount()
    {
        // PlayerPrefs.SetInt("aa", a);
        // PlayerPrefs.SetInt("bb", b);
        PlayerPrefs.SetInt("aa1", a1);
        PlayerPrefs.SetInt("aa2", a2);
        PlayerPrefs.SetInt("aa3", a3);
        PlayerPrefs.SetInt("aa4", a4);
        PlayerPrefs.SetInt("aa5", a5);
        PlayerPrefs.SetInt("aa6", a6);
        PlayerPrefs.SetInt("aa7", a7);





    }

    public void LoadCount()
    {
       
        a1 = PlayerPrefs.GetInt("aa1");
        a2 = PlayerPrefs.GetInt("aa2");
        a3 = PlayerPrefs.GetInt("aa3");
        a4 = PlayerPrefs.GetInt("aa4");
        a5 = PlayerPrefs.GetInt("aa5");
        a6 = PlayerPrefs.GetInt("aa6");
        a7 = PlayerPrefs.GetInt("aa7");


    }
}
