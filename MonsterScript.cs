using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterScript : MonoBehaviour
{
    public GameObject mainPlayer;
    public float time = 0;
    public float health = 100;
    public float healthTemp;
    public Image healthBar;
    public Image powerBar;
    public Animator animator;
    public bool dead;
    public bool isAttacking;
    public float timeHolder;
    public AudioClip[] audio;
    public AudioSource audiocsource;
    public bool inRange;
    public bool shieldBool;
    public int levelUnloack;
    public GameObject Wincanvas;
    // Start is called before the first frame update
    void Start()
    {
        healthTemp = health;
        dead = false;
        isAttacking = false;
        timeHolder = 40f;
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dead == false)
        {
            if (isAttacking == false)
            {
                Quaternion lookOnLook =
                Quaternion.LookRotation(mainPlayer.transform.position - transform.position);

                transform.rotation =
                Quaternion.Slerp(transform.rotation, lookOnLook, 5f * Time.deltaTime);
            }
            // this.gameObject.transform.rotation = Quaternion.Slerp(this.gameObject.transform.rotation, mainPlayer.transform.rotation, T);
            time += 10 * Time.deltaTime;
            if (time > timeHolder)
            {
                attackSystem();
                time = 0;
            }
        }
        powerBar.fillAmount = time / timeHolder;


    }
    public void Shield()
    {
        shieldBool = true;
        mainPlayer.GetComponent<mainPlayer>().shieldOn();
    }
    public void ShieldUP()
    {
        shieldBool = false;
        mainPlayer.GetComponent<mainPlayer>().shieldOff();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            inRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            inRange = false;
        }
    }
    public void healthReduce(int sword)
    {

        if(sword == 0)
        {
            health -= 10;
        }
        else if (sword == 1)
        {
            health -= 20;
        }else if (sword == 2)
        {
            health -= 60;
        }else if (sword == 3)
        {
            health -= 80;
        }
        
        timeHolder -= 2;
        healthBar.fillAmount = health / healthTemp;
        if (dead == false)
        {
            if (health <= 0)
            {

                animator.SetBool("death", true);
                dead = true;
                audiocsource.clip = audio[2];
                audiocsource.Play();
                Invoke("win", 4f);
            }
        }
        
        hitAnimation();
    }
    public void win()
    {
        Wincanvas.SetActive(true);
    }
    public void hitAnimation()
    {
        animator.SetBool("isHit", true);
        Invoke("stopAnim", 0.15f);
        Invoke("stopAnimHitSword", 1.15f);
    }
    public void stopAnim()
    {
        animator.SetBool("isHit", false);
        animator.SetBool("attackTwo", false);
        animator.SetBool("attackThree", false);
        animator.SetBool("isIdle", true);
        
        
    }
    public void stopAnimHitSword()
    {
        mainPlayer.GetComponent<mainPlayer>().hitStart = false;
    }
    public void attackSystem()
    {
        if (inRange == true)
        {
            
                isAttacking = true;
            if ((health / healthTemp) > 0.5f)
            {
                animator.SetBool("attackTwo", true);
                animator.SetBool("isIdle", false);
                Invoke("stopAnim", 0.15f);
                if (shieldBool == false)
                {
                    mainPlayer.GetComponent<mainPlayer>().healthReduce(10);
                }
            }
            else if (((health / healthTemp) <= 0.5f) && ((health / healthTemp) > 0f))
            {
                animator.SetBool("attackThree", true);
                animator.SetBool("isIdle", false);
                Invoke("stopAnim", 0.15f);
                if (shieldBool == false)
                {
                    mainPlayer.GetComponent<mainPlayer>().healthReduce(15);
                }
            }
            else if ((health / healthTemp) <= 0)
            {
                if (dead == false)
                {
                    if (health <= 0)
                    {

                        animator.SetBool("death", true);
                        dead = true;
                    }
                }
            }
                Invoke("attackOverr", 1.5f);
            
            if(shieldBool == true)
            {
                audiocsource.clip = audio[1];
                audiocsource.Play();
            }
        }
    }
    public void attackOverr()
    {
        isAttacking = false;
    }
}
