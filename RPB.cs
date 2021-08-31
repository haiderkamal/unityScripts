using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPB : MonoBehaviour {
    public Transform LoadingBar;
    public Transform BerzerkBar;

    public Transform TextIndicator;

    [SerializeField]
    public float currentAmount;
    private float berzerkamount;

    [SerializeField]
    private float currentAmounter;
    [SerializeField]
    private float speed;
    public int i;
    public GameObject uibar;
    public clr color;
    public bool berserk;
    public snakemovements smakemovementss;
    public foodgeneration food;
    public GameObject berserkUmh;
    public GameObject berserkimg;

    public Sprite[] foodpicsArray;
    public Image foodPics;
    public int j=1;
    public bool foodBarResetBool;
    public bool foodBarIncreaseBool;
    public float helper;
    public float currentAmountHelper;

    public autosize planetScript;



	// Use this for initialization
	void Start () {
        foodBarResetBool = false;
        planetScript = GameObject.FindGameObjectWithTag("planet").GetComponent<autosize>();

        color = GameObject.FindGameObjectWithTag("clr").GetComponent<clr>();
        berserk = false;
        berzerkamount = 0.01f;
        foodPics.sprite = foodpicsArray[j];
    }
	
	// Update is called once per frame
	void Update () {
        berzerkamount -= 0.001f;
        if (berzerkamount <= 0) {
            berserk = false;
            berserkimg.SetActive(false);
            if (smakemovementss.diebool == true)
            {
                smakemovementss.speed = 0;
            }
            else
            {
                smakemovementss.speed = 4;
            }
            smakemovementss.berserk1 = false;
            //berserkUmh.SetActive( false);
            berzerkamount = 0;
        }
        if (berzerkamount >= 1)
        {
           // berserkUmh.SetActive(true);
            berserkimg.SetActive(true);
            smakemovementss.speed = 5;
            food.settime = 2.0f;

            berserk = true;
            smakemovementss.berserk1 = true;
        }
        if (currentAmounter < 1) {
            currentAmounter = 1;
        }
       
        if (currentAmount >= 100)
        {
            foodBarResetBool = true;
            planetScript.changeplanetclr();
            color.hello();

            j += 1;
            if (j > 13)
            { j = 0; }
            foodPics.sprite = foodpicsArray[j];
        }
        if (foodBarResetBool == true)
        {
            foobarReset();
        }
        if (foodBarIncreaseBool == true)
        {


            foodbarIncrease();

        }
        
        if (currentAmounter > 100) {
            i += 100;
            
            currentAmounter = 0;

            TextIndicator.GetComponent<Text>().text = ((currentAmounter / (100 + i))).ToString() + "%";

        }
        else{
          //  TextIndicator.GetComponent<Text>().text = "Done";
        }

        LoadingBar.GetComponent<Image>().fillAmount = (currentAmount / (100));
        BerzerkBar.GetComponent<Image>().fillAmount = (berzerkamount );

	}
    public void loading() {
        helper = currentAmount+5;
       // while( foodBarIncreaseBool== false)

        foodBarIncreaseBool = true;
        currentAmounter += 5;
        if (berserk == false)
        {
            berzerkamount += 0.2f;



        }
        TextIndicator.GetComponent<Text>().text = ((int)currentAmounter).ToString() + "%";
    }

    public void foobarReset() {
        foodBarIncreaseBool = false;

        currentAmount -= 1f;
        if (currentAmount <= 0)
        {
            currentAmount = 0;
            helper = 0;
            foodBarResetBool = false;
        }
     }
    public void foodbarIncrease(){
        if (foodBarResetBool == false)
        {
            currentAmount += 1f;
            if (currentAmount == (helper))
            {
                foodBarIncreaseBool = false;
            }
        }
        
    }
}
