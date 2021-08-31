using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnScript : MonoBehaviour
{
    public GameObject[] WaveOne;
    public GameObject[] WaveTwo;
    public GameObject[] WaveThree;
    public GameObject[] WaveFour;
    public GameObject[] WaveFive;
    public GameObject[] WaveSix;
    public GameObject[] WaveSeven;
    public GameObject[] WaveEight;
    public GameObject[] WaveNine;

    public GameObject[] WaveTen;
    public GameObject[] WaveEleven;
    public GameObject[] WaveTwelve;
    public GameObject[] WaveThirteen;
    public GameObject[] WaveFourteen;
    public GameObject[] WaveFifteen;
    public GameObject[] WaveSixteen;
    public GameObject[] WaveSeventeen;
    public GameObject[] WaveEighteen;
    public GameObject[] WaveNineteen;
    public GameObject[] WaveTwenty;

    public GameObject[] WaveTwentyone;
    public GameObject[] WaveTwentytwo;
    public GameObject[] WaveTwentythree;
    public GameObject[] WaveTwentyfour;
    public GameObject[] WaveTwentyfive;

    public GameObject   HELICOPTER;
    public Transform helicopterTransform;
    public helicopterPath helicopterAI;

    public GameObject[] door;

    public int TotaldeathCount;

    public GPMultiplayer GP;
    public bool levelCompletedMsg;

    public AudioSource audioSource;
    public AudioClip[] audio;

    public Text EnemiesKilledTopRight;
    public GameObject WinStatus;
    public Text WinStatusText;
    public ParticleSystem[] particle;

    public ParticleSystem helicopterExplosion;
    public GameObject winCanvas;
    public restartScript res;
    public GameObject bodypart1;
    public GameObject bodypart2;

    public GameObject helicopterCam;

    public GameObject hostagesCam;
    public GameObject hostages;

    public AudioSource helicopterAudioSource;
    public int sizeofListE;
    public int ID;
    public bool Allowed;
    public int allow;
    public bool done;
    public int d;

    public void Start()
    {
        HELICOPTER.GetComponent<AudioSource>().mute = true;

    }
    public void Update()
    {
       
        helicopterTransform = HELICOPTER.transform;
        EnemiesKilledTopRight.text = "Killed: " + TotaldeathCount.ToString()+"     |     "+ "Players Online: "+ GP.sizeOfList;
       // EnemiesKilledTopRight.text = "1L: " + GP.TotalEnemyKilledLocal[0]+ " 2L: " + GP.TotalEnemyKilledLocal[1] + "  1S: " + GP.TotalEnemyKilledSync[0]+ " 2S: "+GP.TotalEnemyKilledSync[1] + " A: " + allow + " D: " + d +":"+ GP.enemiesHealthSync1[0] + ":" + GP.enemiesHealthSync1[1] + ":" + GP.enemiesHealthSync1[2] + ":" + GP.enemiesHealthSync1[3] + ":" + GP.enemiesHealthSync2[0] + ":" + GP.enemiesHealthSync2[1] + ":" + GP.enemiesHealthSync2[2] + ":" + GP.enemiesHealthSync2[3]+":"+ GP.enemiesHealth[0] + ":" + GP.enemiesHealth[1] + ":" + GP.enemiesHealth[2] + ":" + GP.enemiesHealth[3]+":"+ helicopterAI.waypointIndex;
        if (TotaldeathCount == 3)
        {
            done = false;

        }
        if (TotaldeathCount == 5)
        {
            done = false;

        }
        if (TotaldeathCount == 6)
        {
            done = false;

        }if (TotaldeathCount == 7)
        {
            done = false;

        }
        if (TotaldeathCount == 9)
        {
            done = false;

        }
        if (TotaldeathCount == 10)
        {
            done = false;

        }
        if (TotaldeathCount == 11)
        {
            done = false;

        }
        if (TotaldeathCount == 13)
        {
            done = false;

        } if (TotaldeathCount == 14)
        {
            done = false;

        } if (TotaldeathCount == 15)
        {
            done = false;

        }
        if (TotaldeathCount == 17)
        {
            done = false;

        }  if (TotaldeathCount == 18)
        {
            done = false;

        }  if (TotaldeathCount == 19)
        {
            done = false;

        }
        if (TotaldeathCount == 21)
        {
            done = false;

        }
        if (TotaldeathCount == 23)
        {
            done = false;

        }
  
        if (TotaldeathCount == 25)
        {
            done = false;

        }
        if (TotaldeathCount == 27)
        {
            done = false;

        }

        if (TotaldeathCount == 29)
        {
            done = false;

        }if (TotaldeathCount == 31)
        {
            done = false;

        }if (TotaldeathCount == 33)
        {
            done = false;

        }if (TotaldeathCount == 35)
        {
            done = false;

        }if (TotaldeathCount == 37)
        {
            done = false;

        }if (TotaldeathCount == 38)
        {
            done = false;

        }if (TotaldeathCount == 39)
        {
            done = false;

        }if (TotaldeathCount == 41)
        {
            done = false;

        }if (TotaldeathCount == 42)
        {
            done = false;

        }if (TotaldeathCount == 43)
        {
            done = false;

        }if (TotaldeathCount == 45)
        {
            done = false;

        }if (TotaldeathCount == 46)
        {
            done = false;

        }if (TotaldeathCount == 47)
        {
            done = false;

        }

        if (Allowed == true)
        {
            allow = 1;

            if (done == false)
            {
                
                if (TotaldeathCount == 4)
                {
                    helicopterAI.waypointIndex += 2;
                    Invoke("SecondWave", 5f);
                    done = true;

                }
                
                
                if (TotaldeathCount == 8)
                {
                    helicopterAI.waypointIndex += 2;
                    Invoke("ThirdWave", 5f);
                    done = true;

                }
               
               
                if (TotaldeathCount == 12)
                {

                    helicopterAI.waypointIndex += 2;
                    WinStatus.SetActive(true);
                    WinStatusText.text = "Proceed to CheckPoint to proceed to next Level!";
                    audioSource.clip = audio[1];
                    audioSource.Play();
                    particle[0].Play();
                    door[0].SetActive(false);

                    Invoke("ForthWave", 5f);
                    done = true;


                }
               

                if (TotaldeathCount == 16)
                {
                    done = true;

                    helicopterAI.waypointIndex += 2;

                    Invoke("FifthWave", 5f);

                }
                
                if (TotaldeathCount == 20)
                {
                    done = true;

                    helicopterAI.waypointIndex += 2;

                    Invoke("SixthWave", 5f);

                }
              


                if (TotaldeathCount == 24)
                {
                    done = true;

                    helicopterAI.waypointIndex += 2;

                    WinStatus.SetActive(true);
                    WinStatusText.text = "Proceed to CheckPoint to proceed to next Level!";
                    audioSource.clip = audio[1];
                    audioSource.Play();
                    particle[1].Play();
                    door[1].SetActive(false);
                    particle[2].Play();
                    door[2].SetActive(false);
                    Invoke("SeventhWave", 5f);

                }

                if (TotaldeathCount == 28)
                {
                    done = true;

                    helicopterAI.waypointIndex += 2;

                    Invoke("EighthWave", 5f);

                }
                if (TotaldeathCount == 32)
                {
                    done = true;

                    helicopterAI.waypointIndex += 2;

                    Invoke("NinthWave", 5f);

                }
                if (TotaldeathCount == 36)
                {

                    done = true;

                    helicopterAI.waypointIndex += 2;

                    WinStatus.SetActive(true);
                    WinStatusText.text = "Almost Done....";
                    audioSource.clip = audio[1];
                    audioSource.Play();
                    // particle[2].Play();
                    //  door[2].SetActive(false);
                    Invoke("TenthWave", 5f);





                }
                if (TotaldeathCount == 40)
                {
                    done = true;

                    helicopterAI.waypointIndex += 2;

                    Invoke("EleventhWave", 5f);

                }
                if (TotaldeathCount == 44)
                {
                    done = true;

                    helicopterAI.waypointIndex += 2;

                    Invoke("TwelvethWave", 5f);

                }
                if (TotaldeathCount == 48)
                {

                    done = true;


                    helicopterCam.SetActive(true);
                    helicopterAI.enabled = false;

                    Invoke("helicopter1", 2f);

                }

            }

        }
        else if (Allowed == false)
        {
            allow = 0;
        }
        if (done == true)
        {
            d = 0;
        }
        else if (done == false)
        {
            d = 1;
        }
    }

    public void disablePopup()
    {
        WinStatus.SetActive(false);
    }
    public void addKills()
    {
        TotaldeathCount += 1;
        //spawning wave 1 of level 1
        
    }
           

            //Invoke("ThirteenthWave", 5f);
        
     /*   if (TotaldeathCount == 52)
        {
            Invoke("FourteenthWave", 5f);
        }
        if (TotaldeathCount == 56)
        {
            Invoke("FifteenthWave", 5f);
        }
        if (TotaldeathCount == 60)
        {
            Invoke("SixteenthWave", 5f);
        }
        if (TotaldeathCount == 64)
        {
            Invoke("SeventeenthWave", 5f);
        }
        if (TotaldeathCount == 68)
        {
            Invoke("EightteenthWave", 5f);
        }
        if (TotaldeathCount == 72)
        {
            Invoke("NineteenthWave", 5f);
        }
        if (TotaldeathCount == 76)
        {
            Invoke("TwentyWave", 5f);
        }
        if (TotaldeathCount == 80)
        {
            Invoke("TwentyOneWave", 5f);
        }
        if (TotaldeathCount == 84)
        {
            Invoke("TwentyTwoWave", 5f);
        }
        if (TotaldeathCount == 88)
        {
            Invoke("TwentyThreeWave", 5f);
        }
        if (TotaldeathCount == 92)
        {
            Invoke("TwentyFourWave", 5f);
        }
        if (TotaldeathCount == 96)
        {
            Invoke("TwentyFiveWave", 5f);
        }
        if (TotaldeathCount == 100)
        {
            Invoke("TwentySixWave", 5f);
        }
        */
    
    public void helicopter1()
    {
        helicopterAudioSource.Stop();
        helicopterExplosion.Play();
        audioSource.clip = audio[4];
        audioSource.Play();
        Invoke("helicopter2", 1.5f);

    }
    public void helicopter2()
    {
        HELICOPTER.GetComponent<BoxCollider>().enabled = true;
        HELICOPTER.GetComponent<CapsuleCollider>().enabled = true;

        HELICOPTER.GetComponent<BoxCollider>().size = new Vector3(0.1381812f, 0.2045382f, 0.5392404f);

        HELICOPTER.GetComponent<Rigidbody>().useGravity = true;
     //   helicopterAI.waypointIndex += 2;
        helicopterExplosion.Play();
        audioSource.clip = audio[5];
        audioSource.Play();

        Invoke("helicopter3", 1f);
        
    }
    public void helicopter3()
    {
        helicopterExplosion.Play();
        bodypart1.SetActive(false);
        bodypart2.SetActive(false);
        Invoke("hostagedFree", 3f);
    }
    public void hostagedFree()
    {
        helicopterCam.SetActive(false);
        hostagesCam.SetActive(true);

        hostages.SetActive(true);
        Invoke("ending", 4f);
    }
    public void ending()
    {
        hostages.SetActive(false);

        res.bulletamountShowWin();
        winCanvas.SetActive(true);
        res.bulletamountShowWin();
    }
    public void enablehelicopterSound()
    {
        HELICOPTER.GetComponent<AudioSource>().mute = false;
    }
    public void FirstWave()
    {
        for (int i = 0; i < WaveOne.Length; i++)
        {
            WaveOne[i].SetActive(true);

        }

        // GP.enemyEnables = true;

    }
    public void SecondWave()
    {
        for (int i = 0; i < WaveTwo.Length; i++)
        {
          //  WaveTwo[i].gameObject.transform.position = new Vector3(helicopterTransform.position.x, helicopterTransform.position.y, helicopterTransform.position.z);

            WaveTwo[i].SetActive(true);
        }
        GP.addEnemies();

    }
    public void ThirdWave()
    {
        for (int i = 0; i < WaveThree.Length; i++)
        {

            WaveThree[i].SetActive(true);

        }
        GP.addEnemies();

    }
    public void ForthWave()
    {
        for (int i = 0; i < WaveFour.Length; i++)
        {

            WaveFour[i].SetActive(true);

        }
        WinStatus.SetActive(false);

        GP.addEnemies();

    }
    public void FifthWave()
    {
        for (int i = 0; i < WaveFive.Length; i++)
        {
            WaveFive[i].SetActive(true);
        }
        GP.addEnemies();

    }
    public void SixthWave()
    {
        for (int i = 0; i < WaveSix.Length; i++)
        {
            WaveSix[i].SetActive(true);
        }
        GP.addEnemies();

    }
    public void SeventhWave()
    {
        for (int i = 0; i < WaveSeven.Length; i++)
        {
            WaveSeven[i].SetActive(true);
        }
        WinStatus.SetActive(false);

        GP.addEnemies();

    }
    public void EighthWave()
    {
        for (int i = 0; i < WaveEight.Length; i++)
        {
            WaveEight[i].SetActive(true);
        }
        GP.addEnemies();

    }
    public void NinthWave()
    {
        for (int i = 0; i < WaveNine.Length; i++)
        {
            WaveNine[i].SetActive(true);
        }
        GP.addEnemies();

    }
    public void TenthWave()
    {
        for (int i = 0; i < WaveTen.Length; i++)
        {
            WaveTen[i].SetActive(true);
        }
        WinStatus.SetActive(false);

        GP.addEnemies();

    }

    public void EleventhWave()
    {
        for (int i = 0; i < WaveEleven.Length; i++)
        {
            WaveEleven[i].SetActive(true);
        }
        GP.addEnemies();

    }
    public void TwelvethWave()
    {
        for (int i = 0; i < WaveTwelve.Length; i++)
        {
            WaveTwelve[i].SetActive(true);
        }
        GP.addEnemies();

    }
    /*   public void ThirteenthWave()
       {
           for (int i = 0; i < WaveThirteen.Length; i++)
           {
               WaveThirteen[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void FourteenthWave()
       {
           for (int i = 0; i < WaveFourteen.Length; i++)
           {
               WaveFourteen[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void FifteenthWave()
       {
           for (int i = 0; i < WaveFifteen.Length; i++)
           {
               WaveFifteen[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void SixteenthWave()
       {
           for (int i = 0; i < WaveSixteen.Length; i++)
           {
               WaveSixteen[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void SeventeenthWave()
       {
           for (int i = 0; i < WaveSeventeen.Length; i++)
           {
               WaveSeventeen[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void EightteenthWave()
       {
           for (int i = 0; i < WaveEighteen.Length; i++)
           {
               WaveEighteen[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void NineteenthWave()
       {
           for (int i = 0; i < WaveNineteen.Length; i++)
           {
               WaveNineteen[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void TwentyWave()
       {
           for (int i = 0; i < WaveTwenty.Length; i++)
           {
               WaveTwenty[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void TwentyOneWave()
       {
           for (int i = 0; i < WaveTwentyone.Length; i++)
           {
               WaveTwentyone[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void TwentyTwoWave()
       {
           for (int i = 0; i < WaveTwentytwo.Length; i++)
           {
               WaveTwentytwo[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void TwentyThreeWave()
       {
           for (int i = 0; i < WaveTwentythree.Length; i++)
           {
               WaveTwentythree[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void TwentyFourWave()
       {
           for (int i = 0; i < WaveTwentyfour.Length; i++)
           {
               WaveTwentyfour[i].SetActive(true);
           }
           GP.addEnemies();

       }
       public void TwentyFiveWave()
       {
           for (int i = 0; i < WaveTwentyfive.Length; i++)
           {
               WaveTwentyfive[i].SetActive(true);
           }
           GP.addEnemies();

       }*/

}
