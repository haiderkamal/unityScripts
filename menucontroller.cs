using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class menucontroller : MonoBehaviour
{
    public GameObject[] vehicalsPrefabs;
    public int vehicalNumber = 0;
    public Transform vehicalSpanPoint;
    public GameObject CurrentVehical;
    public Image[] statsVehical1;
    public float VehicalSpeed1 = 0.2f;
    public float VehicalSpeed2 = 0.5f;
    public float VehicalHand1 = 0.7f;
    public float VehicalHand2 = 0.2f;
    public float VehicalBrake1 = 0.8f;
    public float VehicalBrake2 = 0.6f;
    public int Score =3000;
    public Text ScoreText;
    public Texture[] vehicalTextures;

    public ADS ad;
    public GameObject popUp;
    public Text popUpText;
    public GameObject controls;
    public GameObject Menu;
    public GameObject LevelType;
    public GameObject Levels;
    public cameraFollow cam;


    public float time;
    public Text timeText;
    public restartscript res;
    public void Start()
    {
       VehicalSpeed1 = 0.2f;
       VehicalSpeed2 = 0.5f;
       VehicalHand1 = 0.7f;
       VehicalHand2 = 0.2f;
       VehicalBrake1 = 0.8f;
       VehicalBrake2 = 0.6f;
       Score = 3000;
       vehicalNumber = 0;
       
       LoadCount();
       CurrentVehical = (GameObject) GameObject.Instantiate(vehicalsPrefabs[vehicalNumber]);
       ScoreText.text = Score.ToString();
       popUp.SetActive(false);
    }
    public void nextVehical(int a)
    {
        Destroy(CurrentVehical);
        vehicalNumber += a;
        if (vehicalNumber > vehicalsPrefabs.Length-1)
        {
            vehicalNumber = 0;
        }
        else if (vehicalNumber < 0)
        {
            vehicalNumber = vehicalsPrefabs.Length - 1;
        }
        CurrentVehical = (GameObject)GameObject.Instantiate(vehicalsPrefabs[vehicalNumber]);
        updateStats();

    }

    public void updateStats()
    {
        if(vehicalNumber == 0)
        {
            statsVehical1[0].fillAmount = VehicalSpeed1;
            statsVehical1[1].fillAmount = VehicalHand1;
            statsVehical1[2].fillAmount = VehicalBrake1;

        }
        else if(vehicalNumber == 1)
        {
            statsVehical1[0].fillAmount = VehicalSpeed2;
            statsVehical1[1].fillAmount = VehicalHand2;
            statsVehical1[2].fillAmount = VehicalBrake2;

        }
    }
   
    public void LoadCount()
    {
        VehicalSpeed1 = PlayerPrefs.GetFloat("vehicalSpeed1");
        VehicalSpeed2 = PlayerPrefs.GetFloat("vehicalSpeed2");
        VehicalHand1 = PlayerPrefs.GetFloat("vehicalHand1");
        VehicalHand2 = PlayerPrefs.GetFloat("vehicalHand2");
        VehicalBrake1 = PlayerPrefs.GetFloat("vehicalBrake1");
        VehicalBrake2 = PlayerPrefs.GetFloat("vehicalBrake2");
        Score = PlayerPrefs.GetInt("score;");
        ScoreText.text = Score.ToString();
        Debug.Log("Loaded");
        if(VehicalSpeed1 == 0)
        {
            Debug.Log("LoadedFirstTime");
            SaveCountFirst();
            LoadCount();
        }
    }
    public void SaveCount()
    {
        PlayerPrefs.SetFloat("vehicalSpeed1", VehicalSpeed1);
        PlayerPrefs.SetFloat("vehicalSpeed2", VehicalSpeed2);
        PlayerPrefs.SetFloat("vehicalHand1", VehicalHand1);
        PlayerPrefs.SetFloat("vehicalHand2", VehicalHand2);
        PlayerPrefs.SetFloat("vehicalBrake1", VehicalBrake1);
        PlayerPrefs.SetFloat("vehicalBrake2", VehicalBrake2);
        PlayerPrefs.SetFloat("score", Score);
        Debug.Log("Saved");
    }
    public void SaveCountFirst()
    {
        PlayerPrefs.SetFloat("vehicalSpeed1", 0.2f);
        PlayerPrefs.SetFloat("vehicalSpeed2", 0.5f);
        PlayerPrefs.SetFloat("vehicalHand1", 0.7f);
        PlayerPrefs.SetFloat("vehicalHand2", 0.2f);
        PlayerPrefs.SetFloat("vehicalBrake1", 0.8f);
        PlayerPrefs.SetFloat("vehicalBrake2", 0.6f);
        PlayerPrefs.SetFloat("score", 0);
        Debug.Log("SavedFirstTime");
    }
    public void UpgradeStats()
    {
        if (Score > 1000)
        {
            if(vehicalNumber == 0)
            {
                VehicalSpeed1 += 0.2f;
                VehicalHand1 += 0.2f;
                VehicalBrake1 += 0.2f;
                updateStats();
                Score -= 1000;
                ScoreText.text = Score.ToString();
                SaveCount();
                Debug.Log("Vehical 1 Upgraded");
            }
            else if (vehicalNumber == 1)
            {
                VehicalSpeed2 += 0.2f;
                VehicalHand2 += 0.2f;
                VehicalBrake2 += 0.2f;
                updateStats();
                Score -= 1000;
                ScoreText.text = Score.ToString();
                SaveCount();
                Debug.Log("Vehical 2 Upgraded");
            }
        }
        else
        {
            popUp.SetActive(true);
            popUpText.text = "You Need Just " + (1000-Score).ToString() + "$";
            Debug.Log("Low on Cash");
        }
    }
    public void ChangeColor(int color)
    {
        if(color == 1)
        {
            PlayerPrefs.SetInt("Color", color);
            CurrentVehical.gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture = vehicalTextures[0];
            ad.RequestInterstitial();
        }
        else if (color == 2)
        {
            PlayerPrefs.SetInt("Color", color);
            CurrentVehical.gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture= vehicalTextures[1];
            ad.RequestInterstitial();
        }
        else if (color == 3)
        {
            PlayerPrefs.SetInt("Color", color);
            CurrentVehical.gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture= vehicalTextures[2];
            ad.RequestInterstitial();
        }
        else if (color == 4)
        {
            PlayerPrefs.SetInt("Color", color);
            CurrentVehical.gameObject.transform.Find("body").GetComponent<Renderer>().materials[1].mainTexture = vehicalTextures[3];
            ad.RequestInterstitial();
        }
    }
    public void cash()
    {
        popUp.SetActive(true);
        popUpText.text = "YOU HAVE " + Score.ToString() + "$";
    }
    public void closePopup()
    {
        popUp.SetActive(false);
    }
    public void ShowLevelType()
    {
        Menu.SetActive(false);
        Levels.SetActive(false);
        LevelType.SetActive(true);
        
    }
    public void ShowLevel()
    {
        Menu.SetActive(false);
        LevelType.SetActive(false);
        Levels.SetActive(true);
    }
    public void StartLevel(int a)
    {
        if (a == 1)
        {
            PlayerPrefs.SetInt("Level", a);
            PlayerPrefs.SetInt("Vehical", vehicalNumber);
            SceneManager.LoadScene(a);
        }
    }
    public void ending()
    {
        time -= Time.deltaTime;
        timeText.text = Mathf.RoundToInt(time).ToString();
        if (time <= 0)
        {
            timeText.text = "YOU WON!";
           res.restartDelay();
        }
    }
}
