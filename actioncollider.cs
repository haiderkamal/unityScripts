using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class actioncollider : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip[] audioClip;
    public snakemovements snakemovementsScript;
    public autosize planetscript;
    public GameObject restartscreen;
    public int counterr = 0;
    public RPB score;
    public float timmer;
    public bool spchek;
    public GameObject part;
    public GameObject parttt;
    public GameObject partttd;
    public int planet;
    public Material skybox1;
    public Material skybox11;
    public Text minus;
    public GameObject minuss;
    public int a;
    public gamestart starter;
    public ShareImage sharee;

    public GameObject stars;


    public Renderer renderer;
    public int helper;
    public int bodynumber;
    public int ai, bi, ci, di, ei, fi, gi, hi, ii, ji, ki, li, mi, ni, oi;
    public GameObject[] bodies;
    public GameObject mainbody;
    public RPB loadingBarScript;
    public float counterHelper;
    public bool increaseBoolChecker;
    public Text Fact;
    public string[] facts = new string[10];
    //public DataInserter updateScore;


    // Use this for initialization
    void Start()
    {

        stars.SetActive(false);
        planet = 0;
        restartscreen.SetActive(false);
        renderer = GetComponent<Renderer>();
        starter = GameObject.FindGameObjectWithTag("starter").GetComponent<gamestart>();
        sharee = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShareImage>();
        score = GameObject.FindGameObjectWithTag("score").GetComponent<RPB>();
        counterHelper = score.currentAmountHelper;
        increaseBoolChecker = score.foodBarIncreaseBool;


        minuss.SetActive(false);
        audio = GetComponent<AudioSource>();
        snakemovementsScript = GameObject.FindGameObjectWithTag("mainsnakeo").GetComponent<snakemovements>();
        planetscript = GameObject.FindGameObjectWithTag("planet").GetComponent<autosize>();
        //updateScore = GameObject.FindGameObjectWithTag("multiplayer").GetComponent<DataInserter>();



    }

    public void planetset0() { planet = 0;
   // planetscript.changeplanetclr();
    RenderSettings.skybox = skybox1;

    }
    public void planetset1() { 
        planet = 1;
        planetscript.changeplanetclr11();
        RenderSettings.skybox = skybox11;
    
    
    
    }
    public void minussclose()
    {
        minuss.SetActive(false);
    }

    // Update is called once per frame
    

    public void planetstarter0() {
        starter.play();
}
    public void planetstarter() {
        if (snakemovementsScript.scorer >= 1000)
        {
            a = 1;
           

        }
        if (a == 1)
        {
            a = 2;
            starter.play();
            if (counterr >= 80)
            {
                counterr = 0;
            }
            if (counterr < 2)
            {
                PlaySound(1);
                Instantiate(parttt);
                planetscript.changeplanetclr11();
            }
            if (counterr == 20 && counterr <= 21)
            {
                PlaySound(1);
                planetscript.changeplanetclr22();
                Instantiate(parttt);
            }
            if (counterr >= 40 && counterr <= 41)
            {
                PlaySound(1);
                planetscript.changeplanetclr11();
                Instantiate(parttt);
            }
            if (counterr >= 60 && counterr <= 61)
            {
                PlaySound(1);
                planetscript.changeplanetclr22();
                Instantiate(parttt);
            }
        }
        else if (snakemovementsScript.scorer <= 1000)
        {

            minus.text = "You Need " + (1000 - snakemovementsScript.scorer).ToString() + " Points To Unlock This Level";
            minuss.SetActive(true);
        }
    
    }
    public void unlock11() {
        helper = ai;
        bodynumber = 0;
        unlock1();
    
    }
    public void unlock22()
    {
        helper = bi;
        bodynumber = 1;

        unlock1();

    }
    public void unlock33()
    {
        helper = ci;
        bodynumber = 2;

        unlock1();

    }

    public void unlock44()
    {
        helper = di;
        bodynumber = 3;

        unlock1();

    }
    public void unlock55()
    {
        helper = ei;
        bodynumber = 4;

        unlock1();

    }
    public void unlock66()
    {
        helper = fi;
        bodynumber = 5;

        unlock1();

    }
    public void unlock77()
    {
        helper = gi;
        bodynumber = 6;

        unlock1();

    }
    public void unlock88()
    {
        helper = hi;
        bodynumber = 7;

        unlock1();

    }
    public void unlock99()
    {
        helper = ii;
        bodynumber = 8;

        unlock1();

    }
    public void unlock100()
    {
        helper = ji;
        bodynumber = 9;

        unlock1();

    }
    public void unlock110()
    {
        helper = ki;
        bodynumber = 10;

        unlock1();

    }
    public void unlock120()
    {
        helper = li;
        bodynumber = 11;

        unlock1();

    }
    public void unlock130()
    {
        helper = mi;
        bodynumber = 12;

        unlock1();

    }
    public void unlock140()
    {
        helper = ni;
        bodynumber = 13;

        unlock1();

    }
    public void unlock150()
    {
        helper = oi;
        bodynumber = 14;

        unlock1();

    }

    public void unlock1()
    {

        if (helper == 1)
        {
            for (int j = 0; j <= bodies.Length - 1; j++)
            {
                bodies[j].SetActive(false);
            }
            bodies[bodynumber].SetActive(true);
            minus.text = "OutFit Unlocked! You Look Amazing!";
            minuss.SetActive(true);
            mainbody.SetActive(false);
        }
        else if (snakemovementsScript.scorer >= 50f )
        {
            if (helper == 0)
            {
                if (bodynumber == 0) {
                    ai = 1;
                }
                else if (bodynumber == 1)
                {
                    bi = 1;
                }
                else if (bodynumber == 2)
                {
                    ci = 1;
                }
                else if (bodynumber == 3)
                {
                    di = 1;
                }
                else if (bodynumber == 4)
                {
                    ei = 1;
                }
                else if (bodynumber == 5)
                {
                    fi = 1;
                }
                else if (bodynumber == 6)
                {
                    gi = 1;
                }
                else if (bodynumber == 7)
                {
                    hi = 1;
                }
                else if (bodynumber == 8)
                {
                    ii = 1;
                }
                else if (bodynumber == 9)
                {
                    ji = 1;
                }
                else if (bodynumber == 10)
                {
                    ki = 1;
                }
                else if (bodynumber == 11)
                {
                    li = 1;
                }
                else if (bodynumber == 12)
                {
                    mi = 1;
                }
                else if (bodynumber == 13)
                {
                    ni = 1;
                }
                else if (bodynumber == 14)
                {
                    oi = 1;
                }
                for (int j = 0; j <= bodies.Length - 1; j++)
                {
                    bodies[j].SetActive(false);
                }
                minus.text = "OutFit Unlocked! You Look Amazing!";
                minuss.SetActive(true);
                mainbody.SetActive(false);

                bodies[bodynumber].SetActive(true);
                snakemovementsScript.scorer -= 50;
                SaveCount();
            }
        }
        else
        {
            minus.text = "You Need " + (50 - snakemovementsScript.scorer).ToString() + " Points To Unlock This OutFit";
            minuss.SetActive(true);
        }
    }
    public void share()
    {

        restartscreen.SetActive(false);
        Invoke("sharew", 2);



    }
    public void sharew() {
        sharee.OnShareButtonClick();
        Invoke("restarterrr", 2);
    
    
    }
    void restarterrr() {
        restartscreen.SetActive(true);
        facts[0] = "Polar bears cubs stay with their mom for at least two years, learning the ropes about hunting and diving. - BuzzFeed";
        facts[1] = "Baby elephants can't see very well when they're first born so they identify their mom through touch, scent and sound. - BuzzFeed";
        facts[2] = "Emperor penguin moms and dads alternate roles while raising a chick, one will hunt for food while they other stays at the breeding site to keep the baby warm and safe. - BuzzFeed";
        facts[3] = "A Harp seal mom can identify her baby from hundreds of others based on smell alone. - BuzzFeed";
        facts[4] = "For the first two years of their life, young orangutans are dependent their mom for food and transportation. - BuzzFeed";
        facts[5] = "Each night before going to sleep gorillas make a cozy bed out of leaves. Gorilla moms share these nests with their nursing babies. - BuzzFeed";




        int a = Random.Range(0,5);
        Fact.text = facts[a].ToString();
    }
    public void restarter()
    {
        spchek = true;


    }
    public void Update() {

        if (spchek == true)
        {

            restartscreen.SetActive(false);
            timmer += Time.deltaTime;
            
        }
        if (timmer > 8.0f)
        {
            snakemovementsScript.speed = snakemovementsScript.speedhelp;
            stars.SetActive(false);

            spchek = false;
            timmer = 1f;

        }

    
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("food"))
        {   
            snakemovementsScript.food();
            score.loading();
            audio.clip = audioClip[0];
            audio.Play();

            if (planet == 0)
            {
                planetstarter0();
            }


            if (planet == 1)
            {
                planetstarter();
            }
            Destroy(other.gameObject);

        }
        if (other.CompareTag("nnn"))
        {

               // updateScore.uploadScore();
                stars.SetActive(true);
            audio.clip = audioClip[2];
            audio.Play();
            
            // Instantiate(partttd);
            snakemovementsScript.die();
                Invoke("restarterrr", 2);
            Destroy(other.gameObject);
        }
    }
    public void ContinuePlaying()
    {
        restartscreen.SetActive(false);
        snakemovementsScript.live();
        snakemovementsScript.speed = 2;
    }
    void PlaySound(int clip)
    {

        audio.clip = audioClip[clip];
        audio.Play();
    }
    public void SaveCount()
    {
        PlayerPrefs.SetInt("aa", a);
        PlayerPrefs.SetInt("aai", ai);
        PlayerPrefs.SetInt("bbi", bi);
        PlayerPrefs.SetInt("cci", ci);
        PlayerPrefs.SetInt("ddi", di);
        PlayerPrefs.SetInt("eei", ei);
        PlayerPrefs.SetInt("ffi", fi);
        PlayerPrefs.SetInt("ggi", gi);
        PlayerPrefs.SetInt("hhi", hi);
        PlayerPrefs.SetInt("iii", ii);
        PlayerPrefs.SetInt("jji", ji);
        PlayerPrefs.SetInt("kki", ki);
        PlayerPrefs.SetInt("lli", li);
        PlayerPrefs.SetInt("mmi", mi);
        PlayerPrefs.SetInt("nni", ni);
        PlayerPrefs.SetInt("ooi", oi);
    }
    public void LoadCount()
    {

        ai = PlayerPrefs.GetInt("aai");
        bi = PlayerPrefs.GetInt("bbi");
        ci = PlayerPrefs.GetInt("cci");
        di = PlayerPrefs.GetInt("ddi");
        ei = PlayerPrefs.GetInt("eei");
        fi = PlayerPrefs.GetInt("ffi");
        gi = PlayerPrefs.GetInt("ggi");
        hi = PlayerPrefs.GetInt("hhi");
        ii = PlayerPrefs.GetInt("iii");
        ji = PlayerPrefs.GetInt("jji");
        ki = PlayerPrefs.GetInt("kki");
        li = PlayerPrefs.GetInt("lli");
        mi = PlayerPrefs.GetInt("mmi");
        ni = PlayerPrefs.GetInt("nni");
        oi = PlayerPrefs.GetInt("ooi");
        a = PlayerPrefs.GetInt("aa");
    }

}
