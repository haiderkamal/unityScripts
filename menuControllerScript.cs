using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuControllerScript : MonoBehaviour
{
    public int LoadScore;
    public int swordnumber;
    public int sword0L;
    public int sword1L;
    public int sword2L;
    public int sword3L;
    public GameObject InfoCanvas;
    public Text infoText;
    public int price;
    public Text buttonText;
    public Text totalScore;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SW0", 1);
        sword1L = 0;
        sword2L = 0;
        sword3L = 0;
        LoadGame();
    }
    public void loadCurrentCoins()
    {
        totalScore.text = LoadScore.ToString();
    }
    void LoadGame()
    {

        LoadScore = PlayerPrefs.GetInt("coinsCollected");
        sword0L = PlayerPrefs.GetInt("SW0"); 
        sword1L = PlayerPrefs.GetInt("SW1");
        sword2L = PlayerPrefs.GetInt("SW2");
        sword3L = PlayerPrefs.GetInt("SW3");
        swordnumber = PlayerPrefs.GetInt("currentSword");
        Debug.Log("Game data loaded!");


    }
    public void buttonTextChange(int num)
    {
        LoadGame();
        if (num == 0)
        {
            if (sword0L == 1)
            {
                buttonText.text = "Select";
            }
            if(sword0L == 0)
            {
                buttonText.text = "Buy";
            }
        }
        else if (num == 1)
        {
            if (sword1L == 1)
            {
                buttonText.text = "Select";
            }
            if (sword1L == 0)
            {
                buttonText.text = "Buy";
            }
        }else if (num == 2)
        {
            if (sword2L == 1)
            {
                buttonText.text = "Select";
            }
            if (sword2L == 0)
            {
                buttonText.text = "Buy";
            }
        }else if (num == 3)
        {
            if (sword3L == 1)
            {
                buttonText.text = "Select";
            }
            if (sword3L == 0)
            {
                buttonText.text = "Buy";
            }
        }
    }
    void SaveGame(int swordNumb)
    {
        
         
        PlayerPrefs.SetInt("coinsCollected", LoadScore);
        PlayerPrefs.SetInt("currentSword", swordNumb);
        PlayerPrefs.Save();
        Debug.Log(LoadScore);
    }
    // Update is called once per frame
    void Update()
    {
        
    }public void infoFun(int info, int swordNum)
    {
        if(swordNum == 1)
        {
            price = 100;
        }if(swordNum == 2)
        {
            price = 400;
        }if(swordNum == 3)
        {
            price = 1000;
        }
        InfoCanvas.SetActive(true);
        if(info == 0)
        {
            infoText.text = ("You Need " + (price - LoadScore) + "To Buy This");
        }
        else if (info == 1)
        {
            infoText.text = "Bought Successfull";
            buttonText.text = "Select";
        }
        
        
        
        
        
        else if(info == 10)
        {
            infoText.text = "Selected!";
        }
        Invoke("closeInfo", 3f);
    }
    public void closeInfo()
    {
        InfoCanvas.SetActive(false);
    }
    public void buySword(int swordNum)
    {
        LoadGame();
        if (swordNum == 0)
        {
            Debug.Log("Selected!");
            infoFun(10, 0);
        }
        else if (swordNum == 1)
        {
            if (sword1L == 0)
            {
                if (LoadScore >= 100)
                {
                    LoadScore -= 100;
                    Debug.Log("Bought Successful");
                    PlayerPrefs.SetInt("SW1", 1);
                    SaveGame(swordNum);
                    infoFun(1,1);
                    loadCurrentCoins();
                }
                else
                {
                    Debug.Log("Low Money");
                    infoFun(0, 1);
                }
            }
            else if(sword1L == 1)
            {
                Debug.Log("Selected!");
                infoFun(10, 0);
            }
        } else if (swordNum == 2)
        {
            if (sword2L == 0)
            {
                if (LoadScore >= 400)
                {
                    LoadScore -= 400;
                    Debug.Log("Bought Successful");
                    PlayerPrefs.SetInt("SW2", 1);
                    SaveGame(swordNum);
                    infoFun(1,2);
                    loadCurrentCoins();
                }
                else
                {
                    Debug.Log("Low Money");
                    infoFun(0, 2);
                }
            }
            else if(sword2L == 1)
            {
                Debug.Log("Selected!");
                infoFun(10, 0);
            }
        }else if (swordNum == 3)
        {
            if (sword3L == 0)
            {
                if (LoadScore >= 1000)
                {
                    LoadScore -= 1000;
                    Debug.Log("Bought Successful");
                    PlayerPrefs.SetInt("SW3", 1);
                    SaveGame(swordNum);
                    infoFun(1,3);
                    loadCurrentCoins();
                }
                else
                {
                    Debug.Log("Low Money");
                    infoFun(0, 3);
                }
            }
            else if(sword3L == 1)
            {
                Debug.Log("Selected!");
                infoFun(10, 0);
            }
        }
    }
}
