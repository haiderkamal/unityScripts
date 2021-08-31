using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodgeneration : MonoBehaviour {
	private float Xsize = 8.0f;
	private float Zsize = 8.0f;
	private float Ysize = 8.5f;

    public int i = 0;
     
	public GameObject[] food;
    AudioSource audio;
    public AudioClip[] audioClip;
	private GameObject foodi;
	public float time;
	public Vector3 curpos;
	public GameObject curfood;
    public float settime;
    public GameObject[] bolt;
    public GameObject curntbolt;
    public float timebolt;
    public Vector3 curboltpos;
    public GameObject curntbolt1;
	// Use this for initialization
    void Start() {
        settime = 0.5f;
        timebolt = 8f;
        audio = GetComponent<AudioSource>();
    }
    public void changefood(){

        i += 1;
    
    
    }

	void addnewfood()
	{
		randomfood ();
		randompos ();
		curfood = GameObject.Instantiate(foodi,curpos,Quaternion.identity) as GameObject;

        PlaySound(0);

	}

    void PlaySound(int clip)
    {

        audio.clip = audioClip[clip];
        audio.Play();
    }

	// Update is called once per frame
	void randompos(){

        int j = Random.Range(0, 2);

        if (j == 0)
        {
            curpos = new Vector3(Random.Range(Xsize * -1, Xsize), Random.Range(Ysize * -1, Ysize), Random.Range(Zsize * -1, Zsize));
        }
        else if (j == 1)
        {
            curpos = new Vector3(Random.Range(Xsize * -1, Xsize), -1 * 5.5f, Random.Range(Zsize * -1, Zsize));
        }


	}
    void randomposbolt()
    {

        int j = Random.Range(0, 2);

        if (j == 0)
        {
            curboltpos = new Vector3(Random.Range(Xsize * -1, Xsize), Random.Range(Ysize * -1, Ysize), Random.Range(Zsize * -1, Zsize));
        }
        else if (j == 1)
        {
            curboltpos = new Vector3(Random.Range(Xsize * -1, Xsize), -1 * 5.5f, Random.Range(Zsize * -1, Zsize));
        }


    }
    void randombolt()
    {
        int n = Random.Range(0, 2);

        if (n == 0)
        {
            curntbolt = bolt[0];
        }
        else
        {
            curntbolt = bolt[1];
        }
    }



	void randomfood(){
        foodi = food[i];
//		int n = Random.Range (0, 13);

//		if (n == 0){
//			foodi= food[0];
//		}
//		else if (n == 1){
//			foodi= food[1];
//		}
//		else if (n == 2){
//			foodi= food[2];
//		}
//		else if (n == 3){
//			foodi= food[3];
//		}
//		else if (n == 4) {
//			foodi= food[4];
//		}
 //       else if (n == 5)
  //      {
   //         foodi = food[5];
    //    }
     //   else if (n == 6)
      //  {
       //     foodi = food[6];
        //}
//        else if (n == 7)
 //       {
  //          foodi = food[7];
   //     }
    //    else if (n == 8)
     //   {
      //      foodi = food[8];
       // }
//        else if (n == 9)
 //       {
  //          foodi = food[9];
   //     }
    //    else if (n == 10)
      //  {
       //     foodi = food[10];
        //}
//        else if (n == 11)
 //       {
  //          foodi = food[11];
   //     }
    //    else if (n == 12)
     //   {
      //      foodi = food[12];
       // }
        //else if (n == 13)
//        {
 //           foodi = food[13];
   //     }

	}
	void Update(){

	  time += Time.deltaTime;

		if (time > settime) {
			addnewfood ();

			time = 0;


		}
         timebolt += Time.deltaTime;
        if (timebolt > 8f)
        {
            randomposbolt();
            randombolt();
            curntbolt1 = GameObject.Instantiate(curntbolt, curboltpos, Quaternion.identity) as GameObject;

            timebolt = 0;


        }


		if (!curfood) {
			addnewfood ();

		} else {
		
			return;}
			
	}





}
