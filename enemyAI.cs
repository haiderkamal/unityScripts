using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class enemyAI : MonoBehaviour
{
    public Animator anim;
    public int damage,i=0;
    public float range = 100f;
    public GameObject GunPoint;
    public AudioSource audio;
    public AudioClip[] audioClips;
    public Transform thisPlayer;
    public GameObject[] otherPlayers;
    public GameObject[] otherPlayers1;

    public GameObject[] otherPlayers2;

    public bool inRange = false;
    public float time = 0;
    public ParticleSystem particle;

    public float[] distance;
    public float dis;
    public int a,ii;
    public bool isAlive;
    public GameObject[] pickUpItems;

    public bool StationaryEnemy;

    void Awake()
    {
        addPlayerInList();
    }
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        addPlayerInList();
        distance = new float[otherPlayers.Length];
        
        anim = this.gameObject.GetComponent<Animator>();
        dis= distance[0];
       
    }
    void Update()
    {
        addPlayerInList();
        if (isAlive == true)
        {
            MoveToNearestPlayer();
        }
    }
    public void pickUpItemsFunction()
    {
        for (int i = 0; i < pickUpItems.Length; i++)
        {
            pickUpItems[i].SetActive(true);
        }
    }
    public void addPlayerInList()
    {
        this.otherPlayers1 = GameObject.FindGameObjectsWithTag("MainPlayer");
        this.otherPlayers2 = GameObject.FindGameObjectsWithTag("MainPlayerOnline");

        this.otherPlayers = otherPlayers1.Concat(otherPlayers2).ToArray(); 




    }

    void startShoot()
    {
        audio.clip = audioClips[0];
        this.particle.Play();

        audio.Play();
        RaycastHit hit;
        if (Physics.Raycast(GunPoint.transform.position, GunPoint.transform.forward, out hit, range))
        {
            Debug.DrawRay(GunPoint.transform.position, GunPoint.transform.forward, Color.green);
            Debug.Log(hit.transform.name);
            playerStats target = hit.transform.GetComponent<playerStats>();
            if (target != null)
            {
                target.TakeDamage(damage);
                addPlayerInList();
            }
        }

    }

    public void MoveToNearestPlayer()
    {
        if (otherPlayers.Length == 1)
        {
            this.distance[0] = Vector3.Distance(this.otherPlayers[0].transform.position, this.gameObject.transform.position);

            //Auto Rotate Towared Player

            RotateTowardPlayer(0);

            //Auto Move TowardPlayer

            if (distance[0] > 1)
            {
                if(StationaryEnemy == false){
                    MoveTowardPlayer(0);
                }
            }

            //Shoot when sutiable
            if (distance[0] < 1)
            {
                this.anim.SetFloat("InputY", 0f);
                time += Time.deltaTime;
                if (time > 2f)
                {
                    this.Invoke("startShoot", 1f);
                    time = 0;
                }
            }
        }
        else if( otherPlayers.Length>1)
        {
            for (i = 0; i < otherPlayers.Length; i++)
            {
                this.distance[i] = Vector3.Distance(this.otherPlayers[i].transform.position, this.gameObject.transform.position);
            }
            for (ii = 0; ii < otherPlayers.Length; ii++)
            {
                if (ii == otherPlayers.Length - 1)
                {
                    //a=1 therefore 1-=1+1 == -1
                    a -= (ii + 1);
                }
                else
                {
                    a = 1;
                }

                if (distance[ii] > distance[ii + a])
                {
                    //Auto Rotate Towared Player

                    RotateTowardPlayer(ii + a);

                    //Auto Move TowardPlayer

                    if (distance[ii + a] > 1)
                    {
                        if (StationaryEnemy == false)
                        {
                            MoveTowardPlayer(ii + a);
                        }
                    }

                    //Shoot when sutiable
                    if (distance[ii + a] < 1)
                    {
                        this.anim.SetFloat("InputY", 0f);
                        time += Time.deltaTime;
                        if (time > 1f)
                        {
                            this.Invoke("startShoot", 1f);
                            time = 0;
                        }
                    }
                }

            }
        }

    }

    int RotateTowardPlayer(int PlayerNumber)
    {
        Vector3 relativeVector = ((this.otherPlayers[PlayerNumber].transform.position)-(this.gameObject.transform.position));
        this.gameObject.transform.rotation = Quaternion.LookRotation(relativeVector);
        return 0;
    }

    int MoveTowardPlayer(int PlayerNumber)
    {
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, otherPlayers[PlayerNumber].transform.position, 0.2f * Time.deltaTime);
        this.anim.SetFloat("InputY", 1f);
        return 0;
    }

    
}
