using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;

public class mainPlayer : MonoBehaviour
{
    public GameObject mainCamera;
    private float speed = 10f;
    public Rigidbody rb;
 
    public Vector3 mainPlayerTransformHolder;
  
    public int location = 0;
    public GameObject mainPlayerTransform;
    public  Animator animator;
    public bool hitBus;
    public GameObject hitBusHolder;
    public float hitbusbackmag;
    public Text mainScore;
    public int score;
    public AudioClip[] audio;
    public AudioSource audiocsource;
    public SwipeManager swipmanager;
    public float speedF;
    public float AngularSpeed;
    public GameObject FightCanvas;
    public bool isRunningLevel;
    private float speedR = 50.0f;
    private Vector3 worldCenter;
    public GameObject boss;
    public bool hitStart;
    public int strafeStatus;
    public float mainPlayerHealth;
    public Image mainPlayerHealthImage;
    public playfabManager playfabManagerScript;
    public int LoadScore;
    public int swordnumber;
    public GameObject[] Swordss;
    public bool shieldStatus;
    public GameObject healthBob;
    public GameObject chest;
    public bool lootStart;
    public GameObject[] healthBottle;
    public Transform loc1,loc2,loc3,loc4;
    public GameObject LoseCanvas;
    public GameObject Wincanvas;
    public string[] leaderboardPeeps;
    public int[] leaderboardPeepsScore;
    public int temp1;
    public string temp2;
    public Text otherPlayerScore;
    public Text otherPlayerName;
    public float nextMin;
    public int nextMinHelper;
    public Image bgScore;
    public float tempscore;
    void Start()
    {
        LoseCanvas.SetActive(false);
        Wincanvas.SetActive(false);
        lootStart = false;
        Vector3 otherPosn = this.transform.position;
        animator = GetComponent<Animator>();
        FightCanvas.SetActive(false);
        hitStart = false;
        Invoke("startRunning", 4f);
        mainPlayerHealth = 100f;
        shieldStatus = false;
        LoadGame();
        nextMin = 0;
    }
    public void startRunning()
    {
       
        isRunningLevel = true;
        animator.SetBool("isRuning", true);
        NextMin();
    }

     

    public void NextMin()
    {
        int ii = 0;
        int iii = leaderboardPeepsScore.Length-1;
        Array.Sort(leaderboardPeepsScore);
        for(int i=0; i<= leaderboardPeepsScore.Length - 1; i++)
        {
            if (leaderboardPeepsScore[ii] == 0)
            {
                ii++;
            }
            if (leaderboardPeeps[iii] == "")
            {
                iii--;
            }
            else
            {
                int H = ii + nextMinHelper; 
                int HH = iii - nextMinHelper;
                nextMin = (leaderboardPeepsScore[H]);
                tempscore = nextMin;
                nextMin -= score;
                bgScore.fillAmount = (float)(nextMin / tempscore);
                otherPlayerScore.text = nextMin.ToString();
                otherPlayerName.text = leaderboardPeeps[HH];
            }
        }

    }
    public void onCoinHitIncrease()
    {
        
        nextMin -= 1;
        otherPlayerScore.text = nextMin.ToString();
        bgScore.fillAmount =(float)( nextMin / tempscore);
        Debug.Log((float)(nextMin / tempscore));
        if (nextMin <= 0)
        {
            nextMinHelper += 1;
            NextMin();
        }
    }public void onChestHitIncrease()
    {
        nextMin -= 10;
        otherPlayerScore.text = nextMin.ToString();
        bgScore.fillAmount = (float)(nextMin / tempscore);
        if (nextMin <= 0)
        {
            nextMinHelper += 1;
            NextMin();
        }
    }
    public void sortLeaderboard()
    {
        /*
        int parse1;
        int parse2;

        // traverse 0 to array length
        for (int i = 0; i < leaderboardPeepsScore.Length - 1; i++)
        {

            // traverse i+1 to array length
            for (int j = i + 1; j < leaderboardPeepsScore.Length; j++)
            {
                // compare array element with 
                // all next element
                parse1 = System.Convert.ToInt32(leaderboardPeepsScore[i]);
                parse2 = System.Convert.ToInt32(leaderboardPeepsScore[j]);
                if (parse1 < parse2)
                {

                    temp1 = parse1;
                    temp2 = leaderboardPeeps[i];
                    parse1 = parse2;
                    leaderboardPeeps[i] = leaderboardPeeps[j];
                    parse2 = temp1;
                    leaderboardPeeps[j] = temp2;
                }
            }
        }*/
    }
    private void Update()
    {
       
        //rb.AddForce(Vector3.forward *2f);
        //transform.Translate(Vector3.forward * Time.deltaTime * speed);
        // transform.position += Vector3.forward * Time.deltaTime * speed;
        //this.transform.Translate(transform.right * speed * Time.smoothDeltaTime);
        //this.transform.position += transform.forward * speed;
        if (isRunningLevel == true)
        {
            
            speedF = rb.velocity.magnitude;
            AngularSpeed = rb.angularVelocity.magnitude;
            mainPlayer.ApplyForceToReachVelocity(rb, Vector3.forward * 10, 50);
            if (Input.GetKeyUp(KeyCode.D))
            {
                if (location == 0)
                {
                    location = 1;

                    animator.SetBool("isRight", true);
                    animator.SetBool("isRuning", false);

                }
                else if (location == -1)
                {
                    location = 0;

                    animator.SetBool("isRight", true);
                    animator.SetBool("isRuning", false);
                }
                Invoke("stopleftright", 0.2f);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                if (location == 0)
                {
                    location = -1;
                    animator.SetBool("isLeft", true);
                    animator.SetBool("isRuning", false);
                }
                else if (location == 1)
                {
                    location = 0;
                    animator.SetBool("isLeft", true);
                    animator.SetBool("isRuning", false);

                }
                Invoke("stopleftright", 0.2f);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {

                animator.SetBool("isJump", true);

                animator.SetBool("isRuning", false);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), 0.1f);


                Invoke("stopleftright", 0.2f);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {

                animator.SetBool("isRoll", true);

                animator.SetBool("isRuning", false);


                Invoke("stopleftright", 0.4f);
            }

            if (SwipeManager.swipeRight)
            {
                if (location == 0)
                {
                    location = 1;

                    animator.SetBool("isRight", true);
                    animator.SetBool("isRuning", false);

                }
                else if (location == -1)
                {
                    location = 0;

                    animator.SetBool("isRight", true);
                    animator.SetBool("isRuning", false);
                }
                Invoke("stopleftright", 0.2f);
            }


            if (SwipeManager.swipeLeft)
            {
                if (location == 0)
                {
                    location = -1;
                    animator.SetBool("isLeft", true);
                    animator.SetBool("isRuning", false);
                }
                else if (location == 1)
                {
                    location = 0;
                    animator.SetBool("isLeft", true);
                    animator.SetBool("isRuning", false);

                }
                Invoke("stopleftright", 0.2f);
            }

            if (SwipeManager.swipeUp)
            {

                animator.SetBool("isJump", true);

                animator.SetBool("isRuning", false);
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), 0.1f);


                Invoke("stopleftright", 0.2f);
            }
            if (SwipeManager.swipeDown)
            {

                animator.SetBool("isRoll", true);

                animator.SetBool("isRuning", false);


                Invoke("stopleftright", 0.4f);
            }
            // Debug.Log(location);



            if (location == -1)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3.5f, this.transform.position.y, this.transform.position.z), 0.3f);
            }
            else if (location == 0)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, this.transform.position.y, this.transform.position.z), 0.3f);
            }
            else if (location == 1)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(3.5f, this.transform.position.y, this.transform.position.z), 0.3f);
            }
            
        }
        else if (isRunningLevel == false)
        {
            if (hitStart == false)
            {
                if(shieldStatus == false) 
                { 
                    transform.RotateAround(worldCenter, Vector3.up, -Input.GetAxis("Horizontal") * 120f * Time.deltaTime); 
                }
               
            }
            if (Input.GetKeyDown(KeyCode.A))
            {

                if (hitStart == false)
                {
                    animator.SetBool("isStrafeLeft", true);
                    animator.SetBool("isStrafeRight", false);
                    animator.SetBool("isIdle", false);

                }

            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (hitStart == false)
                {

                    animator.SetBool("isStrafeRight", true);
                    animator.SetBool("isStrafeLeft", false);
                    animator.SetBool("isIdle", false);

                }
                //
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                Invoke("stopleftrightS", 0.01f);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                Invoke("stopleftrightS", 0.01f);
            }
            if (hitStart == false)
            {
                if (strafeStatus == -1)
                {
                    if (shieldStatus == false)
                    {
                        transform.RotateAround(worldCenter, Vector3.up, (1 * 120f) * Time.deltaTime);
                    }
                }
                if (strafeStatus == 0)
                {

                }
                if (strafeStatus == 1)
                {
                    if (shieldStatus == false)
                    {
                        transform.RotateAround(worldCenter, Vector3.up, (-1 * 120f) * Time.deltaTime);
                    }
                }
            }
            if (hitBus == true)
            {
                hitBusHolder.transform.position = Vector3.MoveTowards(hitBusHolder.transform.position, new Vector3((hitBusHolder.transform.position.x), hitBusHolder.transform.position.y, (hitBusHolder.transform.position.z + 0.1f)), 0.1f);
                Invoke("stopHitBus", 0.2f);
            }
        }

    }

    public void healthReduce(float value) {
        mainPlayerHealth -= value;
        animator.SetBool("isStrafeLeft", false);
        animator.SetBool("isStrafeRight", false);
        animator.SetBool("isIdle", false);
        animator.SetBool("smack", true);
        Invoke("smakcfalse", 1.5f);
        mainPlayerHealthImage.fillAmount = mainPlayerHealth / 100f;
        audiocsource.clip = audio[3];
        audiocsource.Play();
        if (mainPlayerHealth <= 0)
        {
            
            isRunningLevel = false;
            rb.velocity = Vector3.zero;
            audiocsource.clip = audio[1];
            audiocsource.Play();
            animator.SetBool("isStrafeRight", false);
            animator.SetBool("isStrafeLeft", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isHit", true);
            speed = 0;
            
            // playfabManagerScript.GetLeaderboard();
            SaveGame();
            Invoke("losecanvasshow", 3);
        }
       
    }
    public void smakcfalse()
    {
        animator.SetBool("isIdle", true);
        animator.SetBool("smack", false);
    }
    





    public void leftStrafeRun()
    {
        if (isRunningLevel == false)
        {
            strafeStatus = -1;


                animator.SetBool("isStrafeLeft", true);
                animator.SetBool("isStrafeRight", false);
                animator.SetBool("isIdle", false);     
            
        }
    }
    public void RightStrafeRun()
    {
        if (isRunningLevel == false)
        {
            strafeStatus = 1;


            animator.SetBool("isStrafeRight", true);
            animator.SetBool("isStrafeLeft", false);
            animator.SetBool("isIdle", false);

        }
    }
    public void StrafeRunUp()
    {
        if (isRunningLevel == false)
        {
            strafeStatus = 0;
            Invoke("stopleftrightS", 0.01f);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
       
        
        if (other.CompareTag("bus"))
        {
            SaveGame();
            isRunningLevel = false;
            rb.velocity = Vector3.zero;
            audiocsource.clip = audio[1];
            audiocsource.Play();
            hitBusHolder = other.gameObject;
            animator.SetBool("isRuning", false);
            animator.SetBool("isHit", true);
            speed = 0;
            hitBus = true;
            Invoke("losecanvasshow", 3);
        } 
        if (other.CompareTag("coin1"))
        {
            audiocsource.clip = audio[0];
            audiocsource.Play();
            score += 1;
            mainScore.text = score.ToString();
            onCoinHitIncrease();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Goal"))
        {
            SceneManager.LoadScene("betaLevel");
        }if (other.CompareTag("health"))
        {
            if (mainPlayerHealth <= 90)
            {
                mainPlayerHealth += 10;
                mainPlayerHealthImage.fillAmount = mainPlayerHealth / 100f;
                audiocsource.clip = audio[4];
                audiocsource.Play();
                
            }
            audiocsource.clip = audio[4];
            audiocsource.Play();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("chest"))
        {
            score += 10;
            mainScore.text = score.ToString();
            onChestHitIncrease();
            Destroy(other.gameObject);
            audiocsource.clip = audio[5];
            audiocsource.Play();


        }
        if (other.CompareTag("Boss1"))
        {
            FightCanvas.SetActive(true);
            isRunningLevel = false;
            lootStart = true;
            lootstarting();
            rb.velocity = Vector3.zero;
            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isJump", false);
            animator.SetBool("isRoll", false);
            animator.SetBool("isRuning", false);
            animator.SetBool("isIdle", true);
            worldCenter = new Vector3(boss.transform.position.x, boss.transform.position.y, boss.transform.position.z);
            Destroy(other.gameObject);
        }
    }
     public void lootstarting()
    {
        int r = UnityEngine.Random.Range(1, 4);
        if (r == 1)
        {
            Instantiate(healthBottle[0], new Vector3(loc1.position.x, loc1.position.y, loc1.position.z), Quaternion.identity);
        }
        else if (r == 2)
        {
            Instantiate(healthBottle[1], new Vector3(loc2.position.x, loc2.position.y, loc2.position.z), Quaternion.identity);
        }else if (r == 3)
        {
            Instantiate(healthBottle[2], new Vector3(loc3.position.x, loc3.position.y, loc3.position.z), Quaternion.identity);
        }else if (r == 4)
        {
            Instantiate(healthBottle[3], new Vector3(loc4.position.x, loc4.position.y, loc4.position.z), Quaternion.identity);
        }
        


    }
    public void stopleftright()
    {
        animator.SetBool("isRight", false);
        animator.SetBool("isLeft", false);
        animator.SetBool("isJump", false);
        animator.SetBool("isRoll", false);
        animator.SetBool("isRuning", true);
    }
    public void stopleftrightS()
    {
        animator.SetBool("isStrafeRight", false);
        animator.SetBool("isStrafeLeft", false);
        animator.SetBool("SwordHit", false);
        
        animator.SetBool("isIdle", true);
    }public void stopleftrightSW()
    {
       
        animator.SetBool("SwordHit", false);
        
        
    }
    public void stopHitBus()
    {
        hitBus = false;
    }
    public static void ApplyForceToReachVelocity(Rigidbody rigidbody, Vector3 velocity, float force = 1, ForceMode mode = ForceMode.Force)
    {
        if (force == 0 || velocity.magnitude == 0)
            return;

        velocity = velocity + velocity.normalized * 0.2f * rigidbody.drag;

        //force = 1 => need 1 s to reach velocity (if mass is 1) => force can be max 1 / Time.fixedDeltaTime
        force = Mathf.Clamp(force, -rigidbody.mass / Time.fixedDeltaTime, rigidbody.mass / Time.fixedDeltaTime);

        //dot product is a projection from rhs to lhs with a length of result / lhs.magnitude https://www.youtube.com/watch?v=h0NJK4mEIJU
        if (rigidbody.velocity.magnitude == 0)
        {
            rigidbody.AddForce(velocity * force, mode);
        }
        else
        {
            var velocityProjectedToTarget = (velocity.normalized * Vector3.Dot(velocity, rigidbody.velocity) / velocity.magnitude);
            rigidbody.AddForce((velocity - velocityProjectedToTarget) * force, mode);
        }
    }

    public void SwordHitInvoke()
    {
        if (hitStart == false)
        {
            animator.SetBool("SwordHit", true);
            Invoke("SwordHitFunc", 0.5f);
            Invoke("stopleftrightSW", 0.4f);
            
            hitStart = true;
        }
    }
    public void SwordHitFunc()
    {
        audiocsource.clip = audio[2];
        audiocsource.Play();
        boss.GetComponent<MonsterScript>().healthReduce(swordnumber);
        boss.GetComponent<MonsterScript>().hitAnimation();
        lootstarting();
    }
    public void shieldOn()
    {
        animator.SetBool("isShield", true);
        animator.SetBool("isIdle", false);
        shieldStatus = true;
    } public void shieldOff()
    {
        animator.SetBool("isShield", false);
        animator.SetBool("isIdle", true);
        shieldStatus = false;
    }
    void SaveGame()
    {
        //LoadGame();
        int TotalScore = score;
        PlayerPrefs.SetInt("coinsCollected", TotalScore);
        playfabManagerScript.SendLeaderBoard(TotalScore);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }
    void LoadGame()
    {
        
            LoadScore = PlayerPrefs.GetInt("coinsCollected");
            swordnumber = PlayerPrefs.GetInt("currentSword");
        score += LoadScore;
        mainScore.text = score.ToString();
        if (swordnumber == 0)
        {
            Swordss[0].SetActive(true);
            Swordss[1].SetActive(false);
            Swordss[2].SetActive(false);
            Swordss[3].SetActive(false);
        }else if(swordnumber == 1)
        {
            Swordss[0].SetActive(false);
            Swordss[1].SetActive(true);
            Swordss[2].SetActive(false);
            Swordss[3].SetActive(false);
        }else if(swordnumber == 2)
        {
            Swordss[0].SetActive(false);
            Swordss[1].SetActive(false);
            Swordss[2].SetActive(true);
            Swordss[3].SetActive(false);
        }else if(swordnumber == 3)
        {
            Swordss[0].SetActive(false);
            Swordss[1].SetActive(false);
            Swordss[2].SetActive(false);
            Swordss[3].SetActive(true);
        }
        Debug.Log("Game data loaded!");
        
        
    }
    public void losecanvasshow()
    {
        LoseCanvas.SetActive(true);
    }
}
