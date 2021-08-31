using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buy : MonoBehaviour {
    public snakemovements buyerscript;
    public Text textr;
    
	// Use this for initialization
	void Start () {
        buyerscript = GameObject.FindGameObjectWithTag("mainsnakeoo").GetComponent<snakemovements>();
       
	}
	
	// Update is called once per frame
	void Update () {

        textr.text = "Totle Score = " + buyerscript.scorer.ToString();
	}
    public void buy1() {
        if ((buyerscript.scorer - 10) < 0)
        { Debug.Log("hello"); }
        else
        {
            buyerscript.rotatonspeed += 5;
            buyerscript.scorer -= 10;
            textr.text = buyerscript.scorer.ToString();
        }
    
    }




    public void buy3()
    {
        if ((buyerscript.scorer - 10) < 0)
        { Debug.Log("hello"); }
        else
        {
            buyerscript.speed += 1;
            buyerscript.scorer -= 10;
            textr.text = buyerscript.scorer.ToString();

        }

    }
    public void buy4()
    {
        if ((buyerscript.scorer - 20) < 0)
        { Debug.Log("hello"); }
        else
        {
           
            buyerscript.scorer -= 20;
            textr.text = buyerscript.scorer.ToString();

        }

    }
    public void buy5()
    {
        if ((buyerscript.scorer - 100) < 0)
        { Debug.Log("hello"); }
        else
        {
            buyerscript.shieldtime += 3f;
            buyerscript.timer22 += 5f;
            buyerscript.scorer -= 100;
            textr.text = buyerscript.scorer.ToString();

        }

    }
    public void buy6()
    {
        if ((buyerscript.scorer - 300) < 0)
        { Debug.Log("hello"); }
        else
        {
            buyerscript.addfoodcount += 1;
            buyerscript.scorer -= 300;
            textr.text = buyerscript.scorer.ToString();

        }

    }
    
}
