using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorchanger : MonoBehaviour
{

    public Sprite[] imgs;
    public Sprite[] imgsss;
    public Sprite[] imgssss;
    public Sprite[] imgsssss;
    public Sprite[] imgsss1;

    public Image buttt1;
    public Image buttttt;
    public Image but;
    public Image buttt;
    public Image butttt;

   
    public snakemovements buyerscript;
    public buy buyingscript;
    public int a = 1;
    public int b = 1;
    public int c = 0;
    public int d = 0;
    public int e = 0;
    public Text COUNTDOWN;
    public float countdownn;
    // Use this for initialization
    
    void Start(){
        buyerscript = GameObject.FindGameObjectWithTag("mainsnakeoo").GetComponent<snakemovements>();
        buyingscript = GameObject.FindGameObjectWithTag("buyer").GetComponent<buy>();
    }

    // Update is called once per frame
    void Update()
    {

        countdownn -= Time.deltaTime;
       
        COUNTDOWN.text = (countdownn.ToString().Split(',')[0]);
        if (countdownn <= 0) {
           
            buyerscript.speed = 0;
            countdownn = 0;
        }
     
        if (a == 2)
        {
            but.sprite = imgs[1];
        }
        if (a == 3)
        {
            but.sprite = imgs[2];

        }
        if (a == 4)
        {
            but.sprite = imgs[3];

        }
         if (a >= 5)
        {
            but.sprite = imgs[4];

        }
    //     if (a == 6)
      //  {
        //    but.sprite = imgs[5];


        //}
        if (b == 2)
        {
            buttt.sprite = imgsss[1];
        }
       if (b == 3)
        {
            buttt.sprite = imgsss[2];

        }
        if (b == 4)
        {
            buttt.sprite = imgsss[3];

        }
        if (b >= 5)
        {
            buttt.sprite = imgsss[4];

        }
       //  if (b >= 6)
        //{
          //  buttt.sprite = imgsss[5];

        //}
        if (c == 1)
        {
            butttt.sprite = imgssss[1];
        }
        if (c == 2)
        {
            butttt.sprite = imgssss[2];

        }
        if (c == 3)
        {
            butttt.sprite = imgssss[3];

        }
         if (c >= 4)
        {
            butttt.sprite = imgssss[4];
            

        }
       // if (c >= 6)
        //{
          //  butttt.sprite = imgssss[5];

//        }
        if (d == 1)
        {
            buttttt.sprite = imgsssss[1];
        }
       if (d == 2)
        {
            buttttt.sprite = imgsssss[2];
       

        }
        if (d == 3)
        {
            buttttt.sprite = imgsssss[3];

        }
       if (d >= 4)
        {
            buttttt.sprite = imgsssss[4];

        }
    // if (d >= 6)
      //  {
        //    buttttt.sprite = imgsssss[5];

        //}
       if (e == 1)
       {
           buttt1.sprite = imgsss1[1];
       }
        if (e >= 2)
        {
            buttt1.sprite = imgsss1[1];
        }
        //if (e == 3)
        //{
          //  buttt1.sprite = imgsss1[2];

//        }
  //      if (e == 4)
    //    {
      //      buttt1.sprite = imgsss1[3];

//        }
  //      if (e >= 5)
    //    {
      //      buttt1.sprite = imgsss1[4];

       // }
      //   if (e >= 6)
       // {
         //   buttt1.sprite = imgsss1[5];

//        }


    }
    public void ChangeImage()
    {if ((buyerscript.scorer - 10) < 0)
        { Debug.Log("hello"); }
        else
    {
        a +=1;
        if (a <= 5)
        {
            buyingscript.buy1();
        }
    }

        
        
    }

    
    public void ChangeImagesss()
    {
        if ((buyerscript.scorer - 10) < 0)
        { Debug.Log("hello"); }
        else
        {
            b += 1;
            if (b <= 5)
            {
                buyingscript.buy3();
            }
        }
          
        }
    

    public void ChangeImagesss1()
    {
        if ((buyerscript.scorer - 20) < 0)
        { Debug.Log("hello"); }
        else
        {
            c += 1;
            if (c <= 5)
            {
                buyingscript.buy4();
            }

        }
           

        }
    

    public void ChangeImagesss2()
    {
        if ((buyerscript.scorer - 100) < 0)
        { Debug.Log("hello"); }
        else
        {
            d += 1;
            if (d <= 5)
            {
                buyingscript.buy5();
            }
        }
            
    }

    public void ChangeImagesss3()
    {
        if ((buyerscript.scorer - 300) < 0)
        { Debug.Log("hello"); }
        else
        {
            e += 1;
            if (e <= 2)
            {
                buyingscript.buy6();
            }
        }
            
        
    }
     public void SaveCount()
    {
       // PlayerPrefs.SetInt("aa", a);
       // PlayerPrefs.SetInt("bb", b);
        PlayerPrefs.SetInt("cc",c);
        PlayerPrefs.SetInt("dd",d);
        PlayerPrefs.SetInt("ee",e);



       
    }

     public void LoadCount()
     {
        // a = PlayerPrefs.GetInt("aa");
        // b = PlayerPrefs.GetInt("bb");
         c = PlayerPrefs.GetInt("cc");
         d = PlayerPrefs.GetInt("dd");
         e = PlayerPrefs.GetInt("ee");

     }
}
