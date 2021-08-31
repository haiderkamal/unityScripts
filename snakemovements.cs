using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using System.IO;
using UnityStandardAssets.CrossPlatformInput;

public class snakemovements : MonoBehaviour
{
    public List<Transform> BodyParts = new List<Transform>();
    public float mindistance = 0.01f;
    public int beginsize;
    public float timei = 1f;
    private float time;
    public float speed;
    public float rotatonspeed = 150.0f;
    public GameObject bodyprefab;
    private float dis;
    private Transform curBodyPart;
    private Transform PreBodypart;
    public float timeH;
    public float moveHorizontal;
    public float moveVertical;
    public int count;
    public Text score;
    public int scorer;
   
    public float timer;
    public float timmer2;

    public bool spchek;
    public float timer22 = 5.0f;
   
    public float shieldtime = 1.15f;
    
    public int addfoodcount;
    public int i;
    public float ttt;
   
    public GameObject losecanvas;
    public actioncollider ac;
    public GameObject inermenu;
    public int r = 0;
    Vector3 input01;
       private float ScreenWidth;
    public GameObject buttonsss;
    public bool buttonss;
    public float speedhelp;
    public int FINNALSCORE1;
    public Text Finalscoree1;
    public bool berserk1;
    public Text score3;
    public bool diebool;

    public Text curScore;

    //public DataLoader dataloader;
    //public DataInserter datainserter;

    public Text overAllScore;
    public ScrollRect myScrollRect;

    public GameObject[] ParentBody;
    public GameObject[] BabyBody;
    public Text Name;
    public int hen=0, duck=0, dog=0, snake=0;
    public Text PlayButton;
    public gamestart start;
    public int animalNumber =0;
    public Image animal;
    public Sprite[] animalImages;
    // Use this for initialization
     void Start()
     {
        animalNumber = 0;
        speed = 0;
        buttonsss.SetActive(false);
        buttonss = false;
        inermenu.SetActive(false);
        LoadCount();
        ac = GameObject.FindGameObjectWithTag("mainsnake").GetComponent<actioncollider>();
       // dataloader = GameObject.FindGameObjectWithTag("multiplayer").GetComponent<DataLoader>();
        start = GameObject.FindGameObjectWithTag("starter").GetComponent<gamestart>();
        animalchangeFunction(0);
        ScreenWidth = Screen.width;
      //  datainserter.uploadScore();
      //  tr = GameObject.FindGameObjectWithTag("trail").GetComponentInChildren<TrailRenderer>();
      //  tr.time = timeH;


    }

     void FixedUpdate() {
         Move();
     }
     public void changeanimalnumberForward()
     {
        animalNumber += 1;
        if (animalNumber > 3)
        {
            animalNumber = 0;
        }
        animalchangeFunction(animalNumber);
        Debug.Log(animalNumber);
      
     }
     public void changeanimalnumberBack()
     {

        animalNumber -= 1;
        if (animalNumber < 0)
        {
            animalNumber = 3;
        }
        animalchangeFunction(animalNumber);
        Debug.Log(animalNumber);




    }
     public int animalchangeFunction(int a)
     {
         // animalNumber = myScrollRect.horizontalNormalizedPosition;
       
         if (a == 0)
         {
             animal.sprite = animalImages[0];
             Name.text = "Chicken";
             ParentBody[0].SetActive(true);
             BabyBody[0].SetActive(true);
             ParentBody[1].SetActive(false);
             BabyBody[1].SetActive(false);
             ParentBody[2].SetActive(false);
             BabyBody[2].SetActive(false);
             ParentBody[3].SetActive(false);
             BabyBody[3].SetActive(false);
             PlayButton.text = "Play";

         }
         if (a == 1)
         {
             animal.sprite = animalImages[1];

             Name.text = "Duck";
             if (duck == 1)
             {

                 ParentBody[1].SetActive(true);
                 BabyBody[1].SetActive(true);
                 ParentBody[0].SetActive(false);
                 BabyBody[0].SetActive(false);
                 ParentBody[2].SetActive(false);
                 BabyBody[2].SetActive(false);
                 ParentBody[3].SetActive(false);
                 BabyBody[3].SetActive(false);
                 PlayButton.text = "Play";

             }
             else
             {
                 PlayButton.text = "100 Coins";
             }
         }
         if (a == 2)
         {
             animal.sprite = animalImages[2];

             Name.text = "Dog";
             if (dog == 1)
             {

                 ParentBody[2].SetActive(true);
                 BabyBody[2].SetActive(true);
                 ParentBody[1].SetActive(false);
                 BabyBody[1].SetActive(false);
                 ParentBody[0].SetActive(false);
                 BabyBody[0].SetActive(false);
                 ParentBody[3].SetActive(false);
                 BabyBody[3].SetActive(false);
                 PlayButton.text = "Play";

             }
             else
             {
                 PlayButton.text = "200 Coins";
             }
         }
         if (a == 3)
         {
             animal.sprite = animalImages[3];

             Name.text = "Snake";
             if (snake == 1)
             {

                 ParentBody[3].SetActive(true);
                 BabyBody[3].SetActive(true);
                 ParentBody[1].SetActive(false);
                 BabyBody[1].SetActive(false);
                 ParentBody[2].SetActive(false);
                 BabyBody[2].SetActive(false);
                 ParentBody[0].SetActive(false);
                 BabyBody[0].SetActive(false);
                 PlayButton.text = "Play";

             }
             else
             {
                 PlayButton.text = "300 Coins";
             }
         }
         return a;

     }
     
    // Update is called once per frame
    void Update()
     {
       
        moveHorizontal = Input.GetAxis("Horizontal");
        if (diebool == true) {
            speed = 0;
        
        }
            
        else if (berserk1 == false)
        {
            if (speed > 3)
            {
                speed = 3;
            }
        }
        FINNALSCORE1 = scorer;
        score3.text = scorer.ToString();
       // Finalscoree1 .text = "Belly: " + scorer.ToString();
        curScore.text = count.ToString();


        if (speedhelp < speed) {
            speedhelp = speed;
        }
        int i = 0;
        if (buttonss == true)
        {
            while (i < Input.touchCount)
            {
                if ((Input.GetTouch(i).position.x > ScreenWidth / 2) && (Input.GetTouch(i).position.x < ScreenWidth / 2))
                {

                    speed = 0;
                }
                if (Input.GetTouch(i).position.x > ScreenWidth / 2)
                {

                    BodyParts[0].Rotate(Vector3.up * rotatonspeed * Time.deltaTime * (1));

                }
                if (Input.GetTouch(i).position.x < ScreenWidth / 2)
                {
                    BodyParts[0].Rotate(Vector3.up * rotatonspeed * Time.deltaTime * (-1));

                } 
                ++i;
            } 
        }
        

            moveVertical = Input.GetAxis("Vertical");
        
        
        setcounttext();
        if (scorer <= 0)
        {
          //  scorer = 0;
        }
        
          if (Input.GetKey(KeyCode.Escape))
            {
                inermenu.SetActive(true);
                speed = 0;
                
            }
        if (spchek == true) {
          
           
            
            timmer2 += Time.deltaTime;
        }
        if (timmer2 >= timer22) {
          
            spchek = false;
            timmer2 = 1f;

        }

       
       
      
        if (spchek == true) {
            shieldtime = 2f;
        }
        if (spchek == false)
        {
            shieldtime = 1.05f;
        }
        if (addfoodcount > 1) {
            addfoodcount = 1;
        }

         
    }
    public void Starter()
    {
        if (animalNumber ==0)
        {
            Debug.Log(animalNumber);
            animalchangeFunction(animalNumber);
            start.starterr();
        }
        if (animalNumber ==1)
        {
            if (duck == 1)
            {
                animalchangeFunction(animalNumber);
                start.starterr();

            }
            else
            {
                if (scorer >= 100)
                {
                    Debug.Log(animalNumber);

                    scorer -= 100;
                    duck = 1;
                    animalchangeFunction(animalNumber);
                    ShowMainScore();
                    PlayButton.text = "Play";
                    SaveCount();
                    Debug.Log(duck);




                }
            }
        }
        if (animalNumber ==2)
        {
            Name.text = "Dog";
            if (dog == 1)
            {
                animalchangeFunction(animalNumber);
                start.starterr();

            }
            else
            {
                if (scorer >= 200)
                {
                    Debug.Log(animalNumber);

                    scorer -= 200;
                    dog = 1;
                    animalchangeFunction(animalNumber);
                    ShowMainScore();
                    PlayButton.text = "Play";
                    SaveCount();
                    Debug.Log(dog);




                }
            }
        }
        if (animalNumber ==3)
        {
            Name.text = "Snake";
            if (snake == 1)
            {
                animalchangeFunction(animalNumber);
                start.starterr();


            }
            else
            {
                if (scorer >= 300)
                {
                    Debug.Log(animalNumber);

                    scorer -= 300;
                    snake = 1;
                    animalchangeFunction(animalNumber);
                    ShowMainScore();
                    PlayButton.text = "Play";
                    SaveCount();
                    Debug.Log(snake);




                }
            }
        }
        //datainserter.uploadScore();
    }
  
    public void resume() {
        inermenu.SetActive(false);
        speed = speedhelp;
    }
    

    public void Move()
    {
        float curspeed = speed;
        if (moveVertical != 0)
        {
            
            if (curspeed <= 0)
            {
                curspeed = 0;
            }
        }
        BodyParts[0].Translate(BodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);
        BodyParts[0].Rotate(Vector3.up * rotatonspeed * Time.smoothDeltaTime * moveHorizontal);
        
        for (int i = 1; i < BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            PreBodypart = BodyParts[i - 1];
           
            dis = Vector3.Distance(PreBodypart.position, curBodyPart.position);

            Vector3 newpos = PreBodypart.position;
            newpos.y = PreBodypart.position.y;

            float T = Time.deltaTime * dis / mindistance * curspeed;
            if (T >= 0.1f)
               T = 0.1f;
            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, PreBodypart.rotation, T);
           
        }
       
    }

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyprefab, BodyParts[BodyParts.Count - 1].position, BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;
        newpart.SetParent(transform);
        BodyParts.Add(newpart);
    }

    void setcounttext()
    {
        score.text = "Belly: " + count.ToString();
       // yourscore.text = "Yayy..You & Buby Ate: " + count.ToString() + " Times";


    }

  
   

    public void SaveCount()
    {
        PlayerPrefs.SetInt("scorerr", scorer);
        PlayerPrefs.SetInt("duck", duck);
        PlayerPrefs.SetInt("dog", dog);
        PlayerPrefs.SetInt("snake", snake);

       



    }
    public void transformer(){
        losecanvas.SetActive(false);
        Invoke("trans", 3);
        
    }
    public void trans()
    {
       // ac.restarter();
       
        speed = 1;
    }
    public void LoadCount()
    {
        scorer = PlayerPrefs.GetInt("scorerr");
        duck = PlayerPrefs.GetInt("duck");
        dog = PlayerPrefs.GetInt("dog");
        snake = PlayerPrefs.GetInt("snake");

        ShowMainScore();
    
    }
    public void ShowMainScore()
    {
        overAllScore.text = scorer.ToString();
    }
   
    public void buttonsscreen() {
        buttonsss.SetActive(true);
        buttonss = true;

    
    }
    public void food()
    {

        AddBodyPart();
        timeH += 0.2f;
        for (i = 0; i <= addfoodcount; i++)
           {
             count += 1;
             scorer += 1;
             speed += 0.02f;
               if (rotatonspeed < 160)
               {
                   rotatonspeed += 0.5f;
               }
        // dataloader.retrievee(count);
        // datainserter.retrievee(count);
       }
      
    }
    public void die()
    {
        diebool = true;

    }
    public void live()
    {
        diebool = false;
    }

    
    public void buttoncall(){
            buttonsscreen();
}

    }




	
