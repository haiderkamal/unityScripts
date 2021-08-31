using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autosize : MonoBehaviour {
    public bool size;
    public float speed = 1f;
    public float aa = 10;
    public int bb = 10;
    public int cc = 10;
    public AudioSource audio;
    public AudioClip[] audioClip;
    public Vector3 newscale = new Vector3(4, 4, 4);
    private Vector3 mainscale;
    private float speeder = 1f;
   // private float speederR = 5f;

    public int a = 0;
    public float t;
    public float timer;
    public float duration = 1.0f;

    public float timeLeft = 0;
    public Color[] targetColor;
    public Color[] skybox;
    public int i=0;
    public bool colorchangerbool = false;
    public Camera cam;

    public foodgeneration foodscript;

    public Material mat1;
    public Material mat2;
    public Material mat3;
    public Material mat4;

    public Material mat11;
    public Material mat22;
    public Material mat33;
    public Material mat44;
    public Material skybox11;


    public Material skybox2;
    public Material skybox3;
    public Material skybox4;
    public Material skybox5;

    Renderer renderer;

    public GameObject summer;
    public GameObject spring;
    public GameObject autum;
    public GameObject winter;

    public GameObject rocket;
    public GameObject saturn;

    float startTime;

    public Color skyboxhelper;
    public Color targetboxhelper;

    public GameObject[] seasonsProps;
    public int seasonPropsHealper;



	// Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        
        //      spring.SetActive(false);
    //    summer.SetActive(true);
      //  autum.SetActive(false);
     //   winter.SetActive(false);
       // saturn.SetActive(false);
       // rocket.SetActive(false);
        startTime = Time.time;
        mainscale = new Vector3(aa,bb,cc);
        foodscript = GameObject.FindGameObjectWithTag("foodgen").GetComponent<foodgeneration>();

        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
        renderer = GetComponent<Renderer>();
      //  renderer.material.color = Color.Lerp(targetboxhelper, targetColor[i], t += 0.025f);
      //  cam.backgroundColor = Color.Lerp(skyboxhelper, skybox[i], t += 0.025f); 
        transform.localScale = Vector3.Lerp(transform.localScale, newscale, 1f);
        transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
        size = false;
	}
   public void starter() {
       timer = 0;
       a = 2;
    
    }
	void Update () {
        
        if (a == 2)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, mainscale, speeder * Time.smoothDeltaTime);
            transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime);
            timer += Time.deltaTime;
        }
        if (timer >= 2f)
        {
            a = 3;
            size = true;
        }
        
                
        if (size == true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, newscale, speed * Time.smoothDeltaTime);
        }
        colorchanger();
        
	}
    public void colorchangevalue()
    {
        aa += 1;
        bb += 1;
        cc += 1;
         mainscale = new Vector3(aa, bb, cc);
        t = 0.025f;
         skyboxhelper = skybox[i];
         targetboxhelper = targetColor[i];
        i += 1;
        foodscript.changefood();
        soundbeep();
    }
    public void soundbeep()
    {
        PlaySound(0);
    }
    public void colorchanger() 
    {
        
        if (aa >= 15) 
        {

            aa = 10;
            bb = 10;
            cc = 10;
        }

        if (i >= targetColor.Length - 1) 
        {
            i = 0;
        }
               
        renderer.material.color = Color.Lerp(targetboxhelper, targetColor[i], t +=0.025f);
        cam.backgroundColor = Color.Lerp(skyboxhelper, skybox[i], t += 0.025f);

        if (t >= 1)
        {
            t = 1;
        }
                
     }
        
    
    
    
    public void changeplanetclr() {
        seasonsProps[seasonPropsHealper].SetActive(false);
        seasonPropsHealper += 1;
        if (seasonPropsHealper > 3) {
            seasonPropsHealper = 0;
        }
      
        
        seasonsProps[seasonPropsHealper].SetActive(true);
        colorchangevalue();      
        starter();
     }
    
    public void changeplanetclr11()
    {
        summer.SetActive(false);
        rocket.SetActive(true);
        colorchangevalue();      

       // renderer.material = mat11;
        starter();
    }
    public void changeplanetclr22()
    {
        spring.SetActive(false);
        saturn.SetActive(true);
        colorchangevalue();      

       // renderer.material = mat22;
        starter();
    }
    public void changeplanetclr33()
    {
        spring.SetActive(false);
        colorchangevalue();      

       // renderer.material = mat33;
        starter();
    }
    public void changeplanetclr44()
    {
        spring.SetActive(false);
        colorchangevalue();      

       // renderer.material = mat44;
        starter();
    }
    void PlaySound(int clip)
    {

        audio.clip = audioClip[clip];
        audio.Play();
    }
}
