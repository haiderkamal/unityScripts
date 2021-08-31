using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vehicalChooser : MonoBehaviour
{
    public int vehicalNum,color;
    public GameObject[] vehicals;
    public cameraFollow cam;
    public camRotateJS camR;
    public Texture[] vehicalTextures;
    // Start is called before the first frame update
    private void Awake()
    {
        //vehicalNum = PlayerPrefs.GetInt("Level");
       
        color = PlayerPrefs.GetInt("Color");
        vehicalNum = PlayerPrefs.GetInt("Vehical");
    }
    void Start()
    {
        vehicalNum = PlayerPrefs.GetInt("Vehical");
        color = PlayerPrefs.GetInt("Color");
        LevelSelect(vehicalNum);
        ChangeColor(color);
    }

   public void LevelSelect(int vehicalNumber)
    {
            vehicals[vehicalNumber].SetActive(true);
            vehicals[vehicalNumber].GetComponent<EngineSound>().enabled = true;
            cam.GetComponent<cameraFollow>().enabled = true;
            cam.MainVehical = vehicals[vehicalNumber];
            cam.CamPoint = vehicals[vehicalNumber].gameObject.transform.Find("CamPoint").gameObject;
            camR.camPoint = vehicals[vehicalNumber].gameObject.transform.Find("CamPoint").gameObject;
            camR.target = vehicals[vehicalNumber].transform;
       
    }
    public void ChangeColor(int color)
    {
        if (color == 1)
        {
            PlayerPrefs.SetInt("Color", color);
            vehicals[vehicalNum].gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture = vehicalTextures[0];
         
        }
        else if (color == 2)
        {
            PlayerPrefs.SetInt("Color", color);
            vehicals[vehicalNum].gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture = vehicalTextures[1];
            
        }
        else if (color == 3)
        {
            PlayerPrefs.SetInt("Color", color);
            vehicals[vehicalNum].gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture = vehicalTextures[2];
           
        }
        else if (color == 4)
        {
            PlayerPrefs.SetInt("Color", color);
            vehicals[vehicalNum].gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture = vehicalTextures[3];
           
        }
    }
}
