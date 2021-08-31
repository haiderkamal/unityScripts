using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class player2 : MonoBehaviour {

    public GameObject ThisBall;
    Rigidbody m_Rigidbody;
    public float m_Speed;
    public bool righterB;
    public bool lefterB;
    public bool stoperB;
    public bool gameover,gamestart;
    public ADS adscript;
    public Text text11, text22;
    public float time1;
    public float time2;
    public GameObject gameoverpic,gamestartpic;
    public player1 player11;
    public Renderer rend;
    public float timeee;
   
    public Color[] targetColor;
    public Color targetboxhelper;
    public int i;
    public float t;
    public NavMeshAgent nav;
    public bool AI;
   
    void Start()
    {
      
        gamestartpic.SetActive(true);
        gameoverpic.SetActive(false);
        AI = false;
       
        adscript = GameObject.FindGameObjectWithTag("Ad").GetComponent<ADS>();
        player11 = GameObject.FindGameObjectWithTag("chor").GetComponent<player1>();
        rend = GetComponent<Renderer>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Speed = 0.3f;
        targetboxhelper = targetColor[i];
    
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gamestart == true)
        {
            if (gameover == false)
            {
                time1 += 1 * Time.deltaTime;
                time2 = (int)time1;
                text11.text = time2.ToString();
                text22.text = time2.ToString();
            }


            if (righterB == true)
            {
                this.gameObject.transform.Rotate(0, 10, 0);

            }

            if (lefterB == true)
            {
                this.gameObject.transform.Rotate(0, -10, 0);

            }
            if (stoperB == true)
            {

                this.gameObject.transform.Rotate(0, 0, 0);

            }

            timeee += Time.deltaTime;
            if (timeee > 2)
            {
                timeee = 0;
            }
           if (timeee >= 1) {
               // rend.material.color = new Color32( 21, 27, 31,68);
               i += 1;

               this.gameObject.GetComponent<Renderer>().material.color = Color.white;
               player11.GetComponent<Renderer>().material.color = Color.blue;

           }
             else if (timeee < 1) {
                 this.gameObject.GetComponent<Renderer>().material.color = Color.black;
                 player11.GetComponent<Renderer>().material.color = Color.red;

                // rend.material.color = Color.Lerp( targetColor[i],targetboxhelper, t += 0.025f);
             }
            if (i >= targetColor.Length - 1)
            {
                i = 0;
            }



            if (AI == true)
            {


                nav.SetDestination(player11.transform.position);
                
            }
            else
            {
                this.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                transform.position += transform.forward * m_Speed;

            }
           
        }

    }

    public void aienabler(){

        gameObject.GetComponent<NavMeshAgent>().enabled = true;

        gamestartpic.SetActive(false);
        gamestart = true;
        player11.startB = true;
        AI = true;

    
    }
    public void righter()
    {
        stoperB = false;
        lefterB = false;
        righterB = true;
    }
    public void lefter()
    {
        stoperB = false;
        righterB = false;
        lefterB = true;
    }
    public void stoper()
    {
        righterB = false;
        lefterB = false;

        stoperB = true;
    }
    public void OnTriggerEnter(Collider other) {
        if (other.tag == "chor") {
            gameover =true;
            gamestart = false;
            gameoverpic.SetActive(true);
            player11.startB = false;

        }
    
    }
    public void start() {
        gamestartpic.SetActive(false);
        gamestart = true;
        player11.startB = true;
    
    }
    public void restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // adscript.RequestInterstitial();

    }
}
