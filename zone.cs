using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone : MonoBehaviour
{
    public float time;
    public GameObject zoneFeild;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public float health1;
    public float health2;
    public float health3;
    public float health4;
    public int sizeofListRecieved;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public restartScript res;
    // Start is called before the first frame update
    void Start()
    {
        time = 1000f;
    }

    // Update is called once per frame
    void Update()
    {
        zoneFeild.transform.localScale = new Vector3(zoneFeild.transform.localScale.x - Time.deltaTime, zoneFeild.transform.localScale.y - Time.deltaTime, zoneFeild.transform.localScale.z - Time.deltaTime);

        this.gameObject.transform.Rotate(new Vector3(0, 45 *  ((Time.deltaTime)/10f), 0));
        health1 = player1.gameObject.GetComponent<playerStats>().health;
        health2 = player2.gameObject.GetComponent<playerStats>().health;
        health3 = player3.gameObject.GetComponent<playerStats>().health;
        health4 = player4.gameObject.GetComponent<playerStats>().health;

        if (sizeofListRecieved == 2)
        {
            if (health1 <= 0)
            {
                if (player2.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
          else if (health2 <= 0)
            {
                if (player1.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
        }
        else if (sizeofListRecieved == 3)
        {
            if ((health1 <= 0)&& (health2 <= 0))
            {
                if (player3.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
         else if ((health2 <= 0)&& (health3 <= 0))
            {
                if (player1.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
          else  if ((health1 <= 0) && (health3 <= 0))
            {
                if (player2.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
        }
      else   if (sizeofListRecieved == 4)
        {
            if ((health1 <= 0) && (health2 <= 0)&& (health3 <= 0))
            {
                if (player4.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
           else if ((health2 <= 0) && (health3 <= 0)&&(health4 <= 0))
            {
                if (player1.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
           else if ((health1 <= 0) && (health3 <= 0) && (health4 <= 0))
            {
                if (player2.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
           else if ((health1 <= 0) && (health2 <= 0) && (health4 <= 0))
            {
                if (player3.gameObject.GetComponent<playerStats>().localID == true)
                {
                    res.bulletamountShowWin();
                    winCanvas.SetActive(true);
                    res.bulletamountShowWin();
                }
            }
        }
    }
    public void zoneSmaller()
    {
    }
}
